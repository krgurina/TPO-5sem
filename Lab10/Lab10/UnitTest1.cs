using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System;
using System.Text;

namespace Lab9
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;
        private readonly string baseURL;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            verificationErrors = new StringBuilder();
            baseURL = "https://oz.by/";
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
        }

        public BooksPage GoToBooks()
        {
            driver.FindElement(By.LinkText("Книги")).Click();
            Assert.That(driver.Title, Is.EqualTo("Книги : купить в Беларуси в интернет магазине — OZ.by"));
            return new BooksPage(driver, verificationErrors);
        }
    }

    public class BooksPage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;

        public BooksPage(IWebDriver driver, StringBuilder verificationErrors)
        {
            this.driver = driver;
            this.verificationErrors = verificationErrors;
        }

        public ArtLiteraturePage SelectArtLiterature()
        {
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/main/div[1]/section/div[2]/div/div/div/ul/li[3]/a/div[1]/div")).Click();
            Assert.That(driver.Title, Is.EqualTo("Художественная литература: новинки и бестселлеры, авторы, издательства. Купить книги в Минске — OZ.by"));
            return new ArtLiteraturePage(driver, verificationErrors);
        }
    }

    public class ArtLiteraturePage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;

        public ArtLiteraturePage(IWebDriver driver, StringBuilder verificationErrors)
        {
            this.driver = driver;
            this.verificationErrors = verificationErrors;
        }

        public ClassicsPage SelectClassics()
        {
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/main/div[1]/section/div[2]/div/div/div/ul/li[4]/a/div[1]/div")).Click();
            Assert.That(driver.Title, Is.EqualTo("Классическая литература: мировая и русская в интернет-магазине OZ.by"));
            return new ClassicsPage(driver, verificationErrors);
        }
    }

    public class ClassicsPage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;

        public ClassicsPage(IWebDriver driver, StringBuilder verificationErrors)
        {
            this.driver = driver;
            this.verificationErrors = verificationErrors;
        }

        public void AddItemToBasket()
        {
            driver.FindElement(By.CssSelector(".product-card__body")).Click();
            driver.FindElement(By.CssSelector(".b-product-control__btn-container")).Click();
            driver.FindElement(By.CssSelector(".user-bar__cart")).Click();
        }
    }

    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        public class LoginPage
        {
            private readonly IWebDriver driver;
            private readonly StringBuilder verificationErrors;

            public LoginPage(IWebDriver driver, StringBuilder verificationErrors)
            {
                this.driver = driver;
                this.verificationErrors = verificationErrors;
            }

            public void ClickLoginLink()
            {
                driver.FindElement(By.XPath("//*[@id=\"loginFormLoginEmailLink\"]")).Click();
            }

            public void EnterCredentialsAndSubmit(string username, string password)
            {
                IWebElement usernameInput = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div[2]/div[1]/div[1]/input"));
                usernameInput.Click();
                usernameInput.SendKeys(username);
                Thread.Sleep(1000);

                IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div[2]/div[1]/div[2]/input"));
                passwordInput.Click();
                passwordInput.SendKeys(password);
                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/button")).Click();
            }
        }

        [Test]
        public void TestAddItemToBasket()
        {
            var homePage = new HomePage(driver);
            homePage.OpenHomePage();

            var booksPage = homePage.GoToBooks();

            var artLiteraturePage = booksPage.SelectArtLiterature();

            var classicsPage = artLiteraturePage.SelectClassics();

            classicsPage.AddItemToBasket();

            var loginPage = new LoginPage(driver, verificationErrors);
            loginPage.ClickLoginLink();
            loginPage.EnterCredentialsAndSubmit("rwqrdkdyhdcbdhbd@gmail.com", "что-то вводим");
        }
    }
}
