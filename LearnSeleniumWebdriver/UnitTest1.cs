using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnSeleniumWebdriver
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainCall.WebDriver.Navigate().GoToUrl("http://www.google.com.pk");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            if (MainCall.WebDriver == null)
                MainCall.InitializeDriver(TestContext);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            MainCall.DisposeDriver();
        }

        public TestContext TestContext { get { return _testContext; } set { _testContext = value; } }
        private TestContext _testContext;

    }


}
