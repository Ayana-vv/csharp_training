using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactModificationTests : TestBase
    {
        [Test]
        public void MyContactModificationTest()
        {
            ContactsData newData1 = new ContactsData("ttt");
            newData1.Mname = "HHH";
            newData1.Lname = "KKK";
            newData1.Nname = "PPP";
            newData1.Title = "ddd";
            newData1.Company = "zzzzzzzzzzzzz";
            newData1.Address = "cccc";
            newData1.Home = "+7-0258";
            newData1.Mobile = "+7-999-058";
            newData1.Email = "aaaaa@vv.com";

            app.Contacts.Modify(4, newData1);
        }
    }
}
