using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.DotNet.App.SeleniumCommands
{
    [TestClass]
    public class _05_CheckBox_RadioButton
    {
        IWebDriver _driver = new ChromeDriver();

        [TestInitialize]
        public void OpenBrowser()
        {
            _driver.Url = "http://demo.guru99.com/test/radio.html";// https://demoqa.com/automation-practice-form";
        }

        [TestMethod]
        public void CheckBox_RadioButton_Click()
        {
            IWebElement radioBtn = _driver.FindElement(By.Id("vfb-7-2"));
            radioBtn.Click();
        }

        public void CheckBox_RadioButton_Selected()
        {
            IWebDriver _driver = new ChromeDriver();

            IList<IWebElement> oRadioButton = _driver.FindElements(By.Name("toolsqa"));

            bool bValue = oRadioButton.ElementAt(0).Selected;

            if (bValue == true)
            {
                oRadioButton.ElementAt(1).Click();
            }
            else
            {
                oRadioButton.ElementAt(0).Click();
            }
        }

        public void CheckBox_RadioButton_Value()
        {
            IWebDriver _driver = new ChromeDriver();

            // Find the checkbox or radio button element by Name
            IList<IWebElement> oCheckBox = _driver.FindElements(By.Name("tool"));

            
            for (int i = 0; i < oCheckBox.Count; i++)
            {
                String Value = oCheckBox.ElementAt(i).GetAttribute("value");

                if (Value.Equals("toolsqa"))
                {
                    oCheckBox.ElementAt(i).Click();
                    break;
                }
            }
        }

        public void CheckBox_RadioButton_CssSelector()
        {
            IWebDriver _driver = new ChromeDriver();

            IWebElement oCheckBox = _driver.FindElement(By.CssSelector("input[value='Tools QA']"));

            oCheckBox.Click();
        }
    }
}
