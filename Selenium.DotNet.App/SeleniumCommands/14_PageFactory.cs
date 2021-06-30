using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.DotNet.App.SeleniumCommands
{

    [TestClass]
    public class _14_PageFactory
    {

        public void PageFactory_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.store.demoqa.com";

            var homePage = new PO_HomePage();
            PageFactory.InitElements(driver, homePage);
            homePage.MyAccount.Click();

            var loginPage = new PO_LoginPage();
            PageFactory.InitElements(driver, loginPage);
            loginPage.UserName.SendKeys("TestUser_1");
            loginPage.Password.SendKeys("Test@123");
            loginPage.Submit.Submit();
        }

    }
}
