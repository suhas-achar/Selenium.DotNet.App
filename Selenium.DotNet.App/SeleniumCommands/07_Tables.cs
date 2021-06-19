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
    public class _07_Tables
    {
        [TestMethod]
        public void Table_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "file:///H:/Learn/TestingFramework/Selenium.DotNet.App/Selenium.DotNet.App/UI/TablePage.html";

            var elemTable = driver.FindElement(By.Id("tbl"));

            List<IWebElement> rowElements = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));


            String strRowData = "";

            foreach (var row in rowElements)
            {
                List<IWebElement> colElements = new List<IWebElement>(row.FindElements(By.TagName("td")));

              
                if (colElements.Count > 0)
                {
                    foreach (var col in colElements)
                    {
                        strRowData = strRowData + col.Text + "\t\t";
                    }
                }
                else
                {
                    Debug.WriteLine("This is Header Row");
                    Debug.WriteLine(rowElements[0].Text.Replace(" ", "\t\t"));
                }
                Debug.WriteLine(strRowData);
                strRowData = String.Empty;
            }
            Debug.WriteLine("");
            //driver.Quit();
        }

        [TestMethod]
        public void Table_Rows_Columns_Count_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "file:///H:/Learn/TestingFramework/Selenium.DotNet.App/Selenium.DotNet.App/UI/TablePage.html";

            var elemTable = driver.FindElement(By.Id("tbl"));

            List<IWebElement> rowElements = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));

            var rowElement = elemTable.FindElement(By.TagName("tr"));
            List<IWebElement> colElements = new List<IWebElement>( rowElement.FindElements(By.TagName("td")));

            Debug.WriteLine("No. of Rows : " + rowElements.Count);
            Debug.WriteLine("No. of Columns : " + colElements.Count);
        }

    }
}

