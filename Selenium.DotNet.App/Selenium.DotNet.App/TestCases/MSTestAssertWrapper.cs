using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selenium.DotNet.App.TestCases
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
