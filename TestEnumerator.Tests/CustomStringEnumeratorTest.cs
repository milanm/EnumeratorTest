using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestEnumerator.Tests
{
    [TestClass]
    public class CustomStringEnumeratorTest
    {
        [TestMethod]
        public void WhenTwoWordsWithCapitalsLetterSouldReturnTwo()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "" };

            var config = new EnumeratorConfig
            {
                MinLength = 3,
                MaxLength = 10,
                StartWithCapitalLetter = true
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(2, count);           
        }

        [TestMethod]
        public void WhenTwoWordsWithCapitalLettersNoMinLengthSouldReturnThree()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "" };

            var config = new EnumeratorConfig
            {
                MinLength = -1,
                MaxLength = 10,
                StartWithCapitalLetter = true
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void WhenTwoWordsWithCapitalLetterNoMinLengthWithNullSouldReturnFour()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "", "test", null};

            var config = new EnumeratorConfig
            {
                MinLength = -1,
                MaxLength = 10,
                StartWithCapitalLetter = true
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(4, count);
        }


        [TestMethod]
        public void WhenOneWordsWithDigitSouldReturnOne()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "", "test", "123" };

            var config = new EnumeratorConfig
            {
                MinLength = 1,
                MaxLength = 10,
                StartWithDigit = true
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void WhenOneWordsWithDigitNotInLengthSouldReturnZero()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "", "test", "123" };

            var config = new EnumeratorConfig
            {
                MinLength = 1,
                MaxLength = 2,
                StartWithDigit = true
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void WhenOneWordWithinLengthSouldReturnOne()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "test", "parabolic" };

            var config = new EnumeratorConfig
            {
                MinLength = 6,
                MaxLength = 10
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void WhenOneWordWithinLengthAndNullSouldReturnOne()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "test", "parabolic", null };

            var config = new EnumeratorConfig
            {
                MinLength = 0,
                MaxLength = 5
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void WhenOneWordWithinLengthAndCapitalLetterAndNullSouldReturnOne()
        {
            // Arrange
            var collection = new [] { "Milan", "Milanovic", "test", "parabolic", null };

            var config = new EnumeratorConfig
            {
                MaxLength = 5,
                StartWithCapitalLetter = true,
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void WhenTwoWordsWithCapitalAndOneWithDigitAndInLengthSouldReturnZero()
        {
            // Arrange
            var collection = new[] { "Milan", "Milanovic", "", "test", "123" };

            var config = new EnumeratorConfig
            {
                MinLength = 1,
                MaxLength = 10,
                StartWithDigit = true,
                StartWithCapitalLetter = true
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(0, count);
        }


        [TestMethod]
        public void WhenTwoWordsWithDigitAndInLengthSouldReturnTwo()
        {
            // Arrange
            var collection = new[] { "Milan", "Milanovic", "", "test", "123", "5555", null };

            var config = new EnumeratorConfig
            {
                MinLength = 3,
                MaxLength = 5,
                StartWithDigit = true,
            };

            // Act
            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            // Assert
            Assert.AreEqual(2, count);
        }
    }
}
