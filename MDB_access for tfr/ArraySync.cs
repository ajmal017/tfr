using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TFR_cons
{
	public static class ArraySync
	{

		public static List<DateTime> list1 = new List<DateTime> { }; // Collection initialization
		public static List<DateTime> list2 = new List<DateTime> { };

		public static void GenerateArray()
		{
			while (true)
			{

				Random v = new Random();

				/*
				int b = v.Next(3, 6);
				//Console.WriteLine("values added to list1:");
				for (int c = 1; c <= b; c++)
				{
					Random n = new Random();
					int m = n.Next(1, 3);
					list1.Add(m);
					System.Threading.Thread.Sleep(100);
				}
				list1.Sort();
				Console.WriteLine("");

				int b1 = v.Next(4, 8);
				//Console.WriteLine("values added to list2:");
				for (int c = 1; c <= b1; c++)
				{
					Random n = new Random();
					int m = n.Next(1, 6);
					list2.Add(m);
					System.Threading.Thread.Sleep(210);
				}
				list2.Sort();
				Console.WriteLine("");
				*/

				// list1, list2 output
				foreach (DateTime q in list1)
					Console.WriteLine("list1: " + q);
				Console.WriteLine("list1 count: " + list1.Count());
				Console.WriteLine("------------------");

				foreach (DateTime q in list2)
					Console.WriteLine("list2: " + q);
				Console.WriteLine("list1 count: " + list2.Count());
				Console.WriteLine("------------------");

				// Intersection using IEnumerable<>
				Console.WriteLine("Intersection using IEnumerable<>");
				IEnumerable<DateTime> both = list1.Intersect(list2);  // Find unic dates for both lists
				//foreach (DateTime a in both)
					//Console.WriteLine("both: " + a);


				// Intersection using LINQ
				List<DateTime> resultList;
				/*
				if (list2.Count > list1.Count) // If first collection longer than second one
				{
					//resultList = list1.Where(c => list2.Contains(c)).ToList(); // Linq query
					resultList = list1.Where(c => list2.Contains(c)).ToList();
				}
				else
				{
					resultList = list2.Where(c => list1.Contains(c)).ToList(); // Linq query
				}

				Console.WriteLine("intersecton usin linq. with repeated values:");
				foreach (DateTime a in resultList)
					Console.WriteLine(a); // resultlist output
				*/

				var zz = both.ToList(); // dates list 
				for (int i = 0; i < zz.Count(); i++)
				{
					int con = list1.Where(p => p == zz[i]).Count();
					Console.WriteLine("date: " + zz[i] + "count: " + con); // Later i should put foreach here. to go through all unic itercepted values in list1 and list2 
				}

				//foreach (DateTime a in resultList)
				//	Console.WriteLine(a); // resultlist output


				Console.ReadLine();
				Console.Clear();
			}
			
		}

	}
}
