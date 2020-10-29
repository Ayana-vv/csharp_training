using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactCreationTests : TestBase
    {
        [Test]
        public void MyContactCreationTests1()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            GoToAddNewContactPage();
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
            FillContactForm(group);
            SubmitContactCreation();
            ReturnToHomePage();
        }
    }
}
