using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactRemovalTests : AuthTestBase
    { 
        [Test]
        public void MyContactRemovalTest()
        {
            app.Contacts.CheckContacts(1);
            app.Contacts.Remove(1);
        }
    }
}
