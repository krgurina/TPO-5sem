using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Firefox;

namespace Lab9
{
    public class Tests
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            baseURL = "https://oz.by/";
            verificationErrors = new StringBuilder();

        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                Thread.Sleep(5000);
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void TestAddItemToBasket()
        {
            driver.Navigate().GoToUrl(baseURL);
            Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
           
            driver.FindElement(By.LinkText("Книги")).Click();
            Assert.That(driver.Title, Is.EqualTo("Книги : купить в Беларуси в интернет магазине — OZ.by"));

            //художественная литература
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/main/div[1]/section/div[2]/div/div/div/ul/li[3]/a/div[1]/div")).Click();
            Assert.That(driver.Title, Is.EqualTo("Художественная литература: новинки и бестселлеры, авторы, издательства. Купить книги в Минске — OZ.by"));

            //классика
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/main/div[1]/section/div[2]/div/div/div/ul/li[4]/a/div[1]/div")).Click();
            Assert.That(driver.Title, Is.EqualTo("Классическая литература: мировая и русская в интернет-магазине OZ.by"));

            driver.FindElement(By.CssSelector(".product-card__body")).Click();

            driver.FindElement(By.CssSelector(".b-product-control__btn-container")).Click();
            driver.FindElement(By.CssSelector(".user-bar__cart")).Click();

            driver.FindElement(By.XPath("//*[@id=\"loginFormLoginEmailLink\"]")).Click();

            IWebElement searchInputLogin = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div[2]/div[1]/div[1]/input"));
            searchInputLogin.Click();
            searchInputLogin.SendKeys("rwqrdkdyhdcbdhbd@gmail.com");
            Thread.Sleep(1000);

            IWebElement searchInputPassword = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/div[2]/div[1]/div[2]/input"));
            searchInputPassword.Click();
            searchInputPassword.SendKeys("что-то вводим");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/button")).Click();

        }
    }
}