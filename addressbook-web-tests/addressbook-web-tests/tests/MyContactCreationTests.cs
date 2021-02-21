using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactCreationTests : AuthTestBase
    {
        [Test]
        public void MyContactCreationTests1()
        {
            ContactsData contact = new ContactsData("Liam", "YYY");
            contact.Mname = "MMM";
            contact.Nname = "NNN";
            contact.Title = "eee";
            contact.Company = "f";
            contact.Address = "g";
            contact.Home = "12345";
            contact.Mobile = "98765";
            contact.Work = "444";
            contact.Fax = "333";
            contact.Email = "j@kk.com";
            contact.Email2 = "i@ll.com";
            contact.Email3 = "m@nn.com";
            contact.Homepage = "ooo5";
            //contact.Byear = "1990";
            //contact.Ayear = "2020";
            contact.Address2 = "test_1";
            contact.Phone2 = "7654";
            contact.Notes = "test_2";

            List<ContactsData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactsData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void MyContactEmptyCreationTest()
        {
            ContactsData contact = new ContactsData("", "");
            contact.Mname = "";
            contact.Nname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            
            List<ContactsData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactsData> newContacts = app.Contacts.GetContactList();            
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
