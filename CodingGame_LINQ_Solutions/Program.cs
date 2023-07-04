public class Program
{
	private static void Main(string[] args)
	{
	}

	// LambdaExpressions
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/lambda-expressions
	public static Func<int, int> GetNextNumber = x => x + 1;

	// QuerySyntax
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/linq-query-syntax
	public static IEnumerable<string> FilterAndSort(IEnumerable<string> inValues, string pattern)
	{
		return from value in inValues
			   where value.Contains(pattern)
			   orderby value
			   select value;
	}

	// MethodSyntax
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/linq-method-syntax
	public static IEnumerable<string> FilterAndSort2(IEnumerable<string> inValues, string pattern)
	{
		return inValues
			.Where(v => v.Contains(pattern))
			.OrderBy(v => v);
	}

	// SingleValue
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/single-element-exercise
	public static class SingleValue
	{
		public static string GetFirstSingleLetterWord(IEnumerable<string> words)
		{
			return words.Where(w => w.Length == 1).First();
		}

		public static string GetLastWordWithHerInIt(IEnumerable<string> words)
		{
			return words.Where(w => w.Contains("her")).Last();
		}

		public static string GetFifthWordIfItExists(IEnumerable<string> words)
		{
			return words.ElementAtOrDefault(4);
		}

		public static string GetLastWordIfAny(IEnumerable<string> words)
		{
			return words.LastOrDefault();
		}
	}

	// MultipleValue
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/skip-and-take
	public static IEnumerable<string> GetThirdFourthFifthItems(IEnumerable<string> words)
	{
		return words.Skip(2).Take(3);
	}

	public static IEnumerable<string> GetStartThroughEnd(IEnumerable<string> words)
	{
		return words.SkipWhile(w => w != "start").TakeWhile(w => w != "end");
	}

	public static IEnumerable<string> GetDistinctShortWords(IEnumerable<string> words)
	{
		return words.Where(w => w.Length < 4).Distinct();
	}

	// ChangeOrder - see below!

	// Count
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/count
	public static int NumberThatStartWith(IEnumerable<string> words, string startString)
	{
		return words.Count(s => s.StartsWith(startString));
	}

	// MinMax
	public static int LengthOfShortestWord(IEnumerable<string> words)
	{
		return words.Min(_ => _.Length);
	}

	// Aggregate
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/aggregate
	public static int TotalCharactersInSequence(IEnumerable<string> words)
	{
		return words.Aggregate(0, (a, b) => a + b.Length);
	}

	// CalculateSequence
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/select
	public static IEnumerable<string> DisplayStringsForNames(IEnumerable<Name> names)
	{
		return names.Select(n => $"{n.Last}, {n.First}");
	}

	// Exercise1
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/combined-exercise-1
	public static bool TestForSquares(IEnumerable<int> numbers, IEnumerable<int> squares)
	{
		return numbers.Select(n => n * n).SequenceEqual(squares);
	}

	// Exercise2
	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/combined-exercise-2
	public static string GetTheLastWord(IEnumerable<string> words)
	{
		return words.Where(w => w.Contains('e')).OrderBy(w => w).Select(w => $"The last word is {w}").LastOrDefault();
	}


	// ChangeOrder
	public class Name
	{
		public string First { get; }
		public string Middle { get; }
		public string Last { get; }
		public Name(string first, string middle, string last)
		{
			First = first; Middle = middle; Last = last;
		}
	}

	// https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/reverse-and-orderby
	public static class OrderBy1
	{
		public static IEnumerable<Name> SortNames(IEnumerable<Name> names)
		{
			return names.OrderByDescending(n => n.Last);
		}

		public static class ThenBy1
		{
			public static IEnumerable<Name> SortNames(IEnumerable<Name> names)
			{
				return names.OrderBy(n => n.Last).ThenBy(n => n.First).ThenBy(n => n.Middle);
			}
		}
	}
}

