using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{    
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testUser",
                Password = "password",
                Email = "testuser@localhost.localhostdomain"
            };

            app.Registration.Register(account);

        }        
    }
}
