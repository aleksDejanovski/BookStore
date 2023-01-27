using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Book_Store_app
{
    [TestFixture]
    public class Book_Store_TestCases : BaseTestClass

    {

        [Test]
        [Category("REGISTRATION")]
        public void GoToLoginPage()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            Assert.IsTrue(driver.Url.Contains("login"));
        }
        [Test]
        [Category("REGISTRATION")]
        public void GoToRegistrationPage()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.ClickNewUser();
            Assert.IsTrue(driver.Url.Contains("register"));

        }
        [Test]
        [Category("REGISTRATION")]
        public void VerifyThatUserCanRegisterUsingValidData()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.ClickNewUser();
            RegistrationPage pageRegister = new RegistrationPage(driver);
            pageRegister.EnterFields("aleksandar", "dejanovski", "usernamee", "12345678!!21212");
            pageRegister.frameSwitch();
            pageRegister.ClickCheckBox();
            pageRegister.ClickRegisterButton();


            //NOTE AFTER CAPCHA GETS CLICKED IMAGES APPEAR SO I CAN NOT AUTOMATE THAT !!!!

            var alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text.Contains("User Register Successfully"));

        }
        [Test]
        [Category("REGISTRATION")]
        public void VerifyThatUserIsNotAbleToRegisterWithEmptyForm()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.ClickNewUser();
            RegistrationPage pageRegister = new RegistrationPage(driver);
            pageRegister.EnterFields("", "", "", "");
            pageRegister.frameSwitch();
            pageRegister.ClickCheckBox();
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(2500);
            pageRegister.ClickRegisterButton();
            Assert.IsTrue(pageLogin.EmptyForm.Displayed);


            //NOTE AFTER CAPCHA GETS CLICKED IMAGES APPEAR SO I CAN NOT AUTOMATE THAT !!!!



        }
        [Test]
        [Category("REGISTRATION")]
        public void VerifyThatUserIsNotAbleToRegisterWithNotValidPassword()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.ClickNewUser();
            RegistrationPage pageRegister = new RegistrationPage(driver);
            pageRegister.EnterFields("marko", "markovski", "aleks112", "33");
            pageRegister.frameSwitch();
            pageRegister.ClickRegisterButton();
            Assert.IsTrue(pageRegister.WrongPassMessage.Text.Contains("Passwords must have at least one non alphanumeric character, one digit "));

            // NOTE CAPCHA ELEMENT OVERLAPS THE REGISTER BUTON SO SELENIUM CAN CLICK IT AND THROWS EX

            //NOTE AFTER CAPCHA GETS CLICKED IMAGES APPEAR SO I CAN NOT AUTOMATE THAT !!!!



        }
        [Test]
        [Category("LOGIN")]
        public void VerifyThatUserIsAbleToLoginUsingValidData()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            Assert.AreEqual("user", pageProf.userNameForVerify.Text);

        }
        [Test]
        [Category("LOGIN")]
        public void VerifyThatUserIsNOTAbleToLoginUsingInvalidPass()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, "22");
            pageLogin.ClickLoginButton();
            Assert.AreEqual("Invalid username or password!", pageLogin.ErrorLoginMessage.Text);

        }
        [Test]
        [Category("LOGIN")]
        public void VerifyThatUserIsNOTAbleToLoginUsingInvalidUserName()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass("1123!", pass);
            pageLogin.ClickLoginButton();
            Assert.AreEqual("Invalid username or password!", pageLogin.ErrorLoginMessage.Text);

        }
        [Test]
        [Category("LOGIN")]
        public void VerifyThatUserIsNOTAbleToLoginUsingEmptyForm()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass("", "");
            pageLogin.ClickLoginButton();
            Assert.IsTrue(pageLogin.EmptyForm.Displayed);

        }
        [Test]
        [Category("PROFILE")]
        public void VerifyThatUserIsAbleToLogOut()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            pageProf.ClickLogOut();
            Assert.AreEqual("Welcome,", pageLogin.WelcomeText.Text);

        }
        [Test]
        [Category("PROFILE")]
        public void VerifyThatUserIsAbleToVisitProfilePage()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            List<IWebElement> listOfElements = driver.FindElements(By.CssSelector(".element-list.collapse.show")).ToList();
            IWebElement ProfileEle = listOfElements.Where(el => el.Text.Contains("Pro")).FirstOrDefault();
            ProfileEle.Click();
            Assert.IsTrue(driver.Url.Contains("profile"));


        }
        [Test]
        [Category("BOOKSTORE")]
        public void VerifyThatUserIsAbleToClickBook()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            pageProf.ClickBook();
            Assert.AreEqual("ISBN :", pageProf.Isbn.Text);

        }

        [Test]
        [Category("BOOKSTORE")]
        public void VerifyThatUserIsAbleAddBookToCollection()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            pageProf.ClickBook();
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();
            Thread.Sleep(2000);
            pageProf.ClickAddColection();   // at this line IFRAME APPEARS that has no x button i can not turn off the i frame and selenium fails
            Thread.Sleep(2000);
            var alert = driver.SwitchTo().Alert();
            Assert.IsTrue(alert.Text.Contains("collection"));


        }
        [Test]
        [Category("BOOKSTORE")]
        public void VerifyThatUserIsAbleToSearchaBook()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            pageProf.SearchItem("Speaking JavaScript");
            Assert.IsTrue(pageProf.SeachJavaBook.Text.Contains("Speaking JavaScript"));


        }

        [Test]
        [Category("BOOKSTORE")]
        public void VerifyThatUserIsAbleToClickSearchedBook()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            pageProf.SearchItem("Speaking JavaScript");
            pageProf.ClickSeachedBook();
            Assert.AreEqual("ISBN :", pageProf.Isbn.Text);

        }
        [Test]
        [Category("BOOKSTORE")]
        public void VerifyThatUserIsAbleToSortCollectionByClickingAuthor()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            pageProf.ClickAuthor();
            Assert.IsTrue(pageProf.AuthorName.Text.Contains("Axel"));

        }
        [Test]
        [Category("BOOKSTORE")]
        public void VerifyThatCorectBookIsShownAtBookDetailsPage()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass(username, pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            pageProf.SearchItem("git pocket");
            pageProf.ClickGitBook();
            Assert.IsTrue(pageProf.NameOfBookGit.Text.Contains("e"));

        }
        [Test]
        [Category("PROFILE")]
        public void VerifyThatUserIsAbleToDeleteAllBooks()
        {
            MainPage pageMain = new MainPage(driver);
            pageMain.GoTo();
            pageMain.ClickLogin();
            LoginPage pageLogin = new LoginPage(driver);
            pageLogin.EnterUserAndPass("user1", pass);
            pageLogin.ClickLoginButton();
            ProfilePage pageProf = new ProfilePage(driver);
            List<IWebElement> listOfElements = driver.FindElements(By.CssSelector(".element-list.collapse.show")).ToList();
            IWebElement ProfileEle = listOfElements.Where(el => el.Text.Contains("Pro")).FirstOrDefault();
            ProfileEle.Click();
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();
            Thread.Sleep(2000);
            pageProf.ClickDelete();
            Assert.IsTrue(pageProf.DeleteElementVerify.Text.Contains("Delete"));




        }
    }
}