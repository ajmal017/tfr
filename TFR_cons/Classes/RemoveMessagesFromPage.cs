using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR_cons
{
	class RemoveMessagesFromPage
	{

		public static void RemoveMSGs()
		{
			// Remove messages from DOM using JS
			int MessagesOnThePage = Program.ChromeDriver.FindElementsByClassName("GLS-JUXDKAD").Count;
			Console.WriteLine("Total messages: " + MessagesOnThePage);

			while (MessagesOnThePage != 0)
			{
				MessagesOnThePage--;
				{
					try
					{
						Program.js.ExecuteScript("var ele = document.querySelector('.GLS-JUXDKAD'); ele.parentNode.removeChild(ele); "); // This code removes the whole message
						Console.WriteLine("JS execution command: remove message on the page. Total messages on the page: " + MessagesOnThePage);
					}
					catch
					{
						Console.WriteLine("JS error. Can't remove message on the page. There is no more messages. Total messages: " + MessagesOnThePage);
					}
				}
			}
		}

	}
}
