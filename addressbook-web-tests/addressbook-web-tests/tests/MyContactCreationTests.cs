using System;
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
            ContactsData group = new ContactsData("sss");
            group.Mname = "MMM";
            group.Lname = "LLL";
            group.Nname = "NNN";
            group.Title = "eee";
            group.Company = "f";
            group.Address = "g";
            group.Home = "12345";
            group.Mobile = "98765";
            group.Work = "444";
            group.Fax = "333";
            group.Email = "j@kk.com";
            group.Email2 = "i@ll.com";
            group.Email3 = "m@nn.com";
            group.Homepage = "ooo5";
            group.Byear = "1990";
            group.Ayear = "2020";
            group.Address2 = "test_1";
            group.Phone2 = "555";
            group.Notes = "test_2";
            app.Contacts.CreateContact(group);
        }
        [Test]
        public void MyContactEmptyCreationTest()
        {
            ContactsData group = new ContactsData("");
            group.Mname = "";
            group.Lname = "";
            group.Nname = "";
            group.Title = "";
            group.Company = "";
            group.Address = "";
            group.Home = "";
            group.Mobile = "";
            group.Work = "";
            group.Fax = "";
            group.Email = "";
            app.Contacts.CreateContact(group);
        }
    }
}
