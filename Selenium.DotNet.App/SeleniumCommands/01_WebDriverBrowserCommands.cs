using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Diagnostics;
/// <summary>
/// 1. URL Command
/// 2. Title Command
/// 3. Page Source Command
/// 4. Close Command
/// </summary>
namespace Selenium.DotNet.App.SeleniumCommands
{
    [Ignore]
    [TestClass]
    public class WebDriverBrowserCommands
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void SetupWebDriver()
        {
            _driver = new ChromeDriver();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _driver.Close();
        }

        [TestMethod]
        public void LoadWebPage()
        {
            _driver.Url = "https://www.google.com/"; //Opens the link in the browser
            IWebElement element = _driver.FindElement(By.Id("id"));
            IList<IWebElement> elements = _driver.FindElements(By.Id("id"));
            Debug.WriteLine("Loaded Page : " + _driver.Url); // https://www.google.com/
            Debug.WriteLine("Loaded Page : " + _driver.Title);// Google
            Debug.WriteLine("Loaded Page : " + _driver.PageSource); // Source code

            _driver.Close();// OR _driver.Quit();

        }
    }

}
