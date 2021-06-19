using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class _06_DropDown_MultiSelect
    {
        [TestMethod]
        public void DropDownTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://demo.guru99.com/test/newtours/register.php";
            IWebElement element = driver.FindElement(By.Name("country"));
            SelectElement oSelect = new SelectElement(element);

            oSelect.SelectByValue("FRANCE");//Case Sensitive
            oSelect.SelectByText("FRANCE");
            oSelect.SelectByIndex(2);
        }

        [TestMethod]
        public void MultiSelectTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://output.jsbin.com/osebed/2";
            IWebElement element = driver.FindElement(By.Id("fruits"));
            SelectElement oSelect = new SelectElement(element);

            oSelect.SelectByValue("orange");//Case Sensitive
            oSelect.SelectByText("Apple");//Case Sensitive
            oSelect.SelectByIndex(3);

            oSelect.DeselectByText("Grape");
            //oSelect.DeselectAll();
        }

        [TestMethod]
        public void Oprtions_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://output.jsbin.com/osebed/2";

            IWebElement element = driver.FindElement(By.Id("fruits"));
            SelectElement oSelect = new SelectElement(element);

            IList<IWebElement> items = oSelect.Options;
            foreach (var item in items)
                Debug.WriteLine(item.Text);
        }

    }
}
