using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium.DotNet.App
{
    [TestClass]
    public class SeleniumUITest
    {

        public void GotoWebSite(string url, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void OpenCricInfoWebSite()
        {
            IWebDriver driver = new ChromeDriver();
            GotoWebSite("https://www.espncricinfo.com/", driver);

            IWebElement navBar = driver.FindElement(By.Id("navbarSupportedContent"));

            string navBarContent = navBar.Text;

            Assert.AreEqual(true, navBarContent.Contains("Live Scores"));

            //driver.Quit();
        }

        [TestMethod]
        public void PointsTable()
        {
            //http://xpather.com/

            IWebDriver driver = new ChromeDriver();
            GotoWebSite("https://www.espncricinfo.com/", driver);

            // IWebElement anchorAbsoulutePath = driver.FindElement(By.XPath("/html/body/div/section/section/div[1]/div[2]/div/div[1]/div[1]/div/div[1]/div[1]/div[2]/ul/li[1]/a"));
            IWebElement anc = driver.FindElement(By.XPath("//section[@id='main-container']//div[2]//ul[starts-with(@class,'widget-item')]//a[starts-with(@title,'IPL 2021')]"));
            anc.Click();

            //IWebElement pointsElement = driver.FindElement(By.XPath("/html/body/div[1]/section/section/div[1]/div[2]/div/div/div[2]/div/div[2]/div[2]/div/div/table/tbody/tr[3]/td[5]"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement pointsElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//section[@id='main-container']//div[@class='widget-container']//div[1]//table//tbody//tr[3]//td[5]")));

            Assert.AreEqual("10", pointsElement.Text);
        }

        [TestMethod]
        public void TestDropdown()
        {
            IWebDriver driver = new ChromeDriver();
            GotoWebSite("https://www.facebook.com/campaign/landing.php", driver);

            var monthDropdown = driver.FindElement(By.Id("month"));
            var selectElement = new SelectElement(monthDropdown);

            selectElement.SelectByValue("11");
            //selectElement.SelectByText("August");
        }

    }
}
