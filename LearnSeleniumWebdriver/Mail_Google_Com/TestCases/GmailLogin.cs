using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;



namespace LearnSeleniumWebdriver.Mail_Google_Com.TestCases
{
    public partial class Gmail
    {
        [TestMethod]
        public void LoginToGmailAccout()
        {
            test = _extent.CreateTest("MyFirstTest", "Sample description");

            // log(Status, details)
            test.Log(Status.Info, "This step shows usage of log(status, details)");

            // info(details)
            test.Info("This step shows usage of info(details)");

            // log with snapshot
            test.Fail("details", MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());

            // calling flush writes everything to the log file
            _extent.Flush();
            //var url = "http://mail.google.com";
            //var email = "****";
            //var password = "****";

            //MainCall.LoginPage.NavigteToGmail(url);
            //MainCall.LoginPage.EnterEmailAddress(email);
            //MainCall.LoginPage.ClickNextButton();
            //MainCall.LoginPage.EnterPassword(password);
            //MainCall.LoginPage.ClickLoginButton();
        }
    }
}
