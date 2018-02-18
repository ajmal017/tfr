using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TFR_cons
{

	public static class InjectTestMessage
	{
		public static string jsString; // String for JS
		public static List<string> elseMessages = new List<string>() { "Added", "Covered", "Shorted"}; // Collection other than bought and sold messages
		public static void InjectMsg(string messageType)
		{
			// Need to use US culture for date insertion. Must be carefull with it! In DB Convert.ToDouble(command1.ExecuteScalar()) is used
			// It is sensetive to (,) and (.) symbold. If you turn all project into us-US culture sove feilds in DB like accumulated_sum_pcnt or
			// accumulated_balance can turn values 19.99999 to 1999999!
			// Experienced big trubble in DataBase.UpdateProfit() - Get the value of accumulated_sum_prcnt from the previous record then it will be used in a second query

			//CultureInfo.CurrentCulture = new CultureInfo("en-US"); 

			string z = GetAndTrackMMessages.lastMessageDate.AddHours(1).ToString("h:mm:ss tt"); // Add an hour to the date of last message and inject it to the page thus it will be read as a new one 

			Console.WriteLine("added date: " + z);

			switch (messageType)
			{
				case "bought":
					//Console.WriteLine("bought case detected");
					jsString = "var newItem = document.createElement('div'); newItem.style = ('background-color:green'); newItem.className = ('GLS-JUXDFAD'); newItem.innerHTML = ('<img src=\"./profitly_files/TimCover1_bigger.jpg\" width=50 height=50> 11/28 " + z + " - Bought 3000 of $BBBB at 1.59 - text message'); var list = document.getElementById('x-auto-1'); list.insertBefore(newItem, list.childNodes[0]);";
					break;
				case "sold":
					//Console.WriteLine("sold case detected");
					jsString = "var newItem = document.createElement('div'); newItem.style = ('background-color:red'); newItem.className = ('GLS-JUXDFAD'); newItem.innerHTML = ('<img src=\"./profitly_files/TimCover1_bigger.jpg\" width=50 height=50> 11/28 " + z + " - Sold 2000 of $BBBB at 1.60 - text message'); var list = document.getElementById('x-auto-1'); list.insertBefore(newItem, list.childNodes[0]);";
					break;
				case "else":
					//Console.WriteLine("else case detected");
					jsString = "var newItem = document.createElement('div'); newItem.style = ('background-color:gray'); newItem.className = ('GLS-JUXDFAD'); newItem.innerHTML = ('<img src=\"./profitly_files/TimCover1_bigger.jpg\" width=50 height=50> 11/28 " + z + " - " + elseMessages[(new Random()).Next(0, 3)] + " 2000 of $SSSS at 2.24 - text message'); var list = document.getElementById('x-auto-1'); list.insertBefore(newItem, list.childNodes[0]);";
					break;
			}
				
			try
			{
				Program.js.ExecuteScript(jsString); 
				//Console.WriteLine("Test message injected to the page");
			}
			catch (Exception err)
			{
				Console.WriteLine("JS error. Can't inject test message" + err);
			}

		}

	}
}
