using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSeleniumWebdriver
{
    public class Browser
    {
        public static string Type = ConfigurationManager.AppSettings["BrowserType"];

    }

    

    class GeneralSettings
    {
        public static readonly string ChromeDriverPath = ConfigurationManager.AppSettings["ChromeDriverPath"];
    }
}
