using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.IO;

namespace LearnSeleniumWebdriver
{
    public class CustomRemoteDriver : RemoteWebDriver
    {
        public static bool NewSession = false;
        public static string CapPath = @"c:\automation\sessionCap";
        public static string SessiodIdPath = @"c:\automation\sessionid";

        public CustomRemoteDriver(Uri remoteAddress, DesiredCapabilities dd)
            : base(remoteAddress, dd)
        {

        }

        protected override Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            if (driverCommandToExecute == DriverCommand.NewSession)
            {
                if (!NewSession)
                {
                    //var capText = File.ReadAllText(capPath);
                    var sidText = File.ReadAllText(SessiodIdPath);

                    //var cap = JsonConvert.DeserializeObject<Dictionary<string, object>>(capText);
                    return new Response
                    {
                        SessionId = sidText,
                        //   Value = cap
                    };
                }
                else
                {
                    var response = base.Execute(driverCommandToExecute, parameters);
                    // var dictionary = (Dictionary<string, object>)response.Value;
                    // File.WriteAllText(capPath, JsonConvert.SerializeObject(dictionary));
                    File.WriteAllText(SessiodIdPath, response.SessionId);
                    return response;
                }
            }
            else
            {
                var response = base.Execute(driverCommandToExecute, parameters);
                return response;
            }
        }
    }
}
