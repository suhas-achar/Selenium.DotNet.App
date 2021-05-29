using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium.DotNet.App
{
   
    public class SeleniumUITest
    {
        //private IWebDriver _driver;

        //[TestInitialize]
        //public void BeforeEachTestCaseRuns()
        //{
        //    _driver = new ChromeDriver();
        //    _driver.Manage().Window.Maximize();
        //    _driver.Navigate().GoToUrl("https://www.espncricinfo.com");
        //}

        //[TestCleanup]
        //public void AfterEachTestCaseRuns()
        //{
        //    _driver.Quit();
        //}
       

        //public void OpenCricInfoWebSite()
        //{
        //    IWebElement navBar = _driver.FindElement(By.Id("navbarSupportedContent"));

        //    string navBarContent = navBar.Text;

        //    Assert.AreEqual(true, navBarContent.Contains("Live Scores"));
        //}

        //public void PointsTable()
        //{
        //    //http://xpather.com/
        //    IWebElement anc = _driver.FindElement(By.XPath("//section[@id='main-container']//div[2]//ul[starts-with(@class,'widget-item')]//a[starts-with(@title,'IPL 2021')]"));
        //    anc.Click();

        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        //    IWebElement pointsElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//section[@id='main-container']//div[@class='widget-container']//div[1]//table//tbody//tr[3]//td[5]")));

        //    Assert.AreEqual("10", pointsElement.Text);
        //}


        ////public void TestDropdown()
        ////{
        ////    IWebDriver driver = new ChromeDriver();
        ////    GotoWebSite("https://www.facebook.com/campaign/landing.php", driver);

        ////    var monthDropdown = driver.FindElement(By.Id("month"));
        ////    var selectElement = new SelectElement(monthDropdown);

        ////    selectElement.SelectByValue("11");
        ////    //selectElement.SelectByText("August");

        ////    CloseBrowser(driver);
        ////}

        //public void Menubar_Navigation()
        //{
        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"navbarSupportedContent\"]/ul[1]/li[3]")));

        //    Actions action = new Actions(_driver);
        //    action.MoveToElement(element).Perform();

        //    System.Threading.Thread.Sleep(4000);//Waiting for the menu to be displayed    

        //    IWebElement anc = _driver.FindElement(By.XPath("//*[@id=\"navbarSupportedContent\"]/ul[1]/li[3]/div/div/ul[1]/li[4]"));
        //    anc.Click();

        //    wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        //    IWebElement headerText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"__next\"]/div[2]/div/nav/div/a/div[2]/div/div[2]/h5")));

        //    Assert.AreEqual("India", headerText.Text);
        //}
    }
}
