using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Book_Store_app
{
    internal class ProfilePage
    {
        private IWebDriver driver;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //property for user to be verified
        public IWebElement userNameForVerify => driver.FindElement(By.Id("userName-value"));

        //property for logUot
        public IWebElement LogOutButton => driver.FindElement(By.Id("submit"));

        //property for goto BOOKSTORE
        public IWebElement BookStoreButton => driver.FindElement(By.Id("gotoStore"));

        //element za profil
        public IWebElement ProfileElement => driver.FindElement(By.Id("item-3"));


        //element for select a book
        public IWebElement Book => driver.FindElement(By.CssSelector("a[href='/books?book=9781449325862']"));

        //element to add to collection
        public IWebElement AddToCollection => driver.FindElement(By.XPath("//div[@class='text-right fullButton']//button[@id='addNewRecordButton']"));

        //Element for ISBN
        public IWebElement Isbn => driver.FindElement(By.Id("ISBN-label"));

        //Element for SearchBox
        public IWebElement SearchBox => driver.FindElement(By.Id("searchBox"));


        //Element to seach-Java
        public IWebElement SeachJavaBook => driver.FindElement(By.Id("see-book-Speaking JavaScript"));


        //Element to locate Author of the GRID TABLE
        public IWebElement Author => driver.FindElement(By.XPath("//div[contains(text(),'Author')]"));

        //Specific hardcoded author name
        public IWebElement AuthorName => driver.FindElement(By.XPath("//div[normalize-space()='Axel Rauschmayer']"));

        //Element for book GIT
        public IWebElement BookGit => driver.FindElement(By.Id("see-book-Git Pocket Guide"));

        //Element to locate name of the book GIT
        public IWebElement NameOfBookGit => driver.FindElement(By.Id("userName-value"));

        //Element to locate DELETE BUTTON
        public IWebElement DeleteButton => driver.FindElement(By.XPath("//div[@class='text-center button']//button[@id='submit']"));

        //Element to ClickYes on pop up
        public IWebElement YesToDelete => driver.FindElement(By.Id("closeSmallModal-ok"));

        //Element to scrol down to desctription
        public IWebElement Description => driver.FindElement(By.Id("#website-label"));

        //Element for delete od the delete pop up
        public IWebElement DeleteElementVerify => driver.FindElement(By.Id("example-modal-sizes-title-sm"));

        //function for click LogOut
        public void ClickLogOut()
        {
            LogOutButton.Click();
        }

        //function for go to book store
        public void GoToBookStore()
        {
            BookStoreButton.Click();
        }

        //function for click a book
        public void ClickBook()
        {
            Book.Click();
        }

        //function to click add to collection
        public void ClickAddColection()
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("addNewRecordButton")));
            AddToCollection.Click();
        }

        // function for seachbar
        public void SearchItem(string item)
        {
            SearchBox.SendKeys(item);
        }
        //method to click search Java
        public void ClickSeachedBook()
        {
            SeachJavaBook.Click();
        }
        //method to click author
        public void ClickAuthor()
        {
            Author.Click();
        }

        //Click Git BOOK
        public void ClickGitBook()
        {
            BookGit.Click();
        }

        //Function to click Delete
        public void ClickDelete()
        {
            DeleteButton.Click();
        }
        public void ClickYesToDelete()
        {
            YesToDelete.Click();
        }
        
    }
}