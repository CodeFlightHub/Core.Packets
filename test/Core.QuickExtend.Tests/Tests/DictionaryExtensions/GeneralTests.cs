using Core.QuickExtend.Extensions.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DictionaryExtensions
{
    internal class GeneralTests
    {

        [Test]
        public void AddOrUpdate_ExistingKey_UpdateValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" } };

            // Act
            dictionary.AddOrUpdate(1, "Updated One");

            // Assert
            Assert.AreEqual("Updated One", dictionary[1]);
        }

        [Test]
        public void AddOrUpdate_NewKey_AddValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>();

            // Act
            dictionary.AddOrUpdate(1, "One");

            // Assert
            Assert.AreEqual("One", dictionary[1]);
        }

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
        public void ContainsKeyIgnoreCase_CaseInsensitiveKeyExists_ReturnsTrue()
        {
            // Arrange
            var dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) { { "One", 1 } };

            // Act
            var result = dictionary.ContainsKeyIgnoreCase("One");

            // Assert
            Assert.IsTrue(result);
        }


        [Test]
        public void ContainsKeyIgnoreCase_CaseSensitiveKeyExists_ReturnsTrue()
        {
            // Arrange
            var dictionary = new Dictionary<string, int> { { "One", 1 } };

            // Act
            var result = dictionary.ContainsKeyIgnoreCase("one");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Merge_SourceDictionary_MergedIntoDestination()
        {
            // Arrange
            var destination = new Dictionary<int, string> { { 1, "One" } };
            var source = new Dictionary<int, string> { { 2, "Two" } };

            // Act
            destination.Merge(source);

            // Assert
            Assert.AreEqual("Two", destination[2]);
        }

        [Test]
        public void Intersect_BothDictionariesHaveCommonKeys_ReturnsCommonKeyValuePairs()
        {
            // Arrange
            var first = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" } };
            var second = new Dictionary<int, string> { { 2, "Two" }, { 3, "Three" } };

            // Act
            var result = first.Intersect(second);

            // Assert
            CollectionAssert.AreEquivalent(new Dictionary<int, string> { { 2, "Two" } }, result);
        }

        [Test]
        public void Subtract_SecondDictionaryKeysExistInFirst_RemovesCommonKeyValuePairs()
        {
            // Arrange
            var first = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" } };
            var second = new Dictionary<int, string> { { 2, "Two" }, { 3, "Three" } };

            // Act
            var result = first.Subtract(second);

            // Assert
            CollectionAssert.AreEquivalent(new Dictionary<int, string> { { 1, "One" } }, result);
        }

        [Test]
        public void ValuesEquals_ValueExistsInDictionary_ReturnsKeysWithSpecifiedValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "One" } };

            // Act
            var result = dictionary.ValuesEquals("One");

            // Assert
            CollectionAssert.AreEquivalent(new List<int> { 1, 3 }, result);
        }

        [Test]
        public void OrderByValue_AscendingSort_ReturnsSortedDictionary()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" }, { 3, "Three" }, { 2, "Two" } };

            // Act
            var result = dictionary.OrderByValue();

            // Assert
            CollectionAssert.AreEqual(new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } }, result);
        }

        [Test]
        public void OrderByValue_DescendingSort_ReturnsSortedDictionary()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" }, { 3, "Three" }, { 2, "Two" } };

            // Act
            var result = dictionary.OrderByValue(false);

            // Assert
            CollectionAssert.AreEqual(new Dictionary<int, string> { { 3, "Three" }, { 2, "Two" }, { 1, "One" } }, result);
        }

        [Test]
        public void KeyDifference_WithDifferentKeys_ReturnsKeysNotPresentInSecondDictionary()
        {
            // Arrange
            var first = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
            var second = new Dictionary<int, string> { { 2, "Two" }, { 3, "Three" } };

            // Act
            var result = first.KeyDifference(second);

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.Contains(1));
        }

        [Test]
        public void ValueDifference_WithDifferentValues_ReturnsValuesNotPresentInSecondDictionary()
        {
            // Arrange
            var first = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
            var second = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" } };

            // Act
            var result = first.ValueDifference(second);

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.Contains("Three"));
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

        [Test]
        public void Shuffle_ShufflesDictionary_ReturnsDictionaryWithSameElements()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };

            // Act
            var shuffledDict = dictionary.Shuffle();

            // Assert
            Assert.AreEqual(dictionary.Count, shuffledDict.Count);
            CollectionAssert.AreEquivalent(dictionary.Keys, shuffledDict.Keys);
            CollectionAssert.AreEquivalent(dictionary.Values, shuffledDict.Values);
        }

        [Test]
        public void ForEach_PerformsActionOnEachKeyValuePair_ActionExecutedForEachKeyValuePair()
        {
            // Arrange
            var dictionary = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
            var keyList = new List<int>();
            var valueList = new List<string>();

            // Act
            dictionary.ForEach((k, v) =>
            {
                keyList.Add(k);
                valueList.Add(v);
            });

            // Assert
            CollectionAssert.AreEquivalent(dictionary.Keys, keyList);
            CollectionAssert.AreEquivalent(dictionary.Values, valueList);
        }

    }
}
