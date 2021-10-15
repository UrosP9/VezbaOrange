using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using VezbaOrange.Details;
using VezbaOrange.Helpers;
using VezbaOrange.Pages;
using VezbaOrange.Serilog;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange
{


    [Binding]
    class LoginSteps : BaseSteps

    {


        [Given(@"user navigates to OrangeHM website")]
        public void GivenUserNavigatesToOrangeHMWebsite()
        {
            Log.Information("Valid Login");
            
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");

            Log.Information("Otvoren URL");
        }

        [When(@"user enters value '(.*)' for username")]
        public void GivenUserEntersValueForUsername(string username)
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.UsrnmField().SendKeys(username);
            Assert.That(loginPage.UsrnmField().GetAttribute("value") == username, "Username not correct");

            Log.Information("Korisceni username {0}", username);
        }

        [When(@"user enters value '(.*)' for password")]
        public void GivenUserEntersValueForPassword(string password)
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.PasswordField().SendKeys(password);
            Assert.That(loginPage.PasswordField().GetAttribute("value") == password, "Password not correct");

            Log.Information("Korisceni password {0}", password);
        }

           
        [When(@"user clicks on login button")]
        public void WhenUserClicksOnLoginButton()
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.LoginButton().Click();

            Log.Information("Kliknut login dugme");
        }

        [Then(@"user can see dashboard page")]
        public void ThenUserCanSeeDashboardPage()
        {
            DashboardPage dashboardPage = new DashboardPage(Driver);
            Assert.That(dashboardPage.DshbrdPage(), "Dashboard page isn't displayed");

            Log.Information("Otvorena dashboard strana");
        }



        [Given(@"User is on Login page")]
        public void GivenUserIsOnLoginPage()
        {
            Log.Information("Invalid Login");

            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");
            LoginPage loginPage = new LoginPage(Driver);

            Assert.That(loginPage.LogPage(), "Login page isn't displayed");

            Log.Information("Otvorena login strana");
        }


        [When(@"user enters invalid credentials for (.*) and (.*)")]
        public void WhenUserEntersInvalidCredentialsForAnd(string Username, string Password)
        {
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsrnmField().SendKeys(Username);
            loginPage.PasswordField().SendKeys(Password);
            Thread.Sleep(1);
            
            Log.Information("Korisceni Username {0}", Username);
            Log.Information("Korisceni Password {0}", Password);
        }


        [Then(@"user can see errormessage for (.*) and (.*)")]
        public void ThenUserCanSeeErrormessageForAnd(string Username, string Password)
        {
            string actualvalue = Driver.FindElement(By.Id("spanMessage")).Text;

            //string vezba = string.Empty;

            if (Username != "" && Password != "")
            {
                Assert.IsTrue(actualvalue.Contains("Invalid credentials"));
                Log.Information("Error poruka 'Invalid credentials'");
            }

            else if ((Username == "" && Password != "") || (Username == "" && Password == ""))
            {
                Assert.IsTrue(actualvalue.Contains("Username cannot be empty"));
                Log.Information("Error poruka 'Username cannot be empty'");
            }

            else if (Username != "" && Password == "")
            {
                Assert.IsTrue(actualvalue.Contains("Password cannot be empty"));
                Log.Information("Error poruka 'Password cannot be empty'");
            }


            //Log.CloseAndFlush();
            //string nesto = string.Empty;

            
            //string pozdravnaPoruka = "Zdravo Urke :)";
            //Console.WriteLine(pozdravnaPoruka);
        }
        
    }
    
}


