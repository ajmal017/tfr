using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR_form_app
{
	class Helpers
	{
		public static void ClearCurrentConsoleLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}

		public static void FavTabClick()
		{
			try
			{
				Form1.ChromeDriver.FindElementByXPath("/html/body/div[4]/div[2]/div/div/div[2]/div[2]/div[2]/div[1]/div/div[1]/div[1]/ul/li[4]").Click();
			}
			catch (Exception err)
			{
				Console.WriteLine("FavTabClick(). FindElementByXPath. Element not found: " + err);
			}
		}


		public static void TradesTabClick()
		{
			try
			{
				Form1.ChromeDriver.FindElementByXPath("/html/body/div[4]/div[2]/div/div/div[2]/div[2]/div[2]/div[1]/div/div[1]/div[1]/ul/li[2]").Click();
			}
			catch (Exception err)
			{
				Console.WriteLine("TradesTabClick(). FindElementByXPath. Element not found: " + err);
			}
		}

	}


}
