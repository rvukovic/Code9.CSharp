using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort
{
	class Program
	{
		static void Main(string[] args)
		{
			var intList = new List<int> { 45, 345, 43523, 576847, 5643, 768, 431, 435, 65787876 };
			
			//Sort_Delegates(intList);
			//Sort_Bubble(intList);
			//Sort_LINQ(intList);

			ExecutePersonSort();
		}

		private static void Sort_Bubble(List<int> list)
		{
			for (var i = 0; i < list.Count; i++)
				for (var k = 0; k < list.Count; k++)
				{
					if (list[i] < list[k])
					{
						var tmp = list[k];
						list[k] = list[i];
						list[i] = tmp;
					}
				}

			foreach ( var i in list )
			{
				Console.WriteLine(i);
			}
		}

		private static void Sort_Delegates(List<int> list)
		{
			list.Sort();
			foreach ( var i in list )
			{
				Console.WriteLine(i);
			}
		}

		private static void Sort_LINQ(List<int> list)
		{
			list.OrderBy(l => l).ToList().ForEach(Console.WriteLine);
		}

		private static void ExecutePersonSort()
		{
			var list = new List<Person>
			           	{
			           		new Person() {FirstName = "John", LastName = "Smith"},
			           		new Person() {FirstName = "Bob", LastName = "Marley"},
							new Person() {FirstName = "Jim", LastName = "Dylan"},
			           	};

			//list.Sort((x,y) => (x.FirstName + x.LastName).CompareTo(y.FirstName + y.LastName));
			//list.Sort((x, y) => (x.LastName + x.FirstName).CompareTo(y.LastName + y.FirstName));
			//list.ForEach(Console.WriteLine);

			var sorted = (from p in list
						  orderby p.FirstName, p.LastName
						  select p)
						  .ToList();
			sorted.ForEach(Console.WriteLine);
		}
	}
}
