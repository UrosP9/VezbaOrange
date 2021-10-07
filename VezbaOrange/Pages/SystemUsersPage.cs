using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange.Pages
{
    class SystemUsersPage
    {
        private readonly IWebDriver driver;

        public SystemUsersPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search-results")));
        }

        public bool SysUsersPage()
        {
            By sysusersPage = By.Id("search-results");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(sysusersPage)).Displayed;
        }

        public IWebElement AddButton()
        {
            By addbtn = By.Id("btnAdd");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(addbtn));
        }

        public IWebElement SearchButton()
        {
            By searchbtn = By.Id("searchBtn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(searchbtn));
        }

        public IWebElement DeleteButton()
        {
            By deletebtn = By.Id("btnDelete");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(deletebtn));
        }

        public IWebElement UsernameField()
        {
            By usernameSU = By.Id("searchSystemUser_userName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(usernameSU));
        }

        public IWebElement CheckboxField()
        {
            By checkbox = By.Name("chkSelectRow[]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(checkbox));
        }

        public IWebElement LogoutButton()
        {
            By logoutbtn = By.XPath("/html/body/div[1]/div[1]/div[9]/ul/li[3]/a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(logoutbtn));
        }


    }
}
