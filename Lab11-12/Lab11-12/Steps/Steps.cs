using Lab11_12.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab11_12.Driver;
using Lab11_12.Pages;
using Lab11_12.Pages.Lab11_12.Pages;
using OpenQA.Selenium;

namespace Lab11_12.Steps
{
    public class Steps
    {
        IWebDriver driver;

        private  HomePage homePage;
        private  BooksPage booksPage;
        private  ArtLiteraturePage artLiteraturePage;
        private  ClassicsPage classicsPage;
        private  FantasticPage fantasticPage;
        private  LoginPage loginPage; 
        private BacketPage backetPage; 
        private BonusPage bonusPage; 

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
            MaximizeBrowserWindow();
        }

        private void MaximizeBrowserWindow()
        {
            driver.Manage().Window.Maximize();
        }
        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        //public void ChooseCategory()
        //{
        //    HomePage homePage = new HomePage(driver);
        //    homePage.GoToPage();
        //}

        public void GoToBooksPage()
        {
            homePage = new HomePage(driver);
            homePage.OpenHomePage();
            booksPage = homePage.GoToBooks();
        }

        public void SelectLiterature()
        {
            artLiteraturePage = booksPage.SelectArtLiterature();
        }


        public void SelectClassics()
        {
            classicsPage = artLiteraturePage.SelectClassics();
        }


        public void OpenClassics()
        {
            classicsPage = new ClassicsPage(driver);
            classicsPage.OpenClassicsPage();
        }        
        public void OpenHome()
        {
            homePage = new HomePage(driver);
            homePage.OpenHomePage();
        }

        public void AcceptCookies()
        {
            homePage.AcceptCookies();
        }

        public void AddToBacket()
        {
            classicsPage.AddItemToBasket();
        }
        public void AddBookToBacket()
        {
            fantasticPage.AddItemToBasket();
        }

        public void OpenLogin()
        {
            loginPage = new LoginPage(driver);
            loginPage.OpenLoginPage();
        }

        public void LogIn()
        {
            var loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.EnterCredentialsAndSubmit("rwqrdkdyhdcbdhbd@gmail.com", "что-то вводим");
        }

        public void LogInSucsess()
        {
            var loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.EnterCredentialsAndSubmit("", "");
        }

        public void OpenFantastics()
        {
            fantasticPage = new FantasticPage(driver);
            fantasticPage.OpenFantasticPage();
        }

        public void OpenBacket()
        {
            backetPage = new BacketPage(driver);
            backetPage.OpenBacketPage();
        }

        public void ChangeCount()
        {
            backetPage.ChangeCount();
        }
        public void SelectBasketItems()
        {
            backetPage.SelectItems();
        }

        public void InputCode()
        {
            backetPage.InputCode();
        }

        public void Search()
        {
            homePage.PerformSearch("Картина по номерам");
            homePage.ClickOnCategory();
            homePage.SelectCategory();

        }

        public void PriceFilter()
        {
            homePage.SetPriceFilter("45");
            homePage.SetFilters();

        }

        public void SortResults()
        {
            homePage.SortResults();
            homePage.PriceSortResults();
            homePage.RatingSortResults();
            homePage.DataSortResults();
            homePage.PopularSortResults();
        }
        
        public void FindBonus()
        {
            homePage.ScrollBonus();
        }        
        public void GetBonusInfo()
        {
            bonusPage=new BonusPage(driver);
            bonusPage.ScrollBonusInfo();
            bonusPage.ScrollBonusRules();
        }

        public void ChooseOrderDetails()
        {
            backetPage.ChooseDelivery();
            backetPage.ChoosePayType();
        }













        //    loginPage.ClickLoginLink();
        //    loginPage.EnterCredentialsAndSubmit("rwqrdkdyhdcbdhbd@gmail.com", "что-то вводим");








        //private readonly HomePage homePage;
        //private  BooksPage booksPage;
        //private  ArtLiteraturePage artLiteraturePage;
        //private  ClassicsPage classicsPage;
        //private  LoginPage loginPage;

        //    public Steps()
        //    {
        //        booksPage = new BooksPage();
        //        artLiteraturePage = new ArtLiteraturePage();
        //        classicsPage = new ClassicsPage();
        //        loginPage = new LoginPage();
        //    }

        //    public void InitBrowser()
        //    {
        //        driver = Driver.DriverInstance.GetInstance();
        //    }

        //    public void CloseBrowser()
        //    {
        //        Driver.DriverInstance.CloseBrowser();
        //    }



        //    public void GoToBooksPage()
        //    {
        //        booksPage = homePage.GoToBooks();
        //    }
        //    public string GetBooksPageTitle()
        //    {
        //        return booksPage.GetPageTitle();
        //    }
        //    public void SelectArtLiterature()
        //    {
        //        artLiteraturePage = booksPage.SelectArtLiterature();
        //    }

        //    public void AddClassicsToBasket()
        //    {
        //        classicsPage.AddItemToBasket();
        //    }

        //    public void Login(string username, string password)
        //    {
        //        loginPage.ClickLoginLink();
        //        loginPage.EnterCredentialsAndSubmit(username, password);
        //    }

        //    public void PerformCompletePurchase(string username, string password)
        //    {
        //        OpenHomePage();
        //        GoToBooksPage();
        //        SelectArtLiterature();
        //        AddClassicsToBasket();
        //        Login(username, password);
        //    }

        //    public void PerformInvalidLogin(string invalidUsername, string invalidPassword)
        //    {
        //        OpenHomePage();
        //        Login(invalidUsername, invalidPassword);
        //    }
        //}
    }
}