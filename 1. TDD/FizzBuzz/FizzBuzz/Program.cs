﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
	class Program
	{
		static void Main(string[] args)
		{
			var fb = new FizzBuzzGenerator();
			for ( int i = 1; i < 101; i++ )
			{
				Console.WriteLine(fb.Transform(i));
			}
		}
	}

	public class FizzBuzzGenerator
	{
		public string Transform(int i)
		{
			return (i%3 == 0)
			       	? (i%5 == 0) ? "FizzBuzz" : "Fizz"
			       	: (i%5 == 0) ? "Buzz" : i.ToString();
		}

		public string Transform1(int i)
		{
			string result = null;
			if ( i % 3 == 0 ) { result = "Fizz";}
			if ( i % 5 == 0 ) { result += "Buzz";}
			if ( result == null ) { result = i.ToString(); }
			return result;
		}

		public string Transform2(int i)
		{
			if ( i % 3 == 0 && i % 5 == 0 ) { return "FizzBuzz"; }
			if ( i % 3 == 0 ) { return "Fizz"; }
			if ( i % 5 == 0 ) { return "Buzz"; }
			return i.ToString();
		}
	}
}
