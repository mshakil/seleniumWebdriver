using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace LearnSeleniumWebdriver.Mail_Google_Com.TestCases
{
    public partial class Gmail
    {
        [TestMethod]
        public void LoginToGmailAccout()
        {
            var url = "http://mail.google.com";
            var email = "mshakil74@gmail.com";
            var password = "M.SHAKIL26472";

            MainCall.LoginPage.NavigteToGmail(url);
            MainCall.LoginPage.EnterEmailAddress(email);
            MainCall.LoginPage.ClickNextButton();
            MainCall.LoginPage.EnterPassword(password);
            MainCall.LoginPage.ClickLoginButton();
        }
    }
}
