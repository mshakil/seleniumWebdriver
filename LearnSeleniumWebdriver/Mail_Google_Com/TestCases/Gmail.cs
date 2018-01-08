using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;



namespace LearnSeleniumWebdriver.Mail_Google_Com.TestCases
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public partial class Gmail
    {
        public static string BuildVersion;
        public static string FailedReason;
        private Stopwatch _sw = null;
        public static ExtentReports _extent;
        public ExtentTest test;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BuildVersion = ConfigurationManager.AppSettings["Version"];
            //MainCall.LogEntry("Execution Started On Build", "ExecutionStarted", BuildVersion, null);

            var htmlReporter = new ExtentHtmlReporter(@"C:\Automation\Reports\AutomationReport.html");
            htmlReporter.Configuration().DocumentTitle = "My First Report";

            // make the charts visible on report open
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;

            // report title
            htmlReporter.Configuration().DocumentTitle = "aventstack - ExtentReports";
            // encoding, default = UTF-8
            htmlReporter.Configuration().Encoding = "UTF-8";

            // protocol (http, https)
            htmlReporter.Configuration().Protocol = Protocol.HTTPS;
            htmlReporter.Configuration().ReportName = "Build-1224";
            htmlReporter.Configuration().ChartLocation = ChartLocation.Bottom;
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().CSS = "css-string";
            htmlReporter.Configuration().JS = "js-string";

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            BuildVersion = ConfigurationManager.AppSettings["Version"];
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            _sw = new Stopwatch();
            _sw.Reset();
            FailedReason = string.Empty;

            if (MainCall.WebDriver == null)
                MainCall.InitializeDriver(TestContext);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            _sw.Stop();
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                try
                {
                    MainCall.TakeScreenShotByWebDriver(TestContext.TestName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
                finally
                {
                    MainCall.WebDriver.Quit();

                    MainCall.WebDriver = null;
                    MainCall.MakePageObjectesNull();
                    MainCall.InitializeDriver(TestContext);
                }
            }
        }

        public TestContext TestContext { get { return _testContext; } set { _testContext = value; } }
        private TestContext _testContext;
    }

}
