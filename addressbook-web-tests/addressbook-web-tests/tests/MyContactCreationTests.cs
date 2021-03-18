using System;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactCreationTests : AuthTestBase
    {        
        [Test]
        public void MyContactCreationTests1()
        {
            ContactsData contact = new ContactsData("Liam", "AAA");
            contact.Mname = "MMM";
            contact.Nname = "NNN";
            contact.Title = null;
            contact.Company = "f";
            contact.Address = "g";
            contact.Home = "12345";
            contact.Mobile = null;
            contact.Work = "777";
            contact.Fax = "333";
            contact.Email = "j@kk.com";
            contact.Email2 = null;
            contact.Email3 = "m@nn.com";
            contact.Homepage = "ooo5";
            contact.Address2 = null;
            contact.Phone2 = "7654";
            contact.Notes = null;

            List<ContactsData> oldContacts = ContactsData.GetAllContacts();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactsData> newContacts = ContactsData.GetAllContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }        
    }
}
