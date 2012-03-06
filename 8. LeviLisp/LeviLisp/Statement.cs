using System;
using System.Collections.Generic;

namespace LeviLisp
{
	public enum StatementType
	{
		Number,
		Symbol,
		List,
		Proc,
		Lambda
	}

	public class Statement : IComparable<Statement>
	{
		public Statement(StatementType type, string value)
		{
			Type = type;
			Value = value;
		}

		public StatementType Type { get; set; }
		public string Value { get; set; }
		public List<Statement> List { get; set; }
		public Func<Statement, Statement> Func { get; set; }
		public LispEnvironment Environment { get; set; }

		public Statement( List<Statement> elementList)
		{
			Type = StatementType.List;
			List = elementList;
		}

		public Statement(Func<Statement, Statement> func)
		{
			Type = StatementType.Proc;
			Func = func;
		}

		public int CompareTo(Statement other)
		{
			if (Type == StatementType.Number)
			{
				var a = double.Parse(Value);
				var b = double.Parse(other.Value);
				return a.CompareTo(b);
			}
			if (Type == StatementType.Symbol)
			{
				return Value.CompareTo(other.Value);
			}

			throw new NotImplementedException();
		}

		public override string ToString()
		{
			switch (Type)
			{
			   case StatementType.Symbol:
			   case StatementType.Number:
				   return Value;
				case StatementType.List:
				   return "(" + string.Join(" ", List) + ")";
				default:
					return string.Format("{0}: {1}", Type, Value);
			}
		}

		public bool Equals(Statement other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Type, Type) && Equals(other.Value, Value) && Equals(other.List, List);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Statement)) return false;
			return Equals((Statement) obj);
		}

		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			unchecked
			{
				int result = Type.GetHashCode();
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				result = (result*397) ^ (List != null ? List.GetHashCode() : 0);
				return result;
			}
		}

		public static bool operator ==(Statement left, Statement right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Statement left, Statement right)
		{
			return !Equals(left, right);
		}

		public static bool operator >(Statement left, Statement right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator <(Statement left, Statement right)
		{
			return left.CompareTo(right) < 0;
		}
	}
}