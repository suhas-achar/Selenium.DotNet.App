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
    public class _12_PageLoadStrategy
    {
        [TestMethod]
        public void PageLoadStrategy_Normal()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            IWebDriver driver = new ChromeDriver(chromeOptions);

            try
            {
                driver.Navigate().GoToUrl("https://example.com");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void PageLoadStrategy_Eager()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

            IWebDriver driver = new ChromeDriver(chromeOptions);
            try
            {
                driver.Navigate().GoToUrl("https://example.com");
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void PageLoadStrategy_None()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.None;

            IWebDriver driver = new ChromeDriver(chromeOptions);
            try
            {
                driver.Navigate().GoToUrl("https://example.com");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
