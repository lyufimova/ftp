using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected ProjectHelper projectHelper;
        protected NavigationHelper navigator;

        protected LoginHelper loginHelper;
        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager> ();

        private ApplicationManager()
        {

            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox EST\firefox.exe";
            options.UseLegacyImplementation = true;

            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/mantisbt-2.11.1/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            projectHelper = new ProjectHelper(this);
            navigator = new NavigationHelper(this);
            loginHelper = new LoginHelper(this);
        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.11.1/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }


        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public string BaseURL
        {
            get
            {
                return baseURL;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }


        public ProjectHelper Projects
        {
            get
            {
                return projectHelper;
            }

        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

    }
}
