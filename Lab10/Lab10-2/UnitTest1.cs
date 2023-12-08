using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Threading;

namespace Lab10_2
{
    public class PageObject
    {
        private IWebDriver driver;

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToHomePage(string url)
        {
            driver.Navigate().GoToUrl(url);
            Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
            Thread.Sleep(3000);
        }

        public void PerformSearch(string searchText)
        {
            IWebElement searchInput = driver.FindElement(By.XPath("//*[@id=\"top-s\"]"));
            searchInput.Click();
            searchInput.SendKeys(searchText);
            Thread.Sleep(2000);
            searchInput.SendKeys(Keys.Enter);
            Thread.Sleep(4000);
            Assert.That(driver.Title, Is.EqualTo($"Результаты поиска по запросу \"{searchText}\". OZ.by"));
        }

        public void ClickOnCategory()
        {
            driver.FindElement(By.XPath("//*[@id=\"fform\"]/div[2]/div[2]/ul/li[2]/a")).Click();
            Thread.Sleep(4000);
        }

        public void AcceptCookies()
        {
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/button[1]")).Click();
            Thread.Sleep(4000);
        }

        public void SelectCategory()
        {
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div/div[2]/div/div[1]/ul/li[2]/ul/li[3]/a")).Click();
            Thread.Sleep(3000);
        }

        public void ApplyFilters()
        {
            driver.FindElement(By.XPath("//*[@id=\"ul_id_producer\"]/li[2]/label/a")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"ul_id_producer\"]/li[3]/label/a")).Click();
            Thread.Sleep(3000);
        }

        public void SetPriceFilter(string price)
        {
            IWebElement elementPriceInput = driver.FindElement(By.XPath("//*[@id=\"inp2_r_cost\"]"));
            IJavaScriptExecutor jsPrice = (IJavaScriptExecutor)driver;
            jsPrice.ExecuteScript("arguments[0].scrollIntoView(true);", elementPriceInput);
            Thread.Sleep(1000);
            elementPriceInput.Click();
            Thread.Sleep(2000);
            elementPriceInput.SendKeys(price);
            Thread.Sleep(3000);
        }

        public void ScrollToElementAndClick()
        {
            IWebElement element = driver.FindElement(By.CssSelector(".filters__searchbtn__btn"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(2000);
            element.Click();
        }

        public void SortResults()
        {
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div/div[2]/div/div[1]/ul/li[1]/div/span"))
                .Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"top_filters__sorter\"]/li[2]/a")).Click();
            Thread.Sleep(2000);
        }

        public void SelectProduct()
        {
            driver.FindElement(By.CssSelector(".product-card__body")).Click();
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div[1]/div/div[1]/div[2]/div[3]/div/div/label/span[1]/span[3]"))
                .Click();
        }
    }

    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private PageObject page;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://oz.by/";
            verificationErrors = new StringBuilder();
            page = new PageObject(driver);
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
        public void TestFind()
        {
            page.NavigateToHomePage(baseURL);
            Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
            Thread.Sleep(3000);

            page.PerformSearch("Картина по номерам");
            Assert.That(driver.Title, Is.EqualTo("Результаты поиска по запросу \"Картина по номерам\". OZ.by"));

            page.ClickOnCategory();
            page.AcceptCookies();
            page.SelectCategory();
            page.ApplyFilters();
            page.SetPriceFilter("45");
            page.ScrollToElementAndClick();
            page.SortResults();
            page.SelectProduct();
        }
    }
}
