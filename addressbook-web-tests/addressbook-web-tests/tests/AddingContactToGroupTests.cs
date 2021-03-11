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
            app.Contacts.ContactCheck();
            app.Groups.GroupCheck();

            GroupData group = GroupData.GetAll()[0];
            List<ContactsData> oldList = group.GetContacts();
            ContactsData contact = ContactsData.GetAllContacts().Except(oldList).First();

            for (int i = 0; i < oldList.Count(); i++)
            {
                if (oldList[i].Id.Equals(contact.Id))
                {
                    contact = new ContactsData("111", "bbb");
                    app.Contacts.CreateContactC(contact);
                    contact.Id = app.Contacts.GetContactId();
                }
            }

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
            app.Contacts.ContactCheck();
            app.Groups.GroupCheck();

            GroupData group = GroupData.GetAll()[0];
            List<ContactsData> oldList = group.GetContacts();
            ContactsData contact = ContactsData.GetAllContacts().First();

            if (group.GetContacts().Count() == 0)
            {
                app.Contacts.AddContactToGroup(contact, group);
            }            
            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactsData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreNotEqual(oldList, newList);
        }
    }
}
