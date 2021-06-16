using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.DotNet.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITesting.Utility
{
    class MSTestAssertWrapper : IAssertWrapper
    {
        public void AreEqual(string expected, string actual)
        {
            Assert.AreEqual(expected, actual);
        }

        public void AreEqual(bool expected, bool actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
