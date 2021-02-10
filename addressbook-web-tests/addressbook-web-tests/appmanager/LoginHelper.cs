using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {      
        }
        public void Login(AccountData account)
        {
            if (IsLoggetIn())
            {
                if (IsLoggetIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }       

        public void Logout()
        {
            if (IsLoggetIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
        public bool IsLoggetIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggetIn(AccountData account)
        {
            return IsLoggetIn()
                && GetLoggetUserName() == account.Username;                    
        }
        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }
    }
}
