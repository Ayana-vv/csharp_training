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
    public class MyContactRemovalTests : ContactTestBase
    { 
        [Test]
        public void MyContactRemovalTest()
        {
            app.Contacts.CheckContacts(0);

            List<ContactsData> oldContacts = ContactsData.GetAllContacts();
            ContactsData tobeRemoved = oldContacts[0];

            app.Contacts.RemoveС(tobeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactsData> newContacts = ContactsData.GetAllContacts();
                        
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactsData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, tobeRemoved.Id);
            }
        }
    }
}
