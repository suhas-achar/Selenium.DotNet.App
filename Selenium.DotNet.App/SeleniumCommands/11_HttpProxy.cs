using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class _11_HttpProxy
    {
        [TestMethod]
        public void HttpProxies_Test()
        {
            Proxy proxy = new Proxy();
            proxy.Kind = ProxyKind.Manual;
            proxy.IsAutoDetect = false;
            proxy.SslProxy = "<HOST:PORT>";

            ChromeOptions options = new ChromeOptions();
            options.Proxy = proxy;
            options.AddArgument("ignore-certificate-errors");

            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
        }
    }
}
