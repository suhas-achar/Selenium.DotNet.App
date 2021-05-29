using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium.DotNet.App.POM
{
    public class HomePage
    {
        private IWebDriver _driver;
        private By navBarBy = By.Id("navbarSupportedContent");
        private By pointsPageBy = By.XPath("//section[@id='main-container']//div[2]//ul[starts-with(@class,'widget-item')]//a[starts-with(@title,'IPL 2021')]");
        private By navDropDownBy = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul[1]/li[3]");
        private By navDropDownPaneBy = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul[1]/li[3]/div/div/ul[1]/li[4]");
        private By navDropDownDataBy = By.XPath("//*[@id=\"__next\"]/div[2]/div/nav/div/a/div[2]/div/div[2]/h5");
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string OpenCricInfo()
        {

            return _driver.Title;
        }

        public string NavigationBar()
        {
            IWebElement navBar = _driver.FindElement(navBarBy);

            return navBar.Text;
        }

        public string NavigateToPointsPage()
        {
            IWebElement linkPointsPage = _driver.FindElement(pointsPageBy);
            linkPointsPage.Click();
            return _driver.Title;
        }

        public string DropDownNavbar()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(navDropDownBy));

            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();

            System.Threading.Thread.Sleep(4000);//Waiting for the menu to be displayed    

            IWebElement anc = _driver.FindElement(navDropDownPaneBy);
            anc.Click();

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement headerText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(navDropDownDataBy));

            return headerText.Text;
        }

    }
}
