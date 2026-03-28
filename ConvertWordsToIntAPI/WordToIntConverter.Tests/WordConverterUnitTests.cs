using NUnit.Framework;
using WordsToIntConverter.Core;

namespace WordToIntConverter.Tests
{
    [TestFixture]
    public class WordConverterTests
    {
        private IConvertWordsToInt _convertWordsToInt;

        [SetUp]
        public void SetUp()
        {
            _convertWordsToInt = new WordsToIntConverter.Core.ConvertWordsToInt();
        }

        [TestCase("Ten", 10)]
        [TestCase("fifty one", 51)]
        [TestCase("three hundred fifty one", 351)]
        [TestCase("Four Thousand Three Hundred Fifty One", 4351)]
        [TestCase("Fifty Three Thousand", 53000)]
        //Additional Test Cases
        [TestCase("fifty-one", 51)]
        [TestCase("three hundred and fifty one", 351)]
        [TestCase("zero", 0)]
        [TestCase("one million", 1000000)]
        //Invalid input test cases
        //[TestCase("apple", Assert.Throws<ArgumentException>)]
        public void ConvertWordsToInt_WhenCalled_ReturnsCorrectInteger(string input, int expected)
        {
            // Act
            int result = _convertWordsToInt.ConvertWordsToIntMethod(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected), $"Failed for input: {input}");
        }

        [TestCase("")]
        public void Convert_InvalidInput_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => _convertWordsToInt.ConvertWordsToIntMethod(input));
        }
    }
}
