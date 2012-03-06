using System;

namespace LeviLisp
{
	class Program
	{
		static void Main(string[] args)
		{
			var examplList = new[]
			                 	{
			                 		"(add 1 2)",
			                 		"(add 1 (add 2 3))",
			                 		"(define a 2)  (add 2 a)",
									"(define a 2) (define b 3)  (add a b)",
			                 		"(define a 2) (define b 3) (define c (add 3 3))  (add c b)",
									@"(define inc (lambda (n) (add n 1))) (inc 1)",
			                 		@"(if (> 1 2) (+ 4 5) (+ 10 8))",
									@"(quote some-test-string)",
									@"(quote (1 2 3 4 5 6))",
									"(define inc (lambda (n) (add n 1)))",
									"(lambda (n) (add n 1))"
			                 	};
			foreach (var e in examplList)
			{
				Console.WriteLine("    {0}", e);
			}
			
			Console.WriteLine();
			Console.WriteLine();
			
			//var lexer = new LispLexer();
			var lexer = new LispLexerOld();
			
			var parser = new LispParser();
			var evaluator = new LispEvaluator();
			var env = new LispEnvironment();

			int i = 1;
			while (true)
			{
				Console.Write("{0}> ", i++);
				
				string input = string.Empty;
				
				var line = Console.ReadLine();
				input += line + Environment.NewLine;
				var tokens = lexer.GetTokenList(input);
				var program = parser.Parse(tokens);
				foreach (var statment in program)
				{
					var res = evaluator.Eval(env, statment);
					Console.WriteLine("==> "+res);
				}
				Console.WriteLine();
			}
		}
	}
}
