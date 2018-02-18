using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TFR_cons
{
	static class GetAndRegex
	{
		public static List<TradeMessage> tradeMessage = new List<TradeMessage> { }; // List of objects - TradeMessages
		public static bool boughtFirstTIme = true; // Flag for passing through Bought message if it occures first in list. We need to start only form Sold message
		public static bool soldFlag = true; // This flag is used for determin the series of sold messages: bought ones - sold few times. If so we add ticker only onece and increment volume each time
		public static int messageSoldVolume = 0; // Value for sold stock quantity. 0 by default. If we get series of sold messages this value is increment each time and recorded to DB 

		// Ticker in the message. We use it for catching only open message with same ticker. Inconsistent sequences can occure
		// Sold ticker_1 volume 3000
		//		Sold ticker_2
		//		Bought ticker_2
		// Added ticker_1 volume 1500
		// Bought ticker_1 volume 1500
		// We miss (dont count) bought and sold ticker_2 which are located between Bought ticker_1 sequence 
		// When DataBase.UpdateRecordOpenPosition(); will be called at the bought message accurance only price will be added to the record, the volume remains the same
		// Then DataBase.UpdateProfit(); is caleed only price and current (accumulated) volume will be used for profit calculation
		// We don't need to accumulate bought and added volume because it must == to accumulated sold volume. In this case 3000
		public static string messageTicker = ""; 

		public static void Messages()
		{
			CultureInfo enUS = new CultureInfo("en-US"); // Date format for coverting string to datetime

			// Get all messages. There are 10 messages (signals) on the page. After "load more" button click 10 messages more loaded
			// We pull all messages from the page. Messages started with date - signals. Other messages are junk
			var InputString = Program.ChromeDriver.FindElementsByClassName("GLS-JUXDFAD");
			int i = 1;
			foreach (var z in InputString) // Run cycle through all found elements on the page
			{
				//Console.WriteLine("***************message " + i + ": " + z.Text);
				Match match = Regex.Match(z.Text, @"(.+?PM|.+?AM)\s-\s(.+?)\s(\d+)\s.+?\s(.+)\sat\s(.+?)\s-\s(.+\s*.+)"); // Run through all found groups. Group - ()
				Console.WriteLine("");
				Console.WriteLine("MATCH!\nDate: " + match.Groups[1].Value + "\nDirection: " + match.Groups[2].Value + "\nQuantity: " + match.Groups[3].Value+ "\nQuantity: " + match.Groups[3].Value + "\nTicker: " + match.Groups[4].Value + "\nPrice: " + match.Groups[5].Value);

				string price = match.Groups[5].Value; // Need to get rid of (,) otherwise double.parse throws a error
				price = price.Replace('.', ','); // , Replace 
				string message_text = match.Groups[6].Value; // Need to get rid of (') because when sentence "i don't need it" goes to SQL query (') it interpreted as a an escape symbol
				message_text = message_text.Replace('\'','*');
				message_text = message_text.Truncate_x(255); // Crop the string to not longer than 255 sybols. Otherwise - SQL error
				

				if (match.Groups[1].Value != "")  // There are 10 emty elemts with class GLS-JUXDFAD which we don't need. Start only from messages
					tradeMessage.Add(new TradeMessage { TradeMessageDate = DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture), TradeMessageDirection = match.Groups[2].Value, TradeMessageStockQuantity = Int32.Parse(match.Groups[3].Value), TradeMessageStockTicker = match.Groups[4].Value, TradeMessagePrice = Double.Parse(price), TradeMessageText = match.Groups[6].Value });

				// Condition: direction is Bought, we must start with only Sold message, we must follow the secuence with the same ticker excluding different tickers. The sequence (ticker) resets at the bought message
				if (match.Groups[2].Value == "Bought" && !boughtFirstTIme && messageTicker == match.Groups[4].Value)
				{
					DataBase.UpdateRecordOpenPosition("open", "long", DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture), Double.Parse(price), 0, 0, 0, 0, 0, message_text);
					DataBase.UpdateProfit(); // Uptade profit and calculate values
					soldFlag = true; // Set soldFlag to true. Means that series of sold messages is over an bought message accured. Sold, Sold, Bought. Next sold will have to add ticker
					messageSoldVolume = 0; // Set volume to 0. If Bought signal occured - we need to start increment volume from scratch
					messageTicker = ""; // Reset ticker 
				}

				// Condition: sell message and ticker is the same as in the first Sold message. We need this in order to pass other tickers in middle of the secuence
				// There may be other messages with different ticker between Sold and other Solds messages - dont count them.
				if (match.Groups[2].Value == "Sold" && ( messageTicker == match.Groups[4].Value || messageTicker == "")) 
				{
					if (soldFlag ) // If series of Sold messages occures - add ticker to DB only ones at the first message 
					{
						messageTicker = match.Groups[4].Value;// remember ticker	
						DataBase.InsertTicker(match.Groups[4].Value); // Added ticker, record created then update it
						soldFlag = false;
					}

					// At each occurance of sold message - update a recoed
					// Update close position no matter whether it is the only message or the series
					messageSoldVolume = messageSoldVolume + Int32.Parse(match.Groups[3].Value); //
					DataBase.UpdateRecordClosePosition(DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture), messageSoldVolume, Double.Parse(price), message_text); // match.Groups[6].Value
					boughtFirstTIme = false; // We start from bought message the go to Bought
				}

				i++;

				//Console.ReadLine(); 
			}

			// Output all added to collection elements
			//foreach (var z in tradeMessage) // List all items in messages collecion
				//Console.WriteLine("foreach: " + z.TradeMessageDate + " " + z.TradeMessageDirection + " " + z.TradeMessageStockQuantity + " " + z.TradeMessageStockTicker + " " + z.TradeMessagePrice); // + " " + z.TradeMessageText

		}


		// Function to crop string to 255 symbols. If lobger - error while adding value to DB
		public static string Truncate_z(this string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value)) return value;
			return value.Length <= maxLength ? value : value.Substring(0, maxLength);
		}

	}
}
