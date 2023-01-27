using OpenQA.Selenium;

namespace Book_Store_app
{
    internal class MainPage : BaseTestClass
    {
       
        public MainPage(IWebDriver driver) 
        {
            this.driver = driver;
        }
        //method for navigation to page
        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/books");

        }
        //property for locating LOGIN BUTTON\
        public IWebElement LoginButton => driver.FindElement(By.Id("login"));



        //Function for clicking login button and opening new PAGE OBJECT
        public LoginPage ClickLogin()
        {
            LoginButton.Click();
            return new LoginPage(driver);
        }
    }
}