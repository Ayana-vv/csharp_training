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
            ContactsData contact = new ContactsData("Liam", "AAA");
            contact.Mname = "MMM";
            contact.Nname = "NNN";
            contact.Title = "eee";
            contact.Company = "f";
            contact.Address = "g";
            contact.Home = "12345";
            contact.Mobile = null;
            contact.Work = "777";
            //contact.Fax = "333";
            contact.Email = "j@kk.com";
            contact.Email2 = null;
            contact.Email3 = "m@nn.com";
            //contact.Homepage = "ooo5";
            //contact.Address2 = "test_1";
            //contact.Phone2 = "7654";
            //contact.Notes = "test_2";
            
            List<ContactsData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.CreateContact(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactsData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }


        //    public static IEnumerable<ContactsData> RandomGroupDataProvider()
        //    {
        //        List<ContactsData> contact = new List<ContactsData>();
        //        for (int i = 0; i < 5; i++)
        //        {
        //            contact.Add(new ContactsData(GenerateRandomString(10), GenerateRandomString(10))
        //            {
        //                Mname = GenerateRandomString(20),
        //                Nname = GenerateRandomString(20),
        //                Company = GenerateRandomString(20),
        //                Title = GenerateRandomString(20),
        //                Address = GenerateRandomString(20),
        //                Home = GenerateRandomString(20),
        //                Mobile = GenerateRandomString(20),
        //                Work = GenerateRandomString(20),
        //                Fax = GenerateRandomString(20),
        //                Email = GenerateRandomString(20),
        //                Email2 = GenerateRandomString(20),
        //                Email3 = GenerateRandomString(20),
        //                Homepage = GenerateRandomString(20),
        //                Address2 = GenerateRandomString(20),
        //                Phone2 = GenerateRandomString(20),
        //                Notes = GenerateRandomString(20),
        //            });
        //        }
        //        return contact;
        //    }
        //    [Test, TestCaseSource("RandomGroupDataProvider")]
        //    public void MyContactCreationTests1(ContactsData contact)
        //    {          

        //        List<ContactsData> oldContacts = app.Contacts.GetContactList();

        //        app.Contacts.CreateContact(contact);

        //        Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

        //        List<ContactsData> newContacts = app.Contacts.GetContactList();
        //        oldContacts.Add(contact);
        //        oldContacts.Sort();
        //        newContacts.Sort();
        //        Assert.AreEqual(oldContacts, newContacts);
        //    }        
    }
}
