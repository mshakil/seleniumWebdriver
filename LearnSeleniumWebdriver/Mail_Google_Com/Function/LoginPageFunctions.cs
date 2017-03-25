using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace LearnSeleniumWebdriver.Mail_Google_Com.Maps
{
    public partial class LoginPage
    {
        public void HelloWorld()
        {
            Console.WriteLine("Hello!");
        }

        public void NavigteToGmail(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public void EnterEmailAddress(string email)
        {
            var emailtxt = _webDriver.FindElement(_gmailEmailTxtbox);
            Playback.Wait(1000);
            emailtxt.SendKeys(email);
            Playback.Wait(2000);
        }

        public void ClickNextButton()
        {
            var nextBtn = _webDriver.FindElement(_gmailNextButton);
            Playback.Wait(1000);
            nextBtn.Click();
            Playback.Wait(5000);
        }

        public void EnterPassword(string password)
        {
            var passwordtxt = _webDriver.FindElement(_gmailPasswordTxtbox);
            Playback.Wait(1000);
            passwordtxt.SendKeys(password);
            Playback.Wait(2000);
        }

        public void ClickLoginButton()
        {
            var nextBtn = _webDriver.FindElement(_gmailLoginButton);
            Playback.Wait(1000);
            nextBtn.Click();
            Playback.Wait(5000);
        }
    }
}
