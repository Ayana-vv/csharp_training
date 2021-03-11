using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegisgrationForm(account);
            SubmitRegistration();

        }

        private void OpenRegistrationForm()
        {
            driver.FindElement().Click();
        }

        private void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        private void FillRegisgrationForm(AccountData account)
        {
            throw new NotImplementedException();
        }

        private void OpenMainPage()
        {
            managers.Driver.Url = "http://localhost/mantisbt-1.2.17/login_page.php";
        }
    }
}
