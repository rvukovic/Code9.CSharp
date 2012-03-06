using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
	class Program
	{
		static void Main(string[] args)
		{
			var pub = new Publisher();
			pub.Click += new ClickEvent(pub_Click);
			pub.Click += new ClickEvent(pub_Click2);

			pub.GenerateClick(2, 2);
		}

		static void pub_Click(object sender, int x, int y)
		{
			Console.WriteLine("Click {0},{1}", x, y);
		}

		static void pub_Click2(object sender, int x, int y)
		{
			Console.WriteLine("Click {0},{1}", x * x, y * y);
		}
	}

	public class Publisher
	{
		public event ClickEvent Click;

		public void OnClick(int x, int y)
		{
			if (Click != null)
			{
				Click(this, x, y);
			}
		}

		public void GenerateClick(int x, int y)
		{
			OnClick(x, y);
		}
	}

	public delegate void ClickEvent(object sender, int x, int y);

}
