using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Add
{
    internal class AppendPathTests
    {
        [Test]
        public void AppendPath_NullUri_ThrowsArgumentNullException()
        {
            Uri uri = null;
            Assert.Throws<ArgumentNullException>(() => uri.AppendPath("newpath"));
        }

        [Test]
        public void AppendPath_NullOrEmptyNewPath_ThrowsArgumentException()
        {
            Uri uri = new Uri("https://www.example.com");
            Assert.Throws<ArgumentException>(() => uri.AppendPath(null));
            Assert.Throws<ArgumentException>(() => uri.AppendPath(""));
            Assert.Throws<ArgumentException>(() => uri.AppendPath(" "));
        }

        [Test]
        public void AppendPath_ValidUriAndNewPath_ReturnsUriWithAppendedPath()
        {
            Uri uri = new Uri("https://www.example.com");
            Uri newUri = uri.AppendPath("newpath");
            Assert.AreEqual("https://www.example.com/newpath", newUri.ToString());
        }

        [Test]
        public void AppendPath_UriWithPathAndNewPath_ReturnsUriWithAppendedPath()
        {
            Uri uri = new Uri("https://www.example.com/existingpath");
            Uri newUri = uri.AppendPath("newpath");
            Assert.AreEqual("https://www.example.com/existingpath/newpath", newUri.ToString());
        }

        [Test]
        public void AppendPath_UriWithTrailingSlashAndNewPath_ReturnsUriWithAppendedPath()
        {
            Uri uri = new Uri("https://www.example.com/");
            Uri newUri = uri.AppendPath("newpath");
            Assert.AreEqual("https://www.example.com/newpath", newUri.ToString());
        }

        [Test]
        public void AppendPath_UriWithQueryAndNewPath_ReturnsUriWithAppendedPath()
        {
            Uri uri = new Uri("https://www.example.com/path?param=value");
            Uri newUri = uri.AppendPath("newpath");
            Assert.AreEqual("https://www.example.com/path/newpath?param=value", newUri.ToString());
        }

        [Test]
        public void AppendPath_UriWithFragmentAndNewPath_ReturnsUriWithAppendedPath()
        {
            Uri uri = new Uri("https://www.example.com/path#fragment");
            Uri newUri = uri.AppendPath("newpath");
            Assert.AreEqual("https://www.example.com/path/newpath#fragment", newUri.ToString());
        }
    }
}
