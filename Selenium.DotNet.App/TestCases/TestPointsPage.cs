using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM;

namespace Selenium.DotNet.App.TestCases
{
    [TestClass]
    public class TestPointsPage
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
        public void PointsTest()
        {
            PointsPage pointsPage = new PointsPage(_driver);
            string points = pointsPage.Points();
            _assertWrapper.AreEqual("10", points);
        }
    }
}
