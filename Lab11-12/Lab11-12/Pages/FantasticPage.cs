using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class FantasticPage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;
        private readonly string baseURL;

        public FantasticPage(IWebDriver driver, StringBuilder verificationErrors)
        {
            this.driver = driver;
            this.verificationErrors = verificationErrors;
        }

        public FantasticPage(IWebDriver driver)
        {
            this.driver = driver;
            verificationErrors = new StringBuilder();
            baseURL = "https://oz.by/books/topic1112887.html?availability=1;2";
        }

        public void OpenFantasticPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            //Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
        }

        public void AddItemToBasket()
        {
            driver.FindElement(By.CssSelector(".product-card__body")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".b-product-control__btn-container")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".user-bar__cart")).Click();
        }
    }
}

