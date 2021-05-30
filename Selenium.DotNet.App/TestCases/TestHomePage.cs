using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM;

namespace Selenium.DotNet.App.TestCases
{
    [TestClass]
    public class TestHomePage
    {
        private IWebDriver _driver;
        IAssertWrapper _assertWrapper;

        [TestInitialize]
        public void BeforeEachTestCaseRuns()
        {
            _assertWrapper = new MSTestAssertWrapper();
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.espncricinfo.com");
        }

        [TestCleanup]
        public void AfterEachTestCaseRuns()
        {
            _driver.Quit();
        }


        [TestMethod]
        public void HomePageTest()
        {
            HomePage homePage = new HomePage(_driver);
            string title = homePage.OpenCricInfo();
            //Assert.AreEqual(true, title.Contains("Check Live Cricket Scores"));
            _assertWrapper.AreEqual(true, title.Contains("Check Live Cricket Scores"));
        }

        [TestMethod]
        public void CheckNavigationBarTest()
        {
            HomePage homePage = new HomePage(_driver);
            string content = homePage.CheckNavigationBar();
            _assertWrapper.AreEqual(true, content.Contains("Live Scores"));
        }


        [TestMethod]
        public void DropDownTest()
        {
            HomePage homePage = new HomePage(_driver);
            string headerTxt = homePage.DropDownNavbar();
            _assertWrapper.AreEqual("India", headerTxt);
        }

    }
}
