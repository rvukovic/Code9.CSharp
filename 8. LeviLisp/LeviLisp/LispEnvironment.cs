using System;
using System.Collections.Generic;

namespace LeviLisp
{
	public class LispEnvironment
	{
		public const string True = "#T";
		public const string False = "#F";
		public const string Null = "NIL";

		public LispEnvironment()
		{
			_env = new Dictionary<string, Statement>(StringComparer.OrdinalIgnoreCase);
			InitializaDefault();
		}

		private void InitializaDefault()
		{
			_env[True]		= new Statement(StatementType.Symbol,True);
			_env[False]		= new Statement(StatementType.Symbol, False);

			_env["add"]		= new Statement(CoreProcedures.Add);
			_env["+"]		= new Statement(CoreProcedures.Add);

			_env["="]		= new Statement(e => e.List[0] == e.List[1]	? _env[True] : _env[False]);
			_env["!="]		= new Statement(e => e.List[0] != e.List[1]	? _env[True] : _env[False]);
			_env[">"]		= new Statement(e => e.List[0] >  e.List[1]	? _env[True] : _env[False]);
			_env["<"]		= new Statement(e => e.List[0] <  e.List[1]	? _env[True] : _env[False]);
		}

		public LispEnvironment(LispEnvironment parentEnvironment, IList<Statement> paramDefinitions, IList<Statement> paramValues)
			: this()
		{
			_parentEnvironment = parentEnvironment;
			var count = paramDefinitions.Count;
			if(count != paramValues.Count)
				throw new ArgumentOutOfRangeException(string.Format("Invalid number of arguments. Supplied {0}, needed {1}", paramValues.Count, count));
			for (int i = 0; i < count; i++)
			{
				SetElement(paramDefinitions[i].Value, paramValues[i]);
			}
		}

		private Dictionary<string, Statement> _env;
		private LispEnvironment _parentEnvironment = null;

		public Statement GetElement(string elementName)
		{
			if (_env.ContainsKey(elementName))
				return _env[elementName];

			if (_parentEnvironment == null)
				return null;

			return _parentEnvironment.GetElement(elementName);
		}

		public void SetElement(string elementName, Statement statement)
		{
			_env[elementName] = statement;
		}

		public LispEnvironment GetCopy()
		{
			var newEnv = new LispEnvironment();
			if(_parentEnvironment != null)
			{
				newEnv._parentEnvironment = _parentEnvironment.GetCopy();
			}
			newEnv._env = new Dictionary<string, Statement>(_env);

			return newEnv;
		}
	}
}