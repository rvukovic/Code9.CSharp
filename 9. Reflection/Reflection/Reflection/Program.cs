using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new Person()
			{
				//Name = "Robert",
				//Age = 20,
			};

			Type t = typeof (Person);
			PropertyInfo[] props = t.GetProperties();

			foreach (var propertyInfo in props)
			{
				Console.WriteLine(propertyInfo.Name);
				var attribs = propertyInfo.GetCustomAttributes(typeof(LeviRequired), false);
				foreach (var a in attribs)
				{
					if ( a is LeviRequired )
					{
						Console.WriteLine("         Found required attribute");
						var name = t.GetProperty("Name").GetValue(p, null) as string;
						if(string.IsNullOrEmpty(name))
						{
							Console.WriteLine("         {0} is required", propertyInfo.Name);
						}
					}
				}
				attribs = propertyInfo.GetCustomAttributes(typeof(LeviRange), false);
				foreach ( var a in attribs )
				{
					if ( a is LeviRange )
					{
						var range = a as LeviRange;
						Console.WriteLine("         Found Range attribute for {0} is: {1} - {2}", propertyInfo.Name, range.From, range.To);

						var age =(int) t.GetProperty("Age").GetValue(p,null);
						if ( age < range.From || age > range.To )
						{
							Console.WriteLine("         Age: {0} is not allowed",age);
						}
					}
				}
			}



		}
	}

	public class Person
	{
		//public int Id { get; set; }

		[LeviRequired]
		public string Name { get; set; }

		[LeviRange(From = 18, To = 88)]
		public int Age { get; set; }
	}

	public class LeviRequired : Attribute
	{
	}

	public class LeviRange : Attribute
	{
		public int From { get; set; }
		public int To { get; set; }
	}
}
