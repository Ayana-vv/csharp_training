using System;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class MyContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactsData> RandomGroupDataProvider()
        {
            List<ContactsData> contact = new List<ContactsData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactsData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Mname = GenerateRandomString(20),
                    Nname = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Title = GenerateRandomString(20),
                    Address = GenerateRandomString(20),
                    Home = GenerateRandomString(20),
                    Mobile = GenerateRandomString(20),
                    Work = GenerateRandomString(20),
                    Fax = GenerateRandomString(20),
                    Email = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20),
                    Homepage = GenerateRandomString(20),
                    Address2 = GenerateRandomString(20),
                    Phone2 = GenerateRandomString(20),
                    Notes = GenerateRandomString(20),
                });
            }
            return contact;
        }
        public static IEnumerable<ContactsData> ContactsDataFromXmlFile()
        {
            return (List<ContactsData>)
                new XmlSerializer(typeof(List<ContactsData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactsData> ContactsDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactsData>>(
                 File.ReadAllText(@"contacts1.json"));
        }
        [Test, TestCaseSource("ContactsDataFromJsonFile")]
        public void MyContactCreationTests1(ContactsData contact)
        {

            List<ContactsData> oldContacts = ContactsData.GetAllContacts();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactsData> newContacts = ContactsData.GetAllContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactsData> fromUi = ContactsData.GetAllContacts();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactsData> fromDb = ContactsData.GetAllContacts();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
