using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Book_Store_app
{
    internal class RegistrationPage
    {
        private IWebDriver driver;
        

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //property for FirstName field
        public IWebElement FirstName => driver.FindElement(By.Id("firstname"));

        //property for LastName Field 
        public IWebElement LastName => driver.FindElement(By.Id("lastname"));

        //property for UserName
        public IWebElement Username => driver.FindElement(By.Id("userName"));

        //property for pass
        public IWebElement Password => driver.FindElement(By.Id("password"));

        //property for check box
        public IWebElement CheckBox => driver.FindElement(By.Id("recaptcha-anchor"));

        //Property for REGISTER button
        public IWebElement RegisterButton => driver.FindElement(By.Id("register"));

        //property for wrong entered pass
        public IWebElement WrongPassMessage => driver.FindElement(By.Id("name"));


        //function for entering the input fields
        public void EnterFields(string firstname, string lastname, string username, string pass)
        {
            FirstName.SendKeys(firstname);
            LastName.SendKeys(lastname);
            Username.SendKeys(username);
            Password.SendKeys(pass);
        }
        //method for frame switch
        public void frameSwitch()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[title='reCAPTCHA']")));
        }
        //function for click checkbox
        public void ClickCheckBox()
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("recaptcha-anchor")));
            CheckBox.Click();
        }
        //function for click register
        public void ClickRegisterButton()
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("register")));
            
            RegisterButton.Click();
          
        }
            
    } 
}