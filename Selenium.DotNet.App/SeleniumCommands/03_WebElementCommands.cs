using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Drawing;

namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class WebElementCommands
    {
        [TestMethod]
        public void Navigation()
        {
            IWebDriver _driver = new ChromeDriver();
            IWebElement element = _driver.FindElement(By.Id(""));

            element.Click();
            element.Clear();
            element.SendKeys("Suhas Achar");

            bool enabled = element.Enabled;
            bool displayed = element.Displayed;
            bool selected = element.Selected;

            element.Submit();

            string tagName = element.TagName;// input for <input name="foo"/>.
            string color = element.GetCssValue("background-color"); // if the “background-color” property is set as “green”, then it return #008000

            string attrVal = element.GetAttribute("id"); //This will return the id value of the element.

            //Dimension dimensions = element.Size;
            //Console.WriteLine("Height:" +dimensions.Height + "Width: "+ dimensions.Width);

            Point point = element.Location;
            Debug.WriteLine("X cordinate : " + point.X + "Y cordinate: " + point.Y);

            _driver.Quit();
        }

    }

}
