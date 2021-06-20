using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class _10_AlertsAndPopups
    {
        [TestMethod]
        public void Alert_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://toolsqa.com/handling-alerts-using-selenium-webdriver/";

            driver.FindElement(By.XPath("//button[@id='alertButton']")).Click();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IAlert simpleAlert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            simpleAlert = driver.SwitchTo().Alert();

            String alertText = simpleAlert.Text;

            simpleAlert.Accept();
            //simpleAlert.Dismiss();
        }

        [TestMethod]
        public void Alert_ConfirmBox_Test()//Yes or No
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://toolsqa.com/handling-alerts-using-selenium-webdriver/";

            IWebElement element = driver.FindElement(By.XPath("//button[@id='confirmButton']"));
            //driver.FindElement(By.XPath("//button[@id='confirmButton']")).Click();

            // 'IJavaScriptExecutor' is an interface which is used to run the 'JavaScript code' into the webdriver (Browser)
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click()", element);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            IAlert confirmAlert = driver.SwitchTo().Alert();

            confirmAlert.Accept();
            //confirmAlert.Dismiss();
        }

        [TestMethod]
        public void Alert_Prompt_Test()//Entering some text in the prompt box
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://toolsqa.com/handling-alerts-using-selenium-webdriver/";

            IWebElement element = driver.FindElement(By.XPath("//button[@id='promtButton']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            IAlert promptAlert = driver.SwitchTo().Alert();

            promptAlert.SendKeys("Accepting the alert");

            promptAlert.Accept();
        }
    }
}

