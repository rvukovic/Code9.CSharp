using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeviLisp.Tests
{
	[TestClass]
	public class LispLexerTexts
	{
		//[TestMethod]
		//public void Can_tokenize_empty_list()
		//{
		//    var lexer = new LispLexer();
		//    var list = "()";
		//    var result = lexer.GetTokenList(list);
		//    var expected = new[] {"(", ")"};
		//    CollectionAssert.AreEqual(expected,result);
		//}

		//[TestMethod]
		//public void Can_tokenize_empty_string()
		//{
		//    var lexer = new LispLexer();
		//    var list = "";
		//    var result = lexer.GetTokenList(list);
		//    var expected = new string[0] ;
		//    CollectionAssert.AreEqual(expected, result);
		//}

		//[TestMethod]
		//public void Can_tokenize_quoted_strings()
		//{
		//    var lexer = new LispLexer();
		//    var list = "(test \"neki string\" \"drugi string\")";
		//    var result = lexer.GetTokenList(list);
		//    var expected = new[] { "(", "test", "neki string", "drugi string", ")" };
		//    CollectionAssert.AreEqual(expected, result);
		//}

		//[TestMethod]
		//public void Can_tokenize_integer_last_bracket_problem()
		//{
		//    var lexer = new LispLexer();
		//    var list = "(1 22 3456789)";
		//    var result = lexer.GetTokenList(list);
		//    var expected = new[] { "(", "1", "22", "3456789", ")" };
		//    CollectionAssert.AreEqual(expected, result);
		//}

		//[TestMethod]
		//public void Can_tokenize_integer()
		//{
		//    var lexer = new LispLexer();
		//    var list = "(1 22 3456789 )";
		//    var result = lexer.GetTokenList(list);
		//    var expected = new[] { "(", "1", "22", "3456789", ")" };
		//    CollectionAssert.AreEqual(expected, result);
		//}

		//[TestMethod]
		//public void Can_tokenize_multiple_brackets()
		//{
		//    var lexer = new LispLexer();
		//    var list = "(() (()()()())";
		//    var result = lexer.GetTokenList(list);
		//    var expected = new[] { "(","(",")","(","(",")","(",")","(",")","(",")",")" };
		//    CollectionAssert.AreEqual(expected, result);
		//}
	}
}
