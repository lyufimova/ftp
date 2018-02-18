using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
           : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
           .Until(d => d.FindElements(By.Name("password")).Count > 0);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector(".user-info")).Click();
                driver.FindElement(By.XPath("//a[.='Logout']")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("navbar"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.CssSelector(".user-info")).Text;
            return text;
        }
    }

}
