using System.Collections.Generic;
using static Program;
using static Program.OrderBy1;

namespace UnitTests
{
	public class CodinGameTests
	{
		[Theory]
		[InlineData(5, 6)]
		[InlineData(-2, -1)]
		public void TestGetNextNumber(int input, int result)
		{
			var actual = GetNextNumber(input);
			var expected = result;
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestQuerySyntax()
		{
			Assert.Equal(new List<string>() { "foo", "goo" }, FilterAndSort(new List<string>() { "foo", "bar", "goo", "onion" }, "oo"));
			Assert.Equal(new List<string>() { "aaa", "abc", "bca", "cba" }, FilterAndSort(new List<string>() { "abc", "bca", "cba", "aaa" }, "a"));
			Assert.Equal(new List<string>() { "integer", "pointer", "reference" }, FilterAndSort(new List<string>() { "pointer", "reference", "structure", "integer" }, "er"));
		}

		[Fact]
		public void TestMethodSyntax()
		{
			Assert.Equal(new List<string>() { "foo", "goo" }, FilterAndSort2(new List<string>() { "foo", "bar", "goo", "onion" }, "oo"));
			Assert.Equal(new List<string>() { "aaa", "abc", "bca", "cba" }, FilterAndSort2(new List<string>() { "abc", "bca", "cba", "aaa" }, "a"));
			Assert.Equal(new List<string>() { "integer", "pointer", "reference" }, FilterAndSort2(new List<string>() { "pointer", "reference", "structure", "integer" }, "er"));
		}

		[Fact]
		public void Test_GetFirstSingleLetterWord()
		{
			Assert.Equal("a", SingleValue.GetFirstSingleLetterWord(new List<string>() { "This", "is", "a", "test" }));
			Assert.Equal("I", SingleValue.GetFirstSingleLetterWord(new List<string>() { "I", "am", "not", "a", "crook" }));
			Assert.Equal("d", SingleValue.GetFirstSingleLetterWord(new List<string>() { "d", "e", "a", "d", "b", "e", "e", "f" }));
		}

		[Fact]
		public void Test_GetLastWordWithHerInIt()
		{
			Assert.Equal("her", SingleValue.GetLastWordWithHerInIt(new List<string>() { "Watching", "the", "weather", "together", "with", "her" }));
			Assert.Equal("watcher", SingleValue.GetLastWordWithHerInIt(new List<string>() { "Watching", "the", "watcher", "alone" }));
			Assert.Equal("where", SingleValue.GetLastWordWithHerInIt(new List<string>() { "where", "where", "where", "where" }));
		}

		[Fact]
		public void Test_GetFifthWordIfItExists()
		{
			Assert.Equal("with", SingleValue.GetFifthWordIfItExists(new List<string>() { "Watching", "the", "weather", "together", "with", "her" }));
			Assert.Null(SingleValue.GetFifthWordIfItExists(new List<string>() { "Watching", "the", "watcher", "alone" }));
			Assert.Null(SingleValue.GetFifthWordIfItExists(new List<string> { }));
		}

		[Fact]
		public void Test_GetLastWordIfAny()
		{
			Assert.Equal("her", SingleValue.GetLastWordIfAny(new List<string>() { "Watching", "the", "weather", "together", "with", "her" }));
			Assert.Equal("alone", SingleValue.GetLastWordIfAny(new List<string>() { "Watching", "the", "watcher", "alone" }));
			Assert.Null(SingleValue.GetLastWordIfAny(new List<string> { }));
		}

		[Fact]
		public void TestGetThirdFourthFifthItems()
		{
			Assert.Equal(new List<string>() { "the", "first", "test" }, GetThirdFourthFifthItems(new List<string>() { "This", "is", "the", "first", "test" }));
			Assert.Equal(new List<string>() { "Dave", "I", "can't" }, GetThirdFourthFifthItems(new List<string>() { "I'm", "sorry", "Dave", "I", "can't", "do", "that" }));
			Assert.Equal(new List<string>() { "be", "enough", "for" }, GetThirdFourthFifthItems(new List<string>() { "640K", "should", "be", "enough", "for", "anybody" }));
		}

		[Fact]
		public void Test_GetStartThroughEnd()
		{
			Assert.Equal(new List<string>() { "start", "is", "the" }, GetStartThroughEnd(new List<string>() { "This", "start", "is", "the", "end", "first", "test" }));
			Assert.Equal(new List<string>() { "start", "I'm", "sorry", "Dave" }, GetStartThroughEnd(new List<string>() { "start", "I'm", "sorry", "Dave", "end", "I", "can't", "do", "that" }));
			Assert.Equal(new List<string>() { "start" }, GetStartThroughEnd(new List<string>() { "640K", "should", "be", "start", "end", "enough", "for", "anybody" }));
		}

		[Fact]
		public void Test_GetDistinctShortWords()
		{
			Assert.Equal(new List<string>() { "see", "the", "for" }, GetDistinctShortWords(new List<string>() { "Can't", "see", "the", "forest", "for", "the", "trees" }));
			Assert.Equal(new List<string>() { "I'm", "I", "do" }, GetDistinctShortWords(new List<string>() { "I'm", "sorry", "Dave", "I", "can't", "do", "that" }));
			Assert.Equal(new List<string>() { "it", "was", "the", "of" }, GetDistinctShortWords(new List<string>() { "it", "was", "the", "best", "of", "times", "it", "was", "the", "worst", "of", "times" }));
		}

		[Fact]
		public void Test_SortNames()
		{
			var king = new Name("Martin", "Luther", "King");
			var bach = new Name("Johann", "Sebastian", "Bach");
			var mozart = new Name("Wolfgang", "Amadeus", "Mozart");
			var roosevelt = new Name("Franklin", "Delano", "Roosevelt");
			IEnumerable<Name> namesToBeSorted = new List<Name>() { king, bach, mozart, roosevelt };
			Assert.Equal(OrderBy1.SortNames(namesToBeSorted), new List<Name>() { roosevelt, mozart, king, bach });
		}

		[Fact]
		public void Test_SortNames2()
		{
			var bach = new Name("Johann", "Sebastian", "Bach");
			var king = new Name("Martin", "Luther", "King");
			var bjKing = new Name("Billie", "Jean", "King");
			var ImKing = new Name("Im", "The", "King");
			var roosevelt = new Name("Franklin", "Delano", "Roosevelt");
			IEnumerable<Name> namesToBeSorted = new List<Name>() { bach, king, bjKing, ImKing, roosevelt };
			Assert.Equal(ThenBy1.SortNames(namesToBeSorted), new List<Name>() { bach, bjKing, ImKing, king, roosevelt });

			var clinton = new Name("Hillary", "Rodham", "Clinton");
			var poeWrong = new Name("Edgar", "Ellen", "Poe");
			var poe = new Name("Edgar", "Allan", "Poe");
			var jfk = new Name("John", "Fitzgerald", "Kennedy");
			IEnumerable<Name> moreNamesToBeSorted = new List<Name>() { clinton, poeWrong, poe, jfk };
			Assert.Equal(ThenBy1.SortNames(moreNamesToBeSorted), new List<Name>() { clinton, jfk, poe, poeWrong });
		}

		[Fact]
		public void Test_NumberThatStartWith()
		{
			Assert.Equal(1, NumberThatStartWith(new List<string>() { "This", "is", "the", "first", "test" }, "is"));
			Assert.Equal(2, NumberThatStartWith(new List<string>() { "I'm", "sorry", "Dave", "I", "can't", "do", "that" }, "I"));
			Assert.Equal(3, NumberThatStartWith(new List<string>() { "She", "sells", "sea", "shells", "down", "by", "the", "sea", "shore" }, "se"));
		}

		[Fact]
		public void Test_LengthOfShortestWord()
		{
			Assert.Equal(2, LengthOfShortestWord(new List<string> { "This", "is", "the", "first", "test" }));
			Assert.Equal(1, LengthOfShortestWord(new List<string> { "I'm", "sorry", "Dave", "I", "can't", "do", "that" }));
			Assert.Equal(2, LengthOfShortestWord(new List<string> { "She", "sells", "sea", "shells", "down", "by", "the", "sea", "shore" }));
		}

		[Fact]
		public void Test_TotalCharactersInSequence()
		{
			Assert.Equal(18, TotalCharactersInSequence(new List<string> { "This", "is", "the", "first", "test" }));
			Assert.Equal(24, TotalCharactersInSequence(new List<string> { "I'm", "sorry", "Dave", "I", "can't", "do", "that" }));
			Assert.Equal(34, TotalCharactersInSequence(new List<string> { "She", "sells", "sea", "shells", "down", "by", "the", "sea", "shore" }));
		}

		[Fact]
		public void Test_DisplayStringsForNames()
		{
			Assert.Equal(new List<string> { "King, Martin", "Bach, Johann", "Mozart, Wolfgang", "Roosevelt, Franklin" }, DisplayStringsForNames(new List<Name> { new Name("Martin", "Luther", "King"), new Name("Johann", "Sebastian", "Bach"), new Name("Wolfgang", "Amadeus", "Mozart"), new Name("Franklin", "Delano", "Roosevelt") }));

			Assert.Equal(new List<string> { "Clinton, Hillary", "Poe, Edgar", "King, Billie", "Kennedy, John" }, DisplayStringsForNames(new List<Name> { new Name("Hillary", "Rodham", "Clinton"), new Name("Edgar", "Allan", "Poe"), new Name("Billie", "Jean", "King"), new Name("John", "Fitzgerald", "Kennedy") }));
		}

		[Fact]
		public void Test_TestForSquares()
		{
			Assert.True(TestForSquares(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 4, 9, 16, 25 }));
			Assert.False(TestForSquares(new List<int>() { 1, 2, 5 }, new List<int>() { 1, 4, 9 }));
			Assert.True(TestForSquares(new List<int>() { 12 }, new List<int>() { 144 }));
			Assert.False(TestForSquares(new List<int>() { 1, 5, 3 }, new List<int>() { 1, 25, 9, 9 }));
			Assert.True(TestForSquares(new List<int>() { }, new List<int>() { }));
		}

		[Fact]
		public void Test_GetTheLastWord()
		{
			Assert.Equal("The last word is we", GetTheLastWord(new List<string>() { "he", "she", "it", "we", "you", "they" }));
			Assert.Null(GetTheLastWord(new List<string>() { "hop", "top", "stop", "cop", "lop", "chop" }));
			Assert.Equal("The last word is incredible", GetTheLastWord(new List<string>() { "elastic", "elaborate", "elephant", "iris", "ibis", "incredible" }));
			Assert.Null(GetTheLastWord(new List<string>() { }));
		}
	}
}