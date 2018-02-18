using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager)
           : base(manager)
        {
        }

        public ProjectHelper Create(ProjectData project)
        {
            manager.Navigator.GoToManageProjects();
            CreateNewProject();
            FillProjectForm(project);
            SubmitProjectForm();
            return this;
        }

        public ProjectHelper Remove(ProjectData project)
        {
            manager.Navigator.GoToManageProjects();
            SelectProject(project);
            RemovalProject();
            ConfirmRemoval();
            return this;
        }

        public ProjectHelper ConfirmRemoval()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("div.alert-warning")).Count > 0);
            driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
            return this;
        }

        public ProjectHelper RemovalProject()
        {
            driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
            return this;
        }

        public ProjectHelper SelectProject(ProjectData project)
        {

            IReadOnlyCollection<IWebElement> result = driver.FindElement(By.XPath("//button[.='Create New Project']/../../../..")).FindElements(By.CssSelector("td a"));
            foreach (IWebElement element in result)
            {
                if (element.GetAttribute("href").EndsWith("?project_id="+project.Id))
                {
                    element.Click();
                    return this;
                }
            }
               
            return this;
        }

        public ProjectHelper SubmitProjectForm()
        {
            driver.FindElement(By.CssSelector("input[value='Add Project']")).Click();
            return this;
        }

        public ProjectHelper FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            return this;
        }

        public ProjectHelper CreateNewProject()
        {
            driver.FindElement(By.XPath("//button[.='Create New Project']")).Click();

            return this;
        }

        public int GetProjectsCount()
        {
            manager.Navigator.GoToManageProjects();
            return driver.FindElement(By.XPath("//button[.='Create New Project']/../../../..")).FindElements(By.CssSelector("tr")).Count-1;
        }




    }
}
