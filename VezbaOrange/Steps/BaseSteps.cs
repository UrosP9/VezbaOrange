using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Serilog;
using Serilog.Events;
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

           
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                    .WriteTo.File(GetAssemblyDirectory() + "/log-{Date}.txt", LogEventLevel.Information)
                    .CreateLogger();

            Log.Information("Pocinje");
        }

        [AfterFeature]
        public static void Teardown()
        {
            if(Driver != null)
            {
                Driver.Quit();
            }
            
        }

        //public static void ConfigureLogger()
        //{
        //    Log.Logger = new LoggerConfiguration()
        //        .MinimumLevel.Debug()
        //            .WriteTo.File(GetAssemblyDirectory() + "/log.txt", LogEventLevel.Information)
        //            //.Enrich.WithThreadId()
        //            //.Enrich.WithMachineName()
        //            .CreateLogger();

        //    Log.Information("Pocinje");
        //}

        private static string GetAssemblyDirectory()
        {
            string nesto = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(nesto);
        }
    }
}
