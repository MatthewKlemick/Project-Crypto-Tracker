using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Crypto_Tracker_UITest
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void IsRefreshButonload()
        {
            app.Screenshot("Crypto Tracker Page");

            AppResult[] results = app.WaitForElement("RefButton");

            Assert.IsTrue(results.Any());
        }
    }
}
