using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace POM
{
    public class PointsPage
    {
        private IWebDriver _driver;
        private By pointsPageBy = By.XPath("//section[@id='main-container']//div[2]//ul[starts-with(@class,'widget-item')]//a[starts-with(@title,'IPL 2021')]");
        private By pointsBy = By.XPath("//section[@id='main-container']//div[@class='widget-container']//div[1]//table//tbody//tr[3]//td[5]");

        public PointsPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public string Points()
        {
            IWebElement anc = _driver.FindElement(pointsPageBy);
            anc.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement pointsElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(pointsBy));

            return pointsElement.Text;
        }
    }
}
