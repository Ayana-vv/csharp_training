﻿using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactCreationTests : TestBase
    {
        [Test]
        public void MyContactCreationTests1()
        {
            ContactsData contact = new ContactsData("sss");
            contact.Mname = "MMM";
            contact.Lname = "LLL";
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
            contact.Byear = "1990";
            contact.Ayear = "2020";
            contact.Address2 = "test_1";
            contact.Phone2 = "555";
            contact.Notes = "test_2";
            app.Contacts.CreateContact(contact);
        }
        [Test]
        public void MyContactEmptyCreationTest()
        {
            ContactsData contact = new ContactsData("");
            contact.Mname = "";
            contact.Lname = "";
            contact.Nname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            app.Contacts.CreateContact(contact);
        }
    }
}