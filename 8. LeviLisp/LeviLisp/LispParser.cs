using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeviLisp
{
	public class LispParser
	{
		public IEnumerable<Statement> Parse(List<string> tokens2)
		{
			do
			{
				yield return ParseTokens(tokens2);
			} while ( tokens2.Any() );
		}

		public static Statement ParseTokens(List<string> tokenList)
		{
			var token = tokenList.First();
			tokenList.RemoveAt(0);
			if ( token == "(" )
			{
				var list = new List<Statement>();
				while ( tokenList.First() != ")" )
				{
					list.Add(ParseTokens(tokenList));
				}
				tokenList.RemoveAt(0);
				return new Statement(list);
			}
			return CreateElement(token);
		}


		public static Statement CreateElement(string token)
		{
			if ( IsDecimalDigit(token[0])
				|| token[0] == '-' && token.Length > 1 && IsDecimalDigit(token[1]))
			{
				return new Statement(StatementType.Number, token);
			}
			return new Statement(StatementType.Symbol, token);
		}

		public static bool IsDecimalDigit(char ch)
		{
			return ((ch >= '0') && (ch <= '9'));
		}
	}
}
