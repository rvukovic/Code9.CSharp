using System.Linq;

namespace LeviLisp
{
	public class LispEvaluator
	{
		public Statement Eval(LispEnvironment environment, Statement statement)
		{
			if ( statement.Type == StatementType.Number )
				return statement;

			if ( statement.Type == StatementType.Symbol )
				return environment.GetElement(statement.Value);

			if ( statement.Type == StatementType.List )
			{
				if ( statement.List == null || statement.List.Any() == false )
					return null;

				if ( statement.List[0].Type == StatementType.Symbol )
				{
					if ( statement.List[0].Value.ToUpperInvariant() == "QUOTE"
						|| statement.List[0].Value.ToUpperInvariant() == "'" )  // (quote exp)
					{
						return statement.List[1];
					}

					if ( statement.List[0].Value.ToUpperInvariant() == "IF" ) // (if condition conseq [alt])
					{
						var condition = Eval(environment, statement.List[1]);
						if ( condition.Value.ToUpperInvariant() == LispEnvironment.True )
						{
							return Eval(environment, statement.List[2]);
						}
						return Eval(environment, statement.List[3]);
					}

					if ( statement.List[0].Value.ToUpperInvariant() == "DEFINE" )  // (define var exp)
					{
						var value = Eval(environment, statement.List[2]);
						environment.SetElement(statement.List[1].Value, value);
						return value;
					}

					if ( statement.List[0].Value.ToUpperInvariant() == "LAMBDA" ) // (lambda (var*) exp)
					{
						statement.Type = StatementType.Lambda;
						statement.Environment = environment.GetCopy();
						return statement;
					}
				}
			}

			var proc = Eval(environment, statement.List[0]);
			var @params = statement.List.Skip(1).Select(e => Eval(environment, e)).ToList();
			if ( proc == null )
				return null;
			if ( proc.Type == StatementType.Proc )
			{
				return proc.Func(new Statement(@params));
			}
			if ( proc.Type == StatementType.Lambda )
			{
				return Eval(new LispEnvironment(proc.Environment, proc.List[1].List, @params), proc.List[2]);
			}

			return null;
		}
	}
}
