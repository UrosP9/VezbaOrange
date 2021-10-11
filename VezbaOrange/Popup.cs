using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange
{
    public class Popup
    {
         IWebDriver driver;

        [SetUp]
        public void Set()
        {

            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Window.Minimize();

        
        }

        [Test]
        public void Testt()
        {
            TimeSpan ts = new TimeSpan(0, 0, 20);
            WebDriverWait wait = new WebDriverWait(driver, ts);

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");

            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");

            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");

            driver.FindElement(By.Id("btnLogin")).Click();


            var element = driver.FindElement(By.Id("panel_wrapper_0"));
            Assert.That(element.Displayed);
       
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("welcome")));
            driver.FindElement(By.Id("welcome")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("aboutDisplayLink")));
            
            driver.FindElement(By.Id("aboutDisplayLink")).Click();

            driver.FindElement(By.XPath("//*[@id='displayAbout']/div/a")).Click();

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id='displayAbout']/div/a")));

            driver.Quit();

        }


    }
}