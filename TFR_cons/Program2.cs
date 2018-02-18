/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace TFR_cons
{
	class Program // Main class
	{
		static void Main() // Main method
		{
			// captcha http://www.imagetyperz.com/ 
			// regexp https://regex101.com/ 
			// https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-options?view=netframework-4.7.1 
			// https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.group?view=netframework-4.7.1

			Console.WriteLine("ff");

			List<string> titles = new List<string>();
			List<string> author = new List<string>();
			List<string> date = new List<string>();

			WebClient web = new WebClient(); // A web client for internet access
			string html = web.DownloadString("http://www.law.com/nationallawjournal/?slreturn=20171013132159"); // https://profit.ly/profiding
																												//string html = web.DownloadString("https://profit.ly/profiding");

			//MatchCollection m1 = Regex.Matches(html, @"<strong>\s*(.+?)\s*</strong>", RegexOptions.Singleline);
			//MatchCollection m1 = Regex.Matches(html, @"<h4 class=""article-title"">.+</h4>", RegexOptions.Singleline); // (.+?) Character of any lenght

			MatchCollection m1 = Regex.Matches(html, "<h4 class=\"article-title\">.+?</h4>", RegexOptions.Singleline); //SingleLine

			Console.WriteLine("Matches count: " + m1.Count);

			//Console.ReadLine();

			foreach (Match m in m1)
			{
				string title = m.Groups[1].Value;
				titles.Add(title);
				Console.WriteLine("zz: " + m);
				Console.WriteLine("*********");
			}


			//Console.WriteLine("zz: " + html);

			Console.ReadLine();
		}
	}
}

*/