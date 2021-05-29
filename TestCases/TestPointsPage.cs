﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.DotNet.App.POM;

namespace Selenium.DotNet.App.TestCases
{
    [TestClass]
    public class TestPointsPage
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
        public void PointsTest()
        {
            PointsPage pointsPage = new PointsPage(_driver);
            string points = pointsPage.Points();
            Assert.AreEqual("10", points);
        }
    }
}
