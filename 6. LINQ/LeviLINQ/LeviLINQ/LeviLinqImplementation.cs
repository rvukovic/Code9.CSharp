using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeviLINQ
{
	public static class LeviLinqImplementation
	{
		public static IEnumerable<TSource> LeviWhere<TSource>(
			this IEnumerable<TSource> source,
			Func<TSource, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return LeviWhereImpl(source, predicate);
		}

		private static IEnumerable<TSource> LeviWhereImpl<TSource>(
			this IEnumerable<TSource> source,
			Func<TSource, bool> predicate)
		{
			foreach (TSource item in source)
			{
				if (predicate(item))
				{
					yield return item;
				}
			}
		}


		//////////////////////////////////////////////////////////

		public static IEnumerable<TResult> LeviSelect<TSource, TResult>(
			this IEnumerable<TSource> source,
			Func<TSource, TResult> selector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			return LeviSelectImpl(source, selector);
		}

		private static IEnumerable<TResult> LeviSelectImpl<TSource, TResult>(
			this IEnumerable<TSource> source,
			Func<TSource, TResult> selector)
		{
			foreach (TSource item in source)
			{
				yield return selector(item);
			}
		}

	}
}
