﻿/*

using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;



namespace TFR_cons
{
	class Program // Main class
	{

		//public static OpenQA.Selenium.Chrome.ChromeOptions options = new ChromeOptions();
		//options.AddArgument("--disable-gpu");

		public static OpenQA.Selenium.Chrome.ChromeDriver ChromeDriver = new ChromeDriver();
		public static IJavaScriptExecutor js = (IJavaScriptExecutor)ChromeDriver; // Make JS instance for JS execution

		static void Main(string[] args) // Main method
		{

			//DataBase.DBCreate();
			//DataBase.DBConnect();
			//DataBase.DBStructCreate();

			//DataBase.DropDB(); // Not working
			//DataBase.DropTable();

			//DataBase.DBInsertStartingBalance(0); // Must be added only onece before buliding the statistics

			//DataBase.DBaddClosePosition("SBER", "close", "long", DateTime.Now, 200, 162.5, "close message");

			//DataBase.InsertTicker("KOPL");

			//DataBase.UpdateRecordClosePosition("closed", "long", DateTime.Now, 28, 9.19, "just closed"); // Add open position info. USED FOR ACC BALANCE UPD
			//DataBase.UpdateRecordOpenPosition(DateTime.Now, 1.91, 2, 3, 10, 2, 11, "open and open");

			//DataBase.UpdateProfit();

			

			Console.WriteLine("Please set an action: ");
			string s = Console.ReadLine();
			Console.WriteLine("Action: " + s);

			if (s == "drop table")
				DataBase.DropTable();
			else if (s == "new db")
			{
				DataBase.DropTable();
				DataBase.DBStructCreate();
				DataBase.DBInsertStartingBalance(0);
				//DataBase.InsertTicker("SBER");
			}
			else if (s == "")




				Properties.Settings.Default.dbCreated = true;
			TFR_cons.Properties.Settings.Default.dbCreated = true;


			//var options = new ChromeOptions(); // Create Chrom browser instance and call it as a driver
			//options.AddArgument("--disable-gpu");
			//ChromeDriver = new ChromeDriver(options);

			Anticaptcha_example.Program.ExampleGetBalance(); // GetBalance method call from Anticaptcha_example project and output result to console

			try { ChromeDriver.Navigate().GoToUrl("https://profit.ly/login"); } // Go to URL
			catch { Console.WriteLine("Can't go to: https://profit.ly/login ");}

			try { ChromeDriver.FindElementByXPath("//*[@id=\"confirm-modal\"]/div[3]/span/a").Click(); } // Click on OK disclamer button
			catch { Console.WriteLine("Can't click on desclamer button. There is no pop-up window or page changed."); }

			List<string> jsString = new List<string>(); // Collection for JS commands
			jsString.Add("document.getElementsByName('g-recaptcha-response')[0].style.display='block';"); // // Display text area for pasting resolved captcha. Make textarea where captcha hash generated by google must be posted visible. Captcha will be solved and posted to this textarea
			jsString.Add("document.getElementsByName('j_username')[0].value='hunterhpm@gmail.com';"); // Type login 
			jsString.Add("document.getElementsByName('j_password')[0].value='Hpm.41771';"); // Type password
			jsString.Add("document.getElementsByName('g-recaptcha-response')[0].value='" + Anticaptcha_example.Program.ExampleNoCaptchaProxyless() + "';");
			jsString.Add("document.getElementsByName('Submit')[0].click();"); // Submit button click 

			// JS execution
			foreach (string z in jsString) {
				try { Console.WriteLine("Executing JS command: " + z); js.ExecuteScript(z); }
				catch { Console.WriteLine("Getting element error: " + z + ". This command did not work. No such element or page changed. Error."); } }

			// Go to URL
			Console.WriteLine("go to: https://profit.ly/profiding");
			ChromeDriver.Navigate().GoToUrl("https://profit.ly/profiding");

			// Wait for 3 sec until the page is loaded
			Console.WriteLine("Wait for 5 sec until the page is loaded");
			System.Threading.Thread.Sleep(5000); 

			// Go to Trades tab 
			Console.WriteLine("Go to Trades tab ");
			try { ChromeDriver.FindElementByXPath("/html/body/div[4]/div[2]/div/div/div[2]/div[2]/div[2]/div[1]/div/div[1]/div[1]/ul/li[2]/a[2]/em/span/span").Click(); } 
			catch { Console.WriteLine("Can't go to trades tab."); }

			// Wait for 3 sec until the page is loaded
			Console.WriteLine("Wait for 5 sec until the page is loaded");
			System.Threading.Thread.Sleep(5000);


			// Cycle throught all pages, get and parse messages
			int i = 0;
			while (i <= 50)
			{
				i++;
				
				Console.WriteLine("GetAndRegex.Messages()");
				GetAndRegex.Messages(); // Pull and parse messages using regex

				Console.WriteLine("RemoveMessagesFromPage.RemoveMSGs()");
				RemoveMessagesFromPage.RemoveMSGs(); // Removes messages from the page

				Console.WriteLine("Press any key to load 10 more messages");
				//Console.ReadLine();

				LoadMoreButton.Click(); // Load more button click
				//Console.WriteLine("Lap number: " + i); // Stop on each page
			}

			//Console.WriteLine("");
			//Console.WriteLine("");
			//foreach (var z in GetAndRegex.tradeMessage) // List all items in messages collecion
				//Console.WriteLine("Parsed message: " + z.TradeMessageDate + " " + z.TradeMessageDirection + " " + z.TradeMessageStockQuantity + " " + z.TradeMessageStockTicker + " " + z.TradeMessagePrice); // + " " + z.TradeMessageText

			Console.WriteLine("Over");

		

		}
	}
}


*/