using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.DotNet.App.POM;

namespace Selenium.DotNet.App.TestCases
{
    [TestClass]
    public class TestHomePage
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void BeforeEachTestCaseRuns()
        {
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
            Assert.AreEqual(true, title.Contains("Check Live Cricket Scores"));
        }

        [TestMethod]
        public void NavigationBarTest()
        {
            HomePage homePage = new HomePage(_driver);
            string content = homePage.NavigationBar();
            Assert.AreEqual(true, content.Contains("Live Scores"));
        }

        [TestMethod]
        public void NavigationTest()
        {
            HomePage homePage = new HomePage(_driver);
            string title = homePage.NavigateToPointsPage();
            Assert.AreEqual(true, title.Contains("Indian Premier League"));
        }

        [TestMethod]
        public void DropDownTest()
        {
            HomePage homePage = new HomePage(_driver);
            string headerTxt = homePage.DropDownNavbar();
            Assert.AreEqual("India", headerTxt);
        }

    }
}
