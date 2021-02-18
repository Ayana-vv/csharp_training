using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactModificationTests : AuthTestBase
    {
        [Test]
        public void MyContactModificationTest()
        {
            app.Contacts.CheckContacts(0);
            ContactsData newData1 = new ContactsData("ttt", null);
            newData1.Mname = null;
            newData1.Nname = null;
            newData1.Title = null;
            newData1.Company = "ZZZZZZZ";
            newData1.Address = null;
            newData1.Home = null;
            newData1.Mobile = "+7-777-88";

            List<ContactsData> oldContacts = app.Contacts.GetContactList();
            ContactsData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData1);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactsData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Fname = newData1.Fname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactsData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData1.Fname, contact.Fname);
                }
            }
        }
    }
}
