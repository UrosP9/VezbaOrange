using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange.Pages
{
    class EditPage
    {
        private readonly IWebDriver driver;
        

        public EditPage(IWebDriver driver)
        {
            this.driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UserHeading")));
        }

        public bool EditttPage()
        {
            By editPage = By.Id("UserHeading");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(editPage)).Displayed;
        }

        public IWebElement EditButton()
        {
            By editbtn = By.Id("btnSave");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(editbtn));
        }

        public IWebElement UsernameEdField()
        {
            By usernameEd = By.Id("systemUser_userName");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(usernameEd));
        }

        public IWebElement SaveEdButton()
        {
            By saveedbtn = By.Id("btnSave");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(saveedbtn));
        }

        
    }
}
