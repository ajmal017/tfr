using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR_cons
{
	class LoadMoreButton
	{
		public static void Click ()
		{
			// Click on load more button. Now elements can be pulled via xpath
			Console.WriteLine("load more");
			int i = 1;
			//while (i<=10) // Get 10 messages
			//{
				Program.ChromeDriver.FindElementByXPath("/html/body/div[4]/div[2]/div/div/div[2]/div[2]/div[2]/div[1]/div/div[2]/div/div[2]/div[2]/div/div[1]/div/table/tbody/tr[2]/td[2]/div/div/table/tbody/tr/td/div").Click();
				System.Threading.Thread.Sleep(2000);
				Console.WriteLine("load more: " + i);
			//	i++;
			//}
		}
	}
}
