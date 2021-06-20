using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class _13_MultipleBrowserWindows
    {
        [TestMethod]
        public void MupltipleWindows()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://toolsqa.com/automation-practice-switch-windows/";

            // Store the parent window of teh driver
            String parentWindowHandle = driver.CurrentWindowHandle;
            Debug.WriteLine("Parent window's handle -> " + parentWindowHandle);//Parent window's handle -> CDwindow-AB2DEB00611B7D0A15480A9014F26793

            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            // IWebElement clickElement = driver.FindElement(By.Id("windowButton"));
            //IWebElement clickElement = driver.FindElement(By.Id("messageWindowButton"));


            // Multiple click to open multiple window
            for (var i = 0; i < 3; i++)
            {
                clickElement.Click();
                //Thread.Sleep(3000);
            }
        }

        [TestMethod]
        public void WindowHandles_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://toolsqa.com/automation-practice-switch-windows/";

            // Store the parent window of the driver
            String parentWindowHandle = driver.CurrentWindowHandle;
            Debug.WriteLine("Parent window's handle -> " + parentWindowHandle);

            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));

            // Multiple click to open multiple window
            for (var i = 0; i < 3; i++)
            {
                clickElement.Click();
                //Thread.Sleep(3000);
            }

            // Store all the opened window into the list 
            List<string> lstWindow = driver.WindowHandles.ToList();

            foreach (var handle in lstWindow)
            {
                Debug.WriteLine(handle);
            }
        }


        [TestMethod]
        public void Handle_MultipleWindows_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://toolsqa.com/automation-practice-switch-windows/";


            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));

            // Multiple click to open multiple window
            for (var i = 0; i < 3; i++)
            {
                clickElement.Click();
                //Thread.Sleep(3000);
            }

            // Store all the opened window into the 'list' 
            List<string> lstWindow = driver.WindowHandles.ToList();
            // Traverse each and every window 
            foreach (var handle in lstWindow)
            {
                //Switch to the desired window first and then execute commands using driver. Here navigating to new url.
                driver.SwitchTo().Window(handle);
                driver.Navigate().GoToUrl("https://google.com");
            }

        }

        [TestMethod]
        public void Close_MultipleWindows_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://toolsqa.com/automation-practice-switch-windows/";

            String parentWindowHandle = driver.CurrentWindowHandle;
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));

            // Multiple click to open multiple window
            for (var i = 0; i < 3; i++)
            {
                clickElement.Click();
                //Thread.Sleep(3000);
            }

            //  driver.WindowHandles is a ReadOnlycollection So i am using '.ToList()' and store into the 'List<string>'
            //Again using 'for loop' to traverse all window which are opened by the above loop 
            //then i use '.SwitchTo().Window'. Basically this is use to switch your control from parent window to current window


            List<string> lstWindow = driver.WindowHandles.ToList();
            String lastWindowHandle = "";
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window - > " + handle);
                Console.WriteLine("Navigating to google.com");

                //Switch to the desired window first and then execute commands using driver
                driver.SwitchTo().Window(handle);

                driver.Navigate().GoToUrl("https://google.com");
                lastWindowHandle = handle;
            }

            //Switch to the parent window
            driver.SwitchTo().Window(parentWindowHandle);

            //close the parent window
            driver.Close();

            //at this point there is no focused window, we have to explicitly switch back to some window.
            driver.SwitchTo().Window(lastWindowHandle);

            driver.Url = "https://toolsqa.com";

        }

    }
}