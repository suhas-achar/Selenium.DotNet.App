using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class _16_MouseHover
    {
        [TestMethod]
        public void Move_MouseCursorTest()
        {
            //moveToElement(WebElement target): Moves the mouse to the middle of the element.
            //actions.moveToElement(target).perform();

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/menu/";

            Actions actions = new Actions(driver);//using OpenQA.Selenium.Interactions;

            IWebElement menuOption = driver.FindElement(By.XPath("//ul[@id=\"nav\"]/li[2]"));

            actions.MoveToElement(menuOption).Perform();

            IWebElement subMenuOption = driver.FindElement(By.XPath("//ul[@id=\"nav\"]/li[2]/ul/li[3]"));
            actions.MoveToElement(subMenuOption).Perform();

        }

        [TestMethod]
        public void Move_MouseCursor_Offset_Slider_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/slider/";

            Actions actions = new Actions(driver);//using OpenQA.Selenium.Interactions;

            IWebElement slider = driver.FindElement(By.XPath("//input[@type=\"range\"]"));

            actions.MoveToElement(slider, 50, 0).Perform();
           // actions.MoveByOffset(150, 0);

            slider.Click();
        }
    }
}
