using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LeviLINQ
{
	class Program
	{
		static void Main(string[] args)
		{
			var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};

			ExecuteDelayedLoop();

			//list.LeviWhere(n => n%2 == 00).ToList().ForEach(Console.WriteLine);
			//list.Select(n => n *n).ToList().ForEach(Console.WriteLine);
		}

		public static IEnumerable<int> Fibonacci(int count)
		{
			int n0 = 0;
			int n1 = 1;
			for ( int i = 0; i < count; i++ )
			{
				yield return n1;
				int next = n0 + n1;
				n0 = n1;
				n1 = next;
			}
		}

		public static void ExecuteDelayedLoop()
		{
			DateTime stop = DateTime.Now.AddSeconds(5);
			//foreach (int i in CountWithTimeLimit(stop))
			//{
			//    Console.WriteLine("Received {0}", i);
			//    Thread.Sleep(1000);
			//}


			foreach ( int i in Square(CountWithTimeLimit(stop)) )
			{
				Console.WriteLine("Received {0}", i);
				Thread.Sleep(1000);
			}
		}

		public static IEnumerable<int> Square(IEnumerable<int> list)
		{
			foreach (var i in list)
			{
				yield return i*i;
			}
		}

		public static IEnumerable<int> CountWithTimeLimit(DateTime limit)
		{
			for ( int i = 1; i <= 100; i++ )
			{
				if ( DateTime.Now >= limit )
				{
					yield break;
				}
				yield return i;
			}
		}
	}
}
