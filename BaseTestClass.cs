using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Book_Store_app
{
    public class BaseTestClass
    {
        public IWebDriver driver;
        WebDriverWait Wait;
        public string username = "user";
        public string pass = "aA123456789!";

        [SetUp]
        public void SetUpMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        }

        [TearDown]
        public void TearDownMethod()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}