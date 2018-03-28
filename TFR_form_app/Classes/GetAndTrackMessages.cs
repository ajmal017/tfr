using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;

namespace TFR_form_app
{
	// Tracking messages on the page 
	static class GetAndTrackMMessages
	{
		public static List<TradeMessage> tradeMessage = new List<TradeMessage> { }; // List of objects - TradeMessages
		public static bool boughtFirstTIme = true; // Flag for passing through Bought message if it occures first in list. We need to start only form Sold message
		public static bool soldFlag = true; // This flag is used for determin the series of sold messages: bought ones - sold few times. If so we add ticker only onece and increment volume each time
		public static int messageSoldVolume = 0; // Value for sold stock quantity. 0 by default. If we get series of sold messages this value is increment each time and recorded to DB 

		public static string messageTicker = "";
		public static bool bougtMessageFlag = true; // Once recevied a Bought message - wait for Sold

		public static bool firstRunFlag = true; // Flag for first run and getting the last date of the message
		public static DateTime lastMessageDate; // Date of the last message
		static bool firstMessageDisplayed = false;

		static DateTime goToFavTabDateTime; // Variables for counting time for clicking on Favorite tab and going back to trades tab. Otherwise you will get disconnected after a while
		static DateTime goToTradesDateTime;
		static bool dateTimerFlag = true; // Record date for tab click flag  
		public static bool startTracking = true; // False by default. When set to true - start tracking messages at the page


