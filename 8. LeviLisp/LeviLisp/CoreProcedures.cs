using System;
using System.Linq;

namespace LeviLisp
{
	public static class CoreProcedures
	{
		public static Statement Add(Statement statement)
		{
			var res = statement.List.Select(n => Double.Parse(n.Value)).Sum();
			return new Statement(StatementType.Number, res.ToString());
		}
	}
}