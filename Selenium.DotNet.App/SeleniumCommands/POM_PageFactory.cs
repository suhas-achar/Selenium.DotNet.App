using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.DotNet.App.SeleniumCommands
{
    public class POM_PageFactoryPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement MyAccount { get; set; }

    }


    public class PO_HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "account")]
        public IWebElement MyAccount { get; set; }
    }

    public class PO_LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "log")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "pwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement Submit { get; set; }
    }
}
