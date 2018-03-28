using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using SmartCOM4Lib;
using System.Diagnostics; // for stopwatch

namespace MDB_access
{
	class Smartcom
	{
		//public static StServer smartcom; // smartcom variable defenition (interface)
		public static SmartCOM4Lib.StServerClass smartcom;
		//DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123); // create date time 2008-03-09 16:05:07.123 ("Sunday, March 9, 2008")
		

		static string bumaga_1 = "RTS-12.12_FT"; // security
		static string ip = "mx2.ittrade.ru"; // broker server mx.ittrade.ru, mx2.ittrade.ru
		static ushort port = 8443;
		static string login = ""; //
		static string password = "";
		static string portfolio = "BP11260-RF-01"; // account
		public TimeSpan time;

		private static bool smartcom_created // bool variable for smartcom existence. true if smartcom is created
		{
			get
			{
				return (smartcom != null); // isready returns true if smartcom exists
			}
		}

		public static bool IsConnected // connection state variable
		{
			get
			{
				bool breturn = false; // connection flag. there is no connection by default. set it false
				if (smartcom_created) // true - smartcom is created
				{
					try
					{
						Console.WriteLine("smartcom_created = true. Smartcom is created");
						breturn = smartcom.IsConnected(); //put connection status to breturn 
					}
					catch (Exception error)
					{
						Console.WriteLine("Exception catch. Smarcom is not created. Is it even installed? Error: " + error);
					}
				}
				return breturn; // this function returns breturn value. connection status flag
			}
		}

		public static void Begin()
		{
			Console.WriteLine("Connection state (isconnected): " + IsConnected);

			if (!smartcom_created) // if smartcom is not created
				try
				{

					Console.WriteLine("Smartcom is not created (smartcom = null). Trying to create smartcom");
					//smartcom = new StServer(); // create new instance of ssmartcom
					smartcom = new SmartCOM4Lib.StServerClass();
					Console.WriteLine("Smartcom ver.: " + smartcom.GetStClientVersionString());

					Stopwatch timer = new Stopwatch();
					timer.Start();

					TimeSpan time = new TimeSpan();

					time = timer.Elapsed;
					string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					time.Hours, time.Minutes, time.Seconds, time.Milliseconds / 10);
					Console.WriteLine("RunTime " + elapsedTime);

					//smartcom events linking (delegates)
					smartcom.Connected += new _IStClient_ConnectedEventHandler(Connected);
					smartcom.Disconnected += new _IStClient_DisconnectedEventHandler(Disconnected);
					smartcom.AddTickHistory += new SmartCOM4Lib._IStClient_AddTickHistoryEventHandler(Smartcom_AddTickHistory);
					smartcom.AddTick += new SmartCOM4Lib._IStClient_AddTickEventHandler(Smartcom_AddTick);


				}

				catch (COMException error)
				{
					Console.WriteLine("COMexception error: " + error);
				}
				catch (Exception error)
				{
					Console.WriteLine("Exception error while smartcom creating: " + error);
				}
			else
			{
				Console.WriteLine("isready: " + smartcom_created + ". Smartcom is already created. No need to create");
			}




			Console.WriteLine("isready: " + smartcom_created);

			if (!IsConnected) // no connection
			{
				try
				{
					Console.WriteLine("Connection attempt. smartcom.connect()");
					smartcom.connect(ip, port, login, password);
				}
				catch (Exception Error)
				{
					Console.WriteLine("Connection error: , " + Error.Message);
				}
			}

		}

		private static void Smartcom_AddTickHistory(int row, int nrows, string symbol, DateTime datetime_history, double price, double volume, string tradeno, [ComAliasName("SmartCOM4Lib.StOrder_Action")] StOrder_Action action)
		{
			Console.WriteLine("Smartcom_AddTickHistory: row:" + row + " nrows: " + nrows + " " + symbol + " date: " + datetime_history + " price: " + price);
			
		}

		public static double stock = 0; //stock
		public static double spread = 0; // spread

		public static void Smartcom_AddTick(string symbol, DateTime datetime, double price, double volume, string tradeno, SmartCOM4Lib.StOrder_Action action)
		{
			
			//Console.WriteLine("ticker: " + symbol + " date: " + datetime + " price: " + price + " volume: " + volume + " direction: " + action);
			if (symbol == "SBRF-12.17_FT")
			{
				spread = price - stock;
				Console.WriteLine("spread: " + spread + " SBRF-12.17_FT:" + price );
			}
			else
			{
				stock = price * 100;
				//Console.WriteLine(symbol + " " + price);
			}
			

			if (symbol == "SBER")
			{
				//DataBase.DBInserRecord("stock_ticks", symbol, datetime, price);
				//Console.WriteLine(symbol + " " + price + "recorded to bd successful!");

			}
			else
			{
				//DataBase.DBInserRecord("futures_ticks", symbol, datetime, price);
				//Console.WriteLine(symbol + " " + price + "recorded to bd successful!");
			}
		}

		private static void Connected()
		{
		
			Console.WriteLine("Connection scceeded!");

			// After connection
			try
			{
				Console.WriteLine("GetTrades attempt");

				DateTime dt = new DateTime(2017, 10, 6, 10, 25, 0);
				//smartcom.GetTrades("GAZP", DateTime.Now.AddDays(-1), -1000); // Get tick history

				smartcom.ListenTicks("SBRF-12.17_FT"); // Futures
				smartcom.ListenTicks("SBER"); // Stock

				//smartcom.ListenTicks("Si-3.18_FT"); // RTS-12.17_FT

			}
			catch (Exception Error)
			{
				Console.WriteLine("GetTrades error: , " + Error.Message);
			}

		}

		private static void Disconnected(string reason)
		{
			Console.WriteLine("smartcom.disconected accured: " + reason);
		}


	}
			
}
