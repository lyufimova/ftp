using OpenQA.Selenium;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager)
            : base(manager)
        {
            this.baseURL = manager.BaseURL;
        }

        public void GoToMyview()
        {
            if (driver.Url == baseURL + "my_view_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "my_view_page.php");
        }

        public void GoToManageProjects()
        {
            if (driver.Url == baseURL + "manage_proj_page.php"
                && IsElementPresent(By.XPath("//button[.='Create New Project']")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "manage_proj_page.php");
        }
    }
}
