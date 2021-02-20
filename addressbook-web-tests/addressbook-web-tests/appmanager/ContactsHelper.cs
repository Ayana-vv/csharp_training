using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactsData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage(); 

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lname = cells[1].Text;
            string fname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;            

            return new ContactsData(fname, lname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }
        public ContactsData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string fname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactsData(fname, lname)
            {
                Address = address, 
                Home = home, 
                Mobile = mobile,
                Work = work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactsHelper CreateContact(ContactsData contact)
        {
            GoToAddNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();

            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactsHelper Remove(int p)
        {            
            SelectContact(p);
            RemoveContact();

            manager.CloseAlertAndGetItsText();
            manager.Navigator.ReturnToHomePage();
            return this;
        }       

        public ContactsHelper Modify(int m, ContactsData newData1)
        {
            manager.Navigator.ReturnToHomePage();
                        
            SelectContact(m);
            InitContactModification(m);
            FillContactForm(newData1);
            SubmitContactModification();

            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactsHelper GoToAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactsHelper FillContactForm(ContactsData contact)
        {
            Type(By.Name("firstname"), contact.Fname);
            Type(By.Name("middlename"), contact.Mname);
            Type(By.Name("lastname"), contact.Lname);
            Type(By.Name("nickname"), contact.Nname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("10");
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            driver.FindElement(By.Name("bmonth")).Click();

            Type(By.Name("byear"), contact.Byear);            
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("10");
            driver.FindElement(By.Name("aday")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("January");
            driver.FindElement(By.Name("amonth")).Click();
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }       

        public ContactsHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }
        public ContactsHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" 
                + (index+1) + "]")).Click();
            return this;
        }
        public ContactsHelper CheckContacts(int index)
        {
            manager.Navigator.ReturnToHomePage();
            if (IsElementPresent(By.XPath("//input[@name='selected[]']")))
            {
                return this;
            }
            else
            {
                ApplicationManager app = ApplicationManager.GetInstance();
                GoToAddNewContactPage();
                ContactsData contact = new ContactsData("TTT", "RRR");
                contact.Mname = "YYY";          
                contact.Email = "j@yy.com";
                contact.Byear = "1988";
                contact.Phone2 = "111";
                app.Contacts.CreateContact(contact);
            }
            return this;
        }
        public ContactsHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactsHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public ContactsHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+ (index+1) +"]")).Click();
            return this;
        }
        private List<ContactsData> contactCache = null;
        public List<ContactsData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactsData>();

                manager.Navigator.ReturnToHomePage();

                ICollection<IWebElement> elements =
                    driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.CssSelector("td"));

                    contactCache.Add(new ContactsData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactsData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }
        public int GetNumberOfSearchRezults()
        {
            manager.Navigator.ReturnToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}