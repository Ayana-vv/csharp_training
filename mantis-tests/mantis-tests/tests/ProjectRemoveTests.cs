using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemoveTests : AuthTestBase
    {
        [Test]
        public void ProjectRemoveTest()
        {
            app.Project.ProjectElementVerification();

            List<ProjectData> oldProjects = app.Project.GetAllFromUI();
            int toBeRemoved = 0;

            app.Project.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.Project.GetAllFromUI();

            oldProjects.RemoveAt(toBeRemoved);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
