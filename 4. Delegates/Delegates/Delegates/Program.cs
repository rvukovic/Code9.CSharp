using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
	public delegate string AddPrefixDelegate(string input);

	public delegate string AddPrefixAndPostfix(string prefix, string postfix, string input);

	class Program
	{
		static void Main(string[] args)
		{
			//AddPrefixDelegate del = AddPrefix;
			//var result = del("test");
			//var result = del.Invoke("test");


			//AddPrefixDelegate del = delegate(string input) { return "+" + input; };
			//var result = del("test");


			//AddPrefixDelegate del = input => "=" + input;
			//var result = del("test");


			//AddPrefixAndPostfix del = (pre, post, input) => pre + input + post;
			//var result = del("<",">","test");

			Func<string,string,string,string> del = (pre, post, input) => pre + input + post;
			var result = del("<", ">", "test");



			Console.WriteLine(result);
		}

		public static string AddPrefix(string input)
		{
			return "-" + input;
		}
	}
	
	

}
