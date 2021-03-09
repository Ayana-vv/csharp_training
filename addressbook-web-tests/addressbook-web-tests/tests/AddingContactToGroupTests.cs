using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{

    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactsData> oldList = group.GetContacts();
            ContactsData contact = ContactsData.GetAllContacts().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactsData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
        [Test]
        public void TestDeleteContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactsData> oldList = group.GetContacts();
            ContactsData contact = ContactsData.GetAllContacts().First();

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactsData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreNotEqual(oldList, newList);
        }
    }
}
