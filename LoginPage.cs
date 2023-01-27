using OpenQA.Selenium;

namespace Book_Store_app
{
    internal class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        // propery for newuser
        public IWebElement NewUserButton => driver.FindElement(By.Id("newUser"));

        //property for username Login
        public IWebElement UserName => driver.FindElement(By.Id("userName"));

        //property for Pass
        public IWebElement PassWord => driver.FindElement(By.Id("password"));


        //property for LOGIN BUTTON
        public IWebElement LoginButton => driver.FindElement(By.Id("login"));

        //property for error message
        public IWebElement ErrorLoginMessage => driver.FindElement(By.Id("name"));

        //property for empty invalid form
        public IWebElement EmptyForm => driver.FindElement(By.ClassName("is-invalid"));

        //property for welcome screen
        public IWebElement WelcomeText => driver.FindElement(By.CssSelector("form[id='userForm'] div h2"));

        

        //function for clicking newuser and opening REGISTRATION PAGE
        public RegistrationPage ClickNewUser()
        {
            NewUserButton.Click();
            return new RegistrationPage(driver);
        }

        //function for enter username and pass
        public void EnterUserAndPass(string user, string pass)
        {
            UserName.SendKeys(user);
            PassWord.SendKeys(pass);
        }

        //function for click login button
        public ProfilePage ClickLoginButton()
        {
            LoginButton.Click();
            return new ProfilePage(driver);
        }
    }
}