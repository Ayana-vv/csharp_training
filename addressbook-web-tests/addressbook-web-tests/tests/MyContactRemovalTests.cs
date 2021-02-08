using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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
            List<ContactsData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CheckContacts(0);
            app.Contacts.Remove(0);

            List<ContactsData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
