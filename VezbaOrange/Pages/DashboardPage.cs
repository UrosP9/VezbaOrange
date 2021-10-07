using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange.Pages
{
    class DashboardPage
    {
        private readonly IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("panel_wrapper_0")));
        }

        public bool DshbrdPage()
        {
            By dashboardPage = By.Id("panel_wrapper_0");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(dashboardPage)).Displayed;
        }

        public IWebElement AdminButton()
        {
            By adminbtn = By.Id("menu_admin_viewAdminModule");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(adminbtn));
        }

        public IWebElement UserManagementButton()
        {
            By usermngbtn = By.Id("menu_admin_UserManagement");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(usermngbtn));
        }

        public IWebElement UsersButton()
        {
            By usersbtn = By.Id("menu_admin_viewSystemUsers");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(usersbtn));
        }

        public IWebElement LogoutButton()
        {
            By logoutbtn = By.XPath("//*[@id='welcome - menu']/ul/li[3]/a");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(logoutbtn));
        }




    }
}