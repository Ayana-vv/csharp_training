using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }
        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetAllFromUI()
        {
            manager.Navigator.GoToProjectPage();
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                IList<IWebElement> rows = driver.FindElements(By.CssSelector("td a"));
                foreach (IWebElement row in rows)
                {
                    projectCache.Add(new ProjectData()
                    {
                        Name = row.Text
                    });
                }
            }
            return new List<ProjectData>(projectCache);
        }
        public void ProjectElementVerification()
        {
            manager.Navigator.GoToProjectPage();
            if (!IsProjectExist())
            {
                M.ProjectData project = new Man.ProjectData()
                {
                    Nname = "ddd"
                };
                Creation(project);
            }
        }
        public void Remove(int toBeRemoved)
        {
            manager.Navigator.Open_Homepage();
            manager.Navigator.GoToProjectPage();
            OpenProject(toBeRemoved);
            SubmintProjectRemove();
        }

        private void SubmintProjectRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            projectCache = null;
        }

        private void OpenProject(int toBeRemoved)
        {
            driver.FindElement(By.CssSelector("td:nth-of-type(" + (toBeRemoved + 1) + ") > a")).Click();
        }

        public void Creation(ProjectData project)
        {
            manager.Navigator.GoToProjectPage();
            InitProjectModification();
            FillProjectModification(project);
            SubmintProjectModification();
            Thread.Sleep(3000);
        }

        private void SubmintProjectModification()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            projectCache = null;
        }

        private void FillProjectModification(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
        }
        private void InitProjectModification()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
        public int GetProjectCount()
        {
            return driver.FindElements(By.CssSelector("td > a")).Count;
        }
        private bool IsProjectExist()
        {
            return IsElementPresent(By.CssSelector("td > a"));
        }
        public void CheckProjects(AccountData account, ProjectData project)
        {
            if (GetProjectList(account).Count == 0)
            {
                Create(account, project);
            }
        }
        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> list = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData()
                {
                    Id = project.id,
                    Name = project.name,
                    Description = project.description
                });
            }
            return list;
        }
    }
}
