using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR_cons
{
	public static class CountMessages
	{

		public static int Count()
		{
			int MessagesOnThePage = Program.ChromeDriver.FindElementsByClassName("GLS-JUXDKAD").Count;
			return MessagesOnThePage;
		}

	}
}
