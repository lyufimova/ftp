using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
   

    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            if (app.Projects.GetProjectsCount() == 0)
            {
                ProjectData project = new ProjectData("ProjectToRemove");
                app.Projects.Create(project);
            }

            List<ProjectData> oldProjects = ProjectData.GetAll();
            ProjectData toBeRemoved = oldProjects[0];

            app.Projects.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectsCount());

            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.Remove(toBeRemoved);
            Assert.AreEqual(oldProjects, newProjects);
            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }

        }
    }
}
