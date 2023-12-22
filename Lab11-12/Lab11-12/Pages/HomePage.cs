using Lab11_12.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    namespace Lab11_12.Pages
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
                //Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
            }

            public BooksPage GoToBooks()
            {
                driver.FindElement(By.LinkText("Книги")).Click();
                Assert.That(driver.Title, Is.EqualTo("Книги : купить в Беларуси в интернет магазине — OZ.by"));
                return new BooksPage(driver, verificationErrors);
            }

            public void PerformSearch(string searchText)
            {
                IWebElement searchInput = driver.FindElement(By.XPath("//*[@id=\"top-s\"]"));
                searchInput.Click();
                searchInput.SendKeys(searchText);
                Thread.Sleep(2000);
                searchInput.SendKeys(Keys.Enter);
                Thread.Sleep(4000);
                //Assert.That(driver.Title, Is.EqualTo($"Результаты поиска по запросу \"{searchText}\". OZ.by"));
            }

            public void AcceptCookies()
            {
                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/button[1]")).Click();
                Thread.Sleep(4000);
            }

            public void ClickOnCategory()
            {
                driver.FindElement(By.XPath("//*[@id=\"fform\"]/div[2]/div[2]/ul/li[2]/a")).Click();
                Thread.Sleep(4000);
            }

            public void SelectCategory()
            {
                driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div/div[2]/div/div[1]/ul/li[2]/ul/li[3]/a")).Click();
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

            public void SetFilters()
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
                Thread.Sleep(1000);
            }

            public void PopularSortResults()
            {
                driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div/div[2]/div/div[1]/ul/li[1]/div/span"))
                    .Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id=\"top_filters__sorter\"]/li[2]/a")).Click();
                Thread.Sleep(1000);
            }           
            public void DataSortResults()
            {
                driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div/div[2]/div/div[1]/ul/li[1]/div/span"))
                    .Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id=\"top_filters__sorter\"]/li[3]/a")).Click();
                Thread.Sleep(1000);
            }            
            public void PriceSortResults()
            {
                driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div/div[2]/div/div[1]/ul/li[1]/div/span"))
                    .Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id=\"top_filters__sorter\"]/li[4]/a")).Click();
                Thread.Sleep(1000);
            }            

            public void RatingSortResults()
            {
                driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div[2]/div/div/div[2]/div/div[1]/ul/li[1]/div/span"))
                    .Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id=\"top_filters__sorter\"]/li[6]/a")).Click();
                Thread.Sleep(1000);
            }

            public void ScrollBonus()
            {
                IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[2]/div[1]/ul[2]/li[4]"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                Thread.Sleep(2000);
                element.Click();
            }
        }
    }
}
