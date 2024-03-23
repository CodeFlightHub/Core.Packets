using Core.QuickExtend.Extensions.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DictionaryExtentions
{
    internal class AddTests
    {

        [Test]
        public void GetOrCreate_WhenKeyExists_ShouldReturnExistingValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

            // Act
            string value = dictionary.GetOrCreate(1, () => "NewValue");

            // Assert
            Assert.AreEqual("One", value);
        }

        [Test]
        public void GetOrCreate_WhenKeyDoesNotExist_ShouldCreateNewValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

            // Act
            string value = dictionary.GetOrCreate(3, () => "NewValue");

            // Assert
            Assert.AreEqual("NewValue", value);
            Assert.IsTrue(dictionary.ContainsKey(3));
        }

        [Test]
        public void GetValueOrDefault_WhenKeyExists_ShouldReturnValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

            // Act
            string value = dictionary.GetValueOrDefault(1);

            // Assert
            Assert.AreEqual("One", value);
        }

        [Test]
        public void GetValueOrDefault_WhenKeyDoesNotExist_ShouldReturnDefaultValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

            // Act
            string value = dictionary.GetValueOrDefault(3);

            // Assert
            Assert.IsNull(value);
        }

        [Test]
        public void GetOrAddDefault_WhenKeyExists_ShouldReturnValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

            // Act
            string value = dictionary.GetOrAddDefault(1, "DefaultValue");

            // Assert
            Assert.AreEqual("One", value);
        }

        [Test]
        public void GetOrAddDefault_WhenKeyDoesNotExist_ShouldAddDefaultValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" }
        };

            // Act
            string value = dictionary.GetOrAddDefault(3, "DefaultValue");

            // Assert
            Assert.AreEqual("DefaultValue", value);
            Assert.IsTrue(dictionary.ContainsKey(3));
        }

        [Test]
        public void GetKeysByValue_ShouldReturnKeysAssociatedWithValue()
        {
            // Arrange
            var dictionary = new Dictionary<int, string>
    {
        { 1, "One" },
        { 2, "Two" },
        { 3, "One" },
        { 4, "Three" }
    };

            // Act
            var keys = DictionaryExtensions.GetKeysByValue(dictionary, "One").ToList(); 

            // Assert
            Assert.AreEqual(2, keys.Count());
            Assert.Contains(1, keys);
            Assert.Contains(3, keys);
        }






    }
}
