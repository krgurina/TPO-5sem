using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    public class BonusPage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;
        private readonly string baseURL;


        public BonusPage(IWebDriver driver)
        {
            this.driver = driver;
            verificationErrors = new StringBuilder();
            baseURL = "https://oz.by/bonus/";
        }

        public void OpenBonusPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            //Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
        }

        public void ScrollBonusInfo()
        {
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div/main/section[3]/div/div[1]/div[2]/div[1]/h3"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(2000);
            element.Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div/main/section[3]/div/div[1]/div[3]/div[1]/h3")).Click();
            Thread.Sleep(1000);

        }

        public void ScrollBonusRules()
        {
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"top-page\"]/div/main/section[3]/div/a"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(2000);
            element.Click();
            Thread.Sleep(1000);

        }
        //public void AddItemToBasket()
        //{
        //    driver.FindElement(By.CssSelector(".product-card__body")).Click();
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.CssSelector(".b-product-control__btn-container")).Click();
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.CssSelector(".user-bar__cart")).Click();
        //}
    }

}
