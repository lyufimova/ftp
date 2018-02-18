using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()

        {
            ProjectData project = new ProjectData("Test 111");

            List<ProjectData> oldProjects = ProjectData.GetAll();


            app.Projects.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectsCount());

            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }

    }
}
