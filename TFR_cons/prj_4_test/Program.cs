using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prj_4_test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("123");
			Console.WriteLine("123");
			Console.SetCursorPosition(0, Console.CursorTop - 1);
			ClearCurrentConsoleLine();
			Console.ReadLine();
		}

		public static void ClearCurrentConsoleLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}
	}
}
