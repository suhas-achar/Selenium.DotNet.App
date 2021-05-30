using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.DotNet.App
{
    public  interface IAssertWrapper
    {
        void AreEqual(string expected, string actual);
        void AreEqual(bool expected, bool actual);

    }
}
