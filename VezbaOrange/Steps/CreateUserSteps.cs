using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using VezbaOrange.Details;
using VezbaOrange.Helpers;
using VezbaOrange.Pages;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace VezbaOrange.Steps
{


    [Binding]
    class CreateUserSteps : BaseSteps
    {
        readonly WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

        readonly static string name = Faker.Name.FullName();
        readonly string user = Faker.Internet.UserName(name);
        readonly string eduser = Faker.Internet.UserName(name);
        readonly string pass = Faker.Identification.UkNationalInsuranceNumber();

        [Given(@"I am logged in with username '(.*)' and password '(.*)'")]
        public void GivenIAmLoggedInWithUsernameAndPassword(string username, string password)
        {
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/auth/login");
            LoginPage loginPage = new LoginPage(Driver);
            loginPage.UsrnmField().SendKeys(username);
            loginPage.PasswordField().SendKeys(password);
            loginPage.LoginButton().Click();
        }

        [Given(@"user can see dashboard page")]
        public void GivenUserCanSeeDashboardPage()
        {
            DashboardPage dashboardPage = new DashboardPage(Driver);
            Assert.That(dashboardPage.DshbrdPage(), "Dashboard page isn't displayed");
        }

        [Given(@"user moves mouse to Admin button")]
        public void ThenUserMovesMouseToAdminButton()
        {

            DashboardPage dashboardPage = new DashboardPage(Driver);

            Actions action = new Actions(Driver);
            action.MoveToElement(dashboardPage.AdminButton()).Build().Perform();
        }

        [Given(@"user moves mouse to User Management button")]
        public void ThenUserMovesMouseToUserManagementButton()
        {
            DashboardPage dashboardPage = new DashboardPage(Driver);

            Actions action = new Actions(Driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menu_admin_UserManagement")));

            action.MoveToElement(dashboardPage.UserManagementButton()).Build().Perform();
        }

        [Given(@"user clicks on Users button")]
        public void WhenUserClicksOnUsersButton()
        {
            DashboardPage dashboardPage = new DashboardPage(Driver);

            Actions action = new Actions(Driver);
            
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menu_admin_viewSystemUsers")));

            action.MoveToElement(dashboardPage.UsersButton()).Build().Perform();
            dashboardPage.UsersButton().Click();
        }

        [When(@"user can see System Users page")]
        public void ThenUserCanSeeSystemUsersPage()
        {
            SystemUsersPage sysusersPage = new SystemUsersPage(Driver);
            Assert.That(sysusersPage.SysUsersPage(), "System Users page isn't displayed");
        }

        [When(@"user clicks on Add button")]
        public void WhenUserClicksOnAddButton()
        {
            SystemUsersPage systemusersPage = new SystemUsersPage(Driver);
            systemusersPage.AddButton().Click();
        }

        [When(@"user can see Add User page")]
        public void ThenUserCanSeeAddUserPage()
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
            Assert.That(adduserPage.AddUsPage(), "Add user page isn't displayed");
        }

        [When(@"user selects value '(.*)' from UserRole")]
        public void ThenUserSelectsValueFromUserRole(string UserRole)
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
            adduserPage.UserRoleField().SelectByText("ESS");
            Assert.AreEqual(UserRole, "ESS");
            
        }

        [When(@"user enters value '(.*)' for EmployeeName")]
        public void WhenUserEntersValueForEmployeeName(string EmployeeName)
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
            adduserPage.EmpNameField().SendKeys(EmployeeName);
        }

        [When(@"user enters value for Username")]
        public void WhenUserEntersValueForUsername()
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
           
            adduserPage.UsernameAUField().SendKeys(user);
        }

        [When(@"user enters value for Password")]
        public void WhenUserEntersValueForPassword()
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
            adduserPage.PasswordAUField().SendKeys(pass);
        }

        [When(@"user enters value for ConfirmPassword")]
        public void WhenUserEntersValueForConfirmPassword()
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
            adduserPage.ConfirmPasswordField().SendKeys(pass);
        }


        [When(@"user selects value '(.*)' from Status")]
        public void ThenUserSelectsValueFromStatus(string status)
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
            adduserPage.StatusField().SelectByText("Enabled");
            Assert.AreEqual(status, "Enabled");
        }

        [When(@"user clicks on Save button")]
        public void WhenUserClicksOnSaveButton()
        {
            AddUserPage adduserPage = new AddUserPage(Driver);
            adduserPage.SaveButton().Click();
        }


        [When(@"user enters value for Username on System Users page")]
        public void WhenUserEntersValueForUsernameOnSystemUsersPage()
        {
            SystemUsersPage sysuserPage = new SystemUsersPage(Driver);           
            sysuserPage.UsernameField().SendKeys(user);
        }


        [When(@"user clicks on Search button")]
        public void WhenUserClicksOnSearchButton()
        {
            SystemUsersPage sysuserPage = new SystemUsersPage(Driver);
            sysuserPage.SearchButton().Click();
        }

        [When(@"user can see created users with usernames")]
        public void ThenUserCanSeeCreatedUsers() 
        {
            Driver.FindElement(By.XPath("//*[@id='resultTable']/tbody/tr"));
           
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='resultTable']/tbody/tr")));
          
        }

        [When(@"user clicks on created user")]
        public void WhenUserClicksOnCreatedUser()
        {
            IWebElement table = Driver.FindElement(By.Id("resultTable"));
            ICollection<IWebElement> buttons = table.FindElements(By.XPath("//*[@id='resultTable']/tbody/tr/td[2]/a"));

            foreach (var button in buttons)

            {

                button.Click();

            }
        }

        [When(@"user can see Edit page")]
        public void ThenUserCanSeeEditPage()
        {
            EditPage editPage = new EditPage(Driver);
            Assert.That(editPage.EditttPage(), "Edit page isn't displayed");
        }



        [When(@"user clicks on Edit button")]
        public void WhenUserClicksOnEditButton()
        {
            EditPage editPage = new EditPage(Driver);
            editPage.EditButton().Click();
        }

        [When(@"user edits value for Username")]
        public void WhenUserEditsValueForUsername()
        {
            EditPage editPage = new EditPage(Driver);
            editPage.UsernameEdField().Clear();
            editPage.UsernameEdField().SendKeys(eduser);

            //var data = editPage.UsernameEdField().GetAttribute("value");
           
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(Driver.FindElement(By.Id("systemUser_userName")), eduser));
            //Thread.Sleep(1000);
        }

       
        [When(@"user clicks on SaveEdit button")]
        public void WhenUserClicksOnSaveEditButton()
        {
            EditPage editPage = new EditPage(Driver);
            editPage.SaveEdButton().Click();
        }

        [When(@"user enters value for EditedUsername on System Users page")]
        public void WhenUserEntersValueForEditedUsernameOnSystemUsersPage()
        {
            SystemUsersPage sysuserPage = new SystemUsersPage(Driver);
            sysuserPage.UsernameField().SendKeys(eduser);
        }


        [When(@"user checkmarks an user")]
        public void ThenUserCheckmarksAnUser()
        {
            SystemUsersPage sysusersPage = new SystemUsersPage(Driver);
            sysusersPage.CheckboxField().Click();
        }

        [When(@"user clicks on Delete button")]
        public void ThenUserClicksOnDeleteButton()
        {
            SystemUsersPage sysusersPage = new SystemUsersPage(Driver);
            sysusersPage.DeleteButton().Click();
        }

        [When(@"user can see alert message")]
        public void ThenUserCanSeeAlertMessage()
        {
            var element = Driver.FindElement(By.XPath("//*[@id='deleteConfModal']/div[2]"));
            Assert.That(element.Displayed);
        }

        [When(@"user accept alert")]
        public void WhenUserAcceptAlert()
        {
            Driver.FindElement(By.Id("dialogDeleteBtn")).Click();

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id='deleteConfModal']/div[2]")));

        }

        [Then(@"user cannnot see user")]
        public void ThenUserCannnotSeeUser()
        {

            string actualvalue = Driver.FindElement(By.XPath("//*[@id='resultTable']/tbody/tr/td")).Text;
            Assert.IsTrue(actualvalue.Contains("No Records Found"), actualvalue + " doesn't contain 'No Records Found'");
            
        }

    
    }
}