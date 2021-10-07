using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange.Pages
{
    class AddUserPage
    {
        
        private readonly IWebDriver driver;
        
        public AddUserPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UserHeading")));
        }

        public bool AddUsPage()
        {
            By adduserPage = By.Id("UserHeading");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(adduserPage)).Displayed;
        }

        public SelectElement UserRoleField()
        {
            By userrole = By.Id("systemUser_userType");
            return new SelectElement(driver.FindElement(userrole));

        }

        public IWebElement EmpNameField()
        {
            By empname = By.Id("systemUser_employeeName_empName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(empname));
        }

        public IWebElement UsernameAUField()
        {
            By usernameAU = By.Id("systemUser_userName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(usernameAU));
        }

        public SelectElement StatusField()
        {
            By status = By.Id("systemUser_status");
            return new SelectElement(driver.FindElement(status));

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //SelectElement se = new SelectElement(wait.Until(ExpectedConditions.ElementIsVisible(status)));
            //return se;
        }

        public IWebElement PasswordAUField()
        {
            By passwordAU = By.Id("systemUser_password");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(passwordAU));
        }

        public IWebElement ConfirmPasswordField()
        {
            By confpassword = By.Id("systemUser_confirmPassword");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(confpassword));
        }

        public IWebElement SaveButton()
        {
            By savebtn = By.Id("btnSave");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(savebtn));
        }




    }
}
