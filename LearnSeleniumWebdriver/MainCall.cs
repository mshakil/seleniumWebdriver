using System;
using OpenQA.Selenium.Support.Extensions;
using Selenium;
using System.Drawing;
using System.Net;
using System.Collections.Generic;
using LearnSeleniumWebdriver.Mail_Google_Com.Maps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace LearnSeleniumWebdriver
{
    class MainCall
    {
        public static IWebDriver WebDriver { get; set; }
        public static LoginPage LoginPage
        {
            get
            {
                if (_loginPage == null)
                    _loginPage = new LoginPage(WebDriver);
                return _loginPage;

            }
            set { _loginPage = value; }
        }
        private static LoginPage _loginPage;

        public static void MakePageObjectesNull()
        {
            _loginPage = null;
        }

        public static void DisposeDriver()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
            WebDriver = null;
        }

        private static readonly bool IsChromeDebuging = Convert.ToBoolean(ConfigurationManager.AppSettings["UseChromeDebugging"]);
        public static void InitializeDriver(TestContext t)
        {
            if (WebDriver == null)
            {
                string driverPath = ConfigurationManager.AppSettings["DriverPath"];

                switch (Browser.Type)
                {
                    case "CR":
                        try
                        {
                            if (IsChromeDebuging)
                            {
                                var pr = Process.GetProcessesByName("chromedriver");

                                if (pr.Length > 0)
                                {
                                    CustomRemoteDriver.NewSession = false;
                                    var driver = new CustomRemoteDriver(new Uri("http://localhost:9515"), DesiredCapabilities.Chrome());
                                    WebDriver = driver;
                                }

                                else
                                {
                                    //if (ConfigurationManager.AppSettings["LoadBalanceCloud"] != "true")
                                    {
                                        Process.Start(GeneralSettings.ChromeDriverPath);
                                        CustomRemoteDriver.NewSession = true;
                                        var driver = new CustomRemoteDriver(new Uri("http://localhost:9515"), DesiredCapabilities.Chrome());
                                        WebDriver = driver;
                                    }
                                }
                            }
                            else
                            {
                                //normal execution
                                var optionss = new ChromeOptions()
                                {

                                    //Proxy = p,
                                };

                                optionss.AddArgument("--user-data-dir=C:\\automation\\baselining\\ChromeProfile");
                                if (ConfigurationManager.AppSettings["LoadBalanceCloud"] == "true")
                                    optionss.AddArgument("--allow-running-insecure-content");

                                WebDriver = new ChromeDriver(driverPath, optionss);
                                WebDriver.Manage().Cookies.DeleteAllCookies();

                                Console.WriteLine("Executed on New driver");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case "FF":
                        break;

                    default:
                        break;


                }
            }
        }
    }
}
