using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace Selenium.DotNet.App.SeleniumCommands

{
    [TestClass]
    public class _09_Waits
    {
        [TestMethod]
        public void ImplicitWait_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement textBox = driver.FindElement(By.XPath("//input[@name='q']"));

            // IWebElement textBox1 = driver.FindElement(By.XPath("//input[@name='xyz']"));

            textBox.SendKeys("Selenium");
            textBox.SendKeys(Keys.Enter);

        }

        [TestMethod]
        public void ExplicitWait_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com";


            driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement firstResult = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href,\"wiki\")]")));

            firstResult.Click();

            //Using ExpectedConditions
            IWebElement wikiHeader = wait.Until(drv => drv.FindElement(By.XPath("//h1")));
            bool isPresnt = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(wikiHeader, "Cheese"));

            Assert.IsTrue(isPresnt);

        }

        [TestMethod]
        public void FluentWait_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com";


            WebDriverWait wait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromSeconds(5),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            var foo = wait.Until(drv => drv.FindElement(By.Id("foo")));


        }
    }
}
