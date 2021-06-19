using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class BrowserNavigationCommands
    {
      
        [TestMethod]
        public void Navigation()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.google.com/"); //Opens the link in the browser
            _driver.Navigate().Back();
            _driver.Navigate().Forward();
            _driver.Navigate().Refresh();

            _driver.Quit();
        }
    }

}
