using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FizzBuzz;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Can_transform_number_to_string()
		{
			var fb = new FizzBuzzGenerator();

			var result = fb.Transform(1);

			Assert.AreEqual("1", result);
		}

		[TestMethod]
		public void Number_that_is_multiply_of_3_returns_Fizz()
		{
			var fb = new FizzBuzzGenerator();

			var resut = fb.Transform(3);

			Assert.AreEqual("Fizz", resut);
		}

		[TestMethod]
		public void Number_that_is_multiply_of_5_returns_Buzz()
		{
			var fb = new FizzBuzzGenerator();

			var resut = fb.Transform(5);

			Assert.AreEqual("Buzz", resut);
		}

		[TestMethod]
		public void Number_that_is_multiply_of_3_and_5_returns_FizzBuzz()
		{
			var fb = new FizzBuzzGenerator();

			var resut = fb.Transform(15);

			Assert.AreEqual("FizzBuzz", resut);
		}
	}
}
