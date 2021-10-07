using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace VezbaOrange
{
    [Binding]
    public class BaseSteps
    {
        public static IWebDriver Driver { get; private set; }

        [BeforeFeature]
        public static void Setup()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            //Driver.Url = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";

        }

        [AfterFeature]
        public static void Teardown()
        {
            if(Driver != null)
            {
                Driver.Quit();
            }
            
        }
    }
}
