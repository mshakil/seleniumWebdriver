using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace LearnSeleniumWebdriver
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //IWebDriver driver = new FirefoxDriver();
            IWebDriver chromeDriver = new ChromeDriver(@"C:\Automation\prereqs\chromedriver");
            chromeDriver.Navigate().GoToUrl("http://www.google.com.pk");
            //MainCall.WebDriver.Navigate().GoToUrl("http://www.google.com.pk");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //if (MainCall.WebDriver == null)
            //MainCall.InitializeDriver(TestContext);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            MainCall.DisposeDriver();
        }

        //public TestContext TestContext { get { return _testContext; } set { _testContext = value; } }
        //private TestContext _testContext;
    }


}
