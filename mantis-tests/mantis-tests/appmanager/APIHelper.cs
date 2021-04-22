using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {       
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<Mantis.ProjectData> GetAllProject(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projects = new Mantis.ProjectData();
            Mantis.ProjectData[] allprojects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            List<Mantis.ProjectData> list = new List<Mantis.ProjectData>();
            foreach (var project in allprojects)
            {
                list.Add(project);
            }
            return list;
        }
        public void Create(ProjectData project, AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projects = new Mantis.ProjectData();
            projects.name = projectData.Name;
            client.mc_project_add(account.Username, account.Password, projects);
        }
    }
}
