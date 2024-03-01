using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Add
{
    internal class AddOrUpdateQueryParameterTests
    {
        [Test]
        public void AddOrUpdateQueryParameter_NullUri_ThrowsArgumentNullException()
        {
            Uri uri = null;
            Assert.Throws<ArgumentNullException>(() => uri.AddOrUpdateQueryParameter("key", "value"));
        }

        [Test]
        public void AddOrUpdateQueryParameter_NullOrEmptyKey_ThrowsArgumentException()
        {
            Uri uri = new Uri("https://www.example.com");
            Assert.Throws<ArgumentException>(() => uri.AddOrUpdateQueryParameter(null, "value"));
            Assert.Throws<ArgumentException>(() => uri.AddOrUpdateQueryParameter("", "value"));
            Assert.Throws<ArgumentException>(() => uri.AddOrUpdateQueryParameter(" ", "value"));
        }

        [Test]
        public void AddOrUpdateQueryParameter_ValidUri_AddsNewParameter()
        {
            Uri uri = new Uri("https://www.example.com");
            Uri newUri = uri.AddOrUpdateQueryParameter("key", "value");
            Assert.AreEqual("https://www.example.com/?key=value", newUri.ToString());
        }

        [Test]
        public void AddOrUpdateQueryParameter_ValidUriWithExistingParameter_UpdatesParameter()
        {
            Uri uri = new Uri("https://www.example.com/?key1=value1");
            Uri newUri = uri.AddOrUpdateQueryParameter("key1", "newvalue");
            Assert.AreEqual("https://www.example.com/?key1=newvalue", newUri.ToString());
        }

        [Test]
        public void AddOrUpdateQueryParameter_ValidUriWithExistingParameters_AddsNewParameter()
        {
            Uri uri = new Uri("https://www.example.com/?key1=value1");
            Uri newUri = uri.AddOrUpdateQueryParameter("key2", "value2");
            Assert.AreEqual("https://www.example.com/?key1=value1&key2=value2", newUri.ToString());
        }

        [Test]
        public void AddOrUpdateQueryParameter_ValidUriWithQueryAndFragment_AddsParameter()
        {
            Uri uri = new Uri("https://www.example.com/path?param=value#fragment");
            Uri newUri = uri.AddOrUpdateQueryParameter("key", "value");
            Assert.AreEqual("https://www.example.com/path?param=value&key=value#fragment", newUri.ToString());
        }
    }
}
 
