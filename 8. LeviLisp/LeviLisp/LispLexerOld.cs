using System;
using System.Collections.Generic;
using System.Linq;

namespace LeviLisp
{
	public class LispLexerOld
	{
		public List<string> GetTokenList(string lispString)
		{
			lispString = lispString.Replace("(", " ( ");
			lispString = lispString.Replace(")", " ) ");
			lispString = lispString.Replace("\r\n","");

			var tokens = lispString.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			return tokens.Select(t => t.Trim()).ToList();
		}
	}
}