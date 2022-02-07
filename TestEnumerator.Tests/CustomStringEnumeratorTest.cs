using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestEnumerator.Tests
{
    [TestClass]
    public class CustomStringEnumeratorTest
    {
        [TestMethod]
        public void WhenTwoWordsWithCapitalsLetterSouldReturnTwo()
        {
            var collection = new string[] { "Milan", "Milanovic", "" };


            var config = new EnumeratorConfig
            {
                MinLength = 3,
                MaxLength = 10,
                StartWithCapitalLetter = true
            };

            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            Assert.AreEqual(2, count);           
        }

        [TestMethod]
        public void WhenTwoWordsWithCapitalLettersNoMinLengthSouldReturnThree()
        {
            var collection = new string[] { "Milan", "Milanovic", "" };

            var config = new EnumeratorConfig
            {
                MinLength = -1,
                MaxLength = 10,
                StartWithCapitalLetter = true
            };

            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void WhenTwoWordsWithCapitalLetterNoMinLengthWithNullSouldReturnFour()
        {
            var collection = new string[] { "Milan", "Milanovic", "", "test", null};

            var config = new EnumeratorConfig
            {
                MinLength = -1,
                MaxLength = 10,
                StartWithCapitalLetter = true
            };

            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            Assert.AreEqual(4, count);
        }


        [TestMethod]
        public void WhenOneWordsWithDigitSouldReturnOne()
        {
            var collection = new string[] { "Milan", "Milanovic", "", "test", "123" };

            var config = new EnumeratorConfig
            {
                MinLength = 1,
                MaxLength = 10,
                StartWithCapitalLetter = false,
                StartWithDigit = true
            };

            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void WhenOneWordWithinLengthWithDigitSouldReturnOne()
        {
            var collection = new string[] { "Milan", "Milanovic", "test", "parabolic" };

            var config = new EnumeratorConfig
            {
                MinLength = 6,
                MaxLength = 10,
                StartWithCapitalLetter = false,
                StartWithDigit = false
            };

            var enumerator = new CustomStringEnumerator(collection, config);
            var count = enumerator.ToList().Count;

            Assert.AreEqual(1, count);
        }

    }
}