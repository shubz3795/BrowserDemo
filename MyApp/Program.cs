using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using OpenQA.Selenium.Remote;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MyApp
{

    public class Program
    {

        public static IWebDriver driver = new ChromeDriver();
        public static Actions actions => new Actions(driver);
        public static IJavaScriptExecutor js => (IJavaScriptExecutor)driver;

        //public static IAlert alert = driver.SwitchTo().Alert();

        public static By TextBox => By.XPath("//input[@type='text']");
        public static By TexList => By.XPath("//ul[@role='listbox']");


        
        static void Main(string[] args)
        {

            BrowserStack();
            Console.ReadLine();

        }
        public static void BrowserStack()
        {
            string USERNAME = "shubhamkulkarni1";
            string AUTOMATE_KEY = "WyWcmc2mtZc5TwQBBsFe";


            ChromeOptions capability = new ChromeOptions();
            capability.AddAdditionalCapability("os_version", "6.0", true);
            capability.AddAdditionalCapability("device", "Samsung Galaxy Note 4", true);
            capability.AddAdditionalCapability("real_mobile", "true", true);
            capability.AddAdditionalCapability("browserstack.local", "false", true);
            capability.AddAdditionalCapability("browserstack.user", "shubhamkulkarni1", true);
            capability.AddAdditionalCapability("browserstack.key", "WyWcmc2mtZc5TwQBBsFe", true);


            IWebDriver driver;
            driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capability);


            //Start of test case

            driver.Navigate().GoToUrl("http://www.google.com");

            Console.WriteLine(driver.Title);

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("selenium");
            query.Submit();
            Console.WriteLine(driver.Title);

            driver.Quit();
        }
        public static string getConfig(string parameter)
        {
            string configStream = File.ReadAllText(@"../../../Practise.json");
            var config = JObject.Parse(configStream.ToString());
            string configValue = config.GetValue(parameter).ToString();
            return configValue;
        }
    }
}
