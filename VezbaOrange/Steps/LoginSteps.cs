using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using VezbaOrange.Details;
using VezbaOrange.Helpers;
using VezbaOrange.Pages;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange
{


    [Binding]
    class LoginSteps : BaseSteps

    {


        [Given(@"user navigates to OrangeHM website")]
        public void GivenUserNavigatesToOrangeHMWebsite()
        {
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");

        }

        [When(@"user enters value '(.*)' for username")]
        public void GivenUserEntersValueForUsername(string username)
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.UsrnmField().SendKeys(username);
            Assert.That(loginPage.UsrnmField().GetAttribute("value") == username, "Username not correct");
        }

        [When(@"user enters value '(.*)' for password")]
        public void GivenUserEntersValueForPassword(string password)
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.PasswordField().SendKeys(password);
            Assert.That(loginPage.PasswordField().GetAttribute("value") == password, "Password not correct");
        }

        [When(@"user clicks on login button")]
        public void WhenUserClicksOnLoginButton()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.LoginButton().Click();
        }

        [Then(@"user can see dashboard page")]
        public void ThenUserCanSeeDashboardPage()
        {
            DashboardPage dashboardPage = new DashboardPage(Driver);
            Assert.That(dashboardPage.DshbrdPage(), "Dashboard page isn't displayed");
        }



        [Given(@"User is on Login page")]
        public void GivenUserIsOnLoginPage()
        {
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");
            LoginPage loginPage = new LoginPage(Driver);

            Assert.That(loginPage.LogPage(), "Login page isn't displayed");
        }


        [When(@"user enters invalid credentials for (.*) and (.*)")]
        public void WhenUserEntersInvalidCredentialsForAnd(string Username, string Password)
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsrnmField().SendKeys(Username);
            loginPage.PasswordField().SendKeys(Password);
            Thread.Sleep(1);
        }


        [Then(@"user can see errormessage for (.*) and (.*)")]
        public void ThenUserCanSeeErrormessageForAnd(string Username, string Password)
        {
            string actualvalue = Driver.FindElement(By.Id("spanMessage")).Text;

            

            if (Username != "" && Password != "")
            {
                Assert.IsTrue(actualvalue.Contains("Invalid credentials"));
            }

            else if ((Username == "" && Password != "") || (Username == "" && Password == ""))
            {
                Assert.IsTrue(actualvalue.Contains("Username cannot be empty"));
            }

            else if (Username != "" && Password == "")
            {
                Assert.IsTrue(actualvalue.Contains("Password cannot be empty"));
            }
            string pozdravnaPoruka = "Zdravo Urke :)";
            Console.WriteLine(pozdravnaPoruka);
        }

    }
}