		public static void MessageSearch(Form1 form)
		{
			
			while (true) // Continues cycle. Each iteration reads the page content
			{

				System.Threading.Thread.Sleep(1000); // Delay between each page parse. 1000 - 1 sec
				//ListViewLogging.log_add(form, "GetAndTrackMessages.cs", "Page parsed at: " + DateTime.Now.ToString("hh.mm.ss.fff"), "white");

				form.BeginInvoke(new Action(delegate ()
				{

					form.progressBar1.Minimum = 0;
					form.progressBar1.Maximum = 100;

					form.progressBar1.Step = 10;

					form.label2.Text = DateTime.Now.ToString("hh.mm.ss.fff");
					if (form.progressBar1.Value == 100)
					{
						//form.progressBar1.CreateGraphics().DrawString(DateTime.Now.ToString("hh.mm.ss.fff").ToString(), new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(form.progressBar1.Width / 2 - 10, form.progressBar1.Height / 2 - 7));
						form.progressBar1.Value = 0;

					}
					form.progressBar1.PerformStep();

				}
				)); // Invoke



			if (firstMessageDisplayed)  // Last line is not cleared at the first run
				{
					//ListViewLogging.log_add(form, "GetAndTrackMessages.cs", "Console.SetCursorPosition(0, Console.CursorTop - 1); // Returned cursor to the previous line", "white");
					//Helpers.ClearCurrentConsoleLine(); // Clear last line with parsed time
				}

				firstMessageDisplayed = true;

				if (dateTimerFlag)
				{
					goToFavTabDateTime = DateTime.Now.AddSeconds(30);
					goToTradesDateTime = DateTime.Now.AddSeconds(32);
					dateTimerFlag = false; // When date is recorded set flag to false until going to the Favorites tab
				}

				if ((DateTime.Compare(DateTime.Now, goToFavTabDateTime) > 0) && startTracking)
				{
					//ListViewLogging.log_add(form, "GetAndTrackMessages.cs", "Go to Favorite tab: ", "white");
					goToFavTabDateTime = DateTime.Now;
					Helpers.FavTabClick();
				}

				if ((DateTime.Compare(DateTime.Now, goToTradesDateTime) > 0) && startTracking) // Go back to trades tab after a short delay
				{
					//ListViewLogging.log_add(form, "GetAndTrackMessages.cs", "Go to Trades tab: ", "white");
					goToTradesDateTime = DateTime.Now;
					Helpers.TradesTabClick();
					dateTimerFlag = true;
				}


				int filter_couner = 0; // Counter for filtering messages. We need to get rid of messages with 2017 year mentined. There is no year in message and 12/28/17 date is considered the latest while parsing throught the whole page. Logic breaks in this case. Last message is the only one which is last on the screen.

				try
				{
					var InputString = Form1.ChromeDriver.FindElementsByClassName("GLS-JUXDFAD");

					foreach (var z in InputString) // Run cycle through all found elements on the page
					{
						try
						{

							Match match = Regex.Match(z.Text, @"(.+?PM|.+?AM)\s-\s(.+?)\s(\d+)\s.+?\s\$(.+)\sat\s(.+?)\s-\s(.+\s*.+)"); // Run through all found groups. Group - (). Regex online: https://regexr.com/																								
							string price = match.Groups[5].Value; // Need to get rid of (,) otherwise double.parse throws a error
																  //price = price.Replace('.', ','); // , Replace. Can be used in differen cultures enviroment
							string message_text = match.Groups[6].Value; // Need to get rid of (') because when sentence "i don't need it" goes to SQL query (') it interpreted as a an escape symbol
							message_text = message_text.Replace('\'', '*'); // Remove \ symbols from the parsed string. Otherwise - SQL error
							message_text = message_text.Truncate_x(255); // Crop the string to not longer than 255 sybols. Otherwise - SQL error

							// Last message date detection. When new message appears - its date must be > than current. For this purpuse we need to record the date ol last detected message
							// ! = "" There are other empty classes on the page. There are no message in them. Pass them
							if (match.Groups[1].Value != "" && filter_couner < 5) // Read only 5 messages. Messgaes that are later than 5th belong to 2017. We do not need to read 2017
							{
								//Console.WriteLine("msg num***: " + filter_couner + "\nTRACE\nDate: " + match.Groups[1].Value + "\nDirection: " + match.Groups[2].Value + "\nQuantity: " + match.Groups[3].Value + "\nTicker: " + match.Groups[4].Value + "\nPrice: " + Double.Parse(price));
								filter_couner++;

								if (firstRunFlag)
								{
									lastMessageDate = DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture);
									//Console.WriteLine("Tracking messages started. First run. Last message date: " + match.Groups[1].Value);
									ListViewLogging.log_add(form, "parserListBox", "GetAndTrackMessages.cs", "Tracking messages started. First run. Last message date: " + match.Groups[1].Value, "white");
									firstRunFlag = false;

									ListViewLogging.log_add(form, "parserListBox", "GetAndTrackMessages.cs", "Date added. New added message with date later than this is considered as new: " + GetAndTrackMMessages.lastMessageDate.AddMinutes(1).ToString("h:mm:ss tt"), "white");
									ListViewLogging.log_add(form, "parserListBox", "GetAndTrackMessages.cs", "Last message parsing example. This output must be the same as the message at the page. Is everything correct?\nDate: " + match.Groups[1].Value + "\nDirection: " + match.Groups[2].Value + "\nQuantity: " + match.Groups[3].Value + "\nTicker: " + match.Groups[4].Value + "\nPrice: " + Double.Parse(price), "white");

									//Console.WriteLine("Date added. New added message with date later than this is considered as new: " + GetAndTrackMMessages.lastMessageDate.AddMinutes(1).ToString("h:mm:ss tt")); // DateTime.Now.Date.ToString("MM/dd/yyyy")
									//Console.WriteLine("Last message parsing example. This output must be the same as the message at the page. Is everything correct?\nDate: " + match.Groups[1].Value + "\nDirection: " + match.Groups[2].Value + "\nQuantity: " + match.Groups[3].Value + "\nTicker: " + match.Groups[4].Value + "\nPrice: " + Double.Parse(price));
								}

								// New message detected. Message date > lastMessageDate
								DateTime h = DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture);

								//Console.WriteLine("TRACE: DateTime.Compare(h, lastMessageDate) > 0: " + (DateTime.Compare(h, lastMessageDate) > 0) + ". h: " + h + ". lastMessageDate: " + lastMessageDate);
								if (DateTime.Compare(h, lastMessageDate) > 0)
								{
									ListViewLogging.log_add(form, "parserListBox", "GetAndTrackMessages.cs", "New message on the page is detected!", "white");
									lastMessageDate = DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture);

									// Bought
									if (match.Groups[2].Value == "Bought" && bougtMessageFlag == true)
									{
										ListViewLogging.log_add(form, "parserListBox", "GetAndTrackMessages.cs", "********************ACTION: Bought", "green");
										bougtMessageFlag = false;
										messageTicker = match.Groups[4].Value;

										// DB Actions
										DataBase.InsertTicker(match.Groups[4].Value); // Added ticker, record created then update it
										DataBase.UpdateRecordOpenPosition("open", "long", DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture), Double.Parse(price), 0, 0, 0, 0, 0, message_text);
										messageSoldVolume = Int32.Parse(match.Groups[3].Value);

										// Boroker actions
										form.placeOrder.SendOrder("buy", match.Groups[4].Value); // Send BUY order to the exchange
										Email.Send("Bought action. Ticker: " + match.Groups[4].Value + ". PLEASE CHECK THE ACCOUNT!!! ");

									}

									//Console.WriteLine("TRACE: sold: " + match.Groups[2].Value + " ticker: " + messageTicker + " current ticker: " + match.Groups[4].Value + " boughMessageFlag: " + bougtMessageFlag);

									// Sold
									if (match.Groups[2].Value == "Sold" && messageTicker == match.Groups[4].Value && bougtMessageFlag == false)
									{
										ListViewLogging.log_add(form, "parserListBox", "GetAndTrackMessages.cs", "********************ACTION: Sold", "red");
										bougtMessageFlag = true;

										// DB Actions 
										DataBase.UpdateRecordClosePosition(DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture), messageSoldVolume, Double.Parse(price), message_text);
										DataBase.UpdateProfit(); // Uptade profit and calculate values
										messageSoldVolume = 0; // Set volume to 0. If Sold signal occured - we need to start increment volume from scratch

										// Boroker actions
										MessageBox.Show("sold");
										form.placeOrder.SendOrder("sell", match.Groups[4].Value); // Send SELL order to the exchange
										Email.Send("Sold action. Ticker: " + match.Groups[4].Value + ". PLEASE CHECK THE ACCOUNT!!! ");
									}
								}
							}


							/*

							// Open message appeared
							if (match.Groups[2].Value == "Bought" && bougtMessageFlag)
							{
								bougtMessageFlag = false; // Next cycle run dont go into this if until Sold message is receive
								messageTicker = match.Groups[4].Value;
								Console.WriteLine("Bought detected. Ticker: " + match.Groups[4].Value);
							}

							// Sold message appeared
							if (match.Groups[2].Value == "Sold" && match.Groups[4].Value == messageTicker)
							{
								bougtMessageFlag = true; // Next cycle run go into Bought message if
														 //messageTicker = match.Groups[4].Value;
								Console.WriteLine("Close detected. Ticker: " + match.Groups[4].Value);
							}

							// Condition: direction is Bought, we must start with only Sold message, we must follow the secuence with the same ticker excluding different tickers. The sequence (ticker) resets at the bought message
							if (match.Groups[2].Value == "Bought" && !boughtFirstTIme && messageTicker == match.Groups[4].Value)
							{
								DataBase.UpdateRecordOpenPosition(DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture), Double.Parse(price), 0, 0, 0, 0, 0, message_text);
								DataBase.UpdateProfit(); // Uptade profit and calculate values
								soldFlag = true; // Set soldFlag to true. Means that series of sold messages is over an bought message accured. Sold, Sold, Bought. Next sold will have to add ticker
								messageSoldVolume = 0; // Set volume to 0. If Bought signal occured - we need to start increment volume from scratch
								messageTicker = ""; // Reset ticker 
							}

							// Condition: sell message and ticker is the same as in the first Sold message. We need this in order to pass other tickers in middle of the secuence
							// There may be other messages with different ticker between Sold and other Solds messages - dont count them.
							if (match.Groups[2].Value == "Sold" && (messageTicker == match.Groups[4].Value || messageTicker == ""))
							{
								if (soldFlag) // If series of Sold messages occures - add ticker to DB only ones at the first message 
								{
									messageTicker = match.Groups[4].Value;// remember ticker	
									DataBase.InsertTicker(match.Groups[4].Value); // Added ticker, record created then update it
									soldFlag = false;
								}

								// At each occurance of sold message - update a recoed
								// Update close position no matter whether it is the only message or the series
								messageSoldVolume = messageSoldVolume + Int32.Parse(match.Groups[3].Value); //
								DataBase.UpdateRecordClosePosition("closed", "long", DateTime.ParseExact(match.Groups[1].Value, "M/d h:mm:ss tt", CultureInfo.InvariantCulture), messageSoldVolume, Double.Parse(price), message_text); // match.Groups[6].Value
								boughtFirstTIme = false; // We start from bought message the go to Bought
							}

							i++;

							*/
							//Console.ReadLine(); 

						}
						catch
						{
							Console.WriteLine("Regex error. Nothing to parse or content can't be parsed using existing regex");
						}

					}

				}
				catch // var InputString
				{
					Console.WriteLine("Regex error. Chrome browser window is closed? Restart the program");
				}

			}

		}

		// Function to crop string to 255 symbols. If lobger - getting a error while adding value to DB
		public static string Truncate_x(this string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value)) return value;
			return value.Length <= maxLength ? value : value.Substring(0, maxLength);
		}

	}


}


