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
            app.Contacts.CheckContacts(1);
            ContactsData newData1 = new ContactsData("ttt");
            newData1.Mname = null;
            newData1.Lname = null;
            newData1.Nname = null;
            newData1.Title = null;
            newData1.Company = "ZZZZZZZ";
            newData1.Address = null;
            newData1.Home = null;
            newData1.Mobile = "+7-777-88";

            app.Contacts.Modify(4, newData1);
        }
    }
}
