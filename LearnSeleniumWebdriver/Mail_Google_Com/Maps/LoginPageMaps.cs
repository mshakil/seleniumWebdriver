using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LearnSeleniumWebdriver.Mail_Google_Com.Maps
{
    public partial class LoginPage
    {
        private static IWebDriver _webDriver;
        public LoginPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        private readonly By _gmailEmailTxtbox = By.Id("Email");
        private readonly By _gmailNextButton = By.Id("next");
        private readonly By _gmailPasswordTxtbox = By.Id("Passwd");
        private readonly By _gmailLoginButton = By.Id("signIn");
    }
}