using Core.QuickExtend.Extensions.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DictionaryExtensions
{
    internal class ToTests
    {
        [Test]
        public void ToFormattedString_NonEmptyDictionary_ReturnsFormattedString()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };

            // Act
            var formattedString = dictionary.ToFormattedString();

            // Assert
            Assert.AreEqual("{1: One, 2: Two, 3: Three}", formattedString);
        }

        [Test]
        public void ToFormattedString_EmptyDictionary_ReturnsEmptyBraces()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>();

            // Act
            var formattedString = dictionary.ToFormattedString();

            // Assert
            Assert.AreEqual("{}", formattedString);
        }

        [Test]
        public void ToConcurrentDictionary_ConvertsToConcurrentDictionary_ReturnsValidConcurrentDictionary()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };

            // Act
            var result = dictionary.ToConcurrentDictionary();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(dictionary.Count, result.Count);
            foreach (var kvp in dictionary)
            {
                Assert.IsTrue(result.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, result[kvp.Key]);
            }
        }
    }
}
