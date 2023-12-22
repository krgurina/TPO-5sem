using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
    internal class BacketPage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;
        private readonly string baseURL;

        public BacketPage(IWebDriver driver, StringBuilder verificationErrors)
        {
            this.driver = driver;
            this.verificationErrors = verificationErrors;
        }

        public BacketPage(IWebDriver driver)
        {
            this.driver = driver;
            verificationErrors = new StringBuilder();
            baseURL = "https://oz.by/checkout/#";
        }

        public void OpenBacketPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            //Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
        }

        public void ChangeCount()
        {
            driver.FindElement(By.XPath("//*[@id=\"goods-block\"]/tbody/tr[2]/td[2]/div/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"goods-block\"]/tbody/tr[2]/td[2]/div/div/ul/li[5]/span")).Click();

            //IWebElement usernameInput = driver.FindElement(By.XPath("//*[@id=\"goods-block\"]/tbody/tr[3]/td[2]/div/div/input"));
            //usernameInput.Click();
            //usernameInput.SendKeys(count);
            Thread.Sleep(1000);
        }

        public void SelectItems()
        {
            driver.FindElement(By.XPath("//*[@id=\"goods-block\"]/tbody/tr[6]/td/div/div[1]/label/span/span/input")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"goods-block\"]/tbody/tr[6]/td/div/div[1]/label/span/span/input")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"goods-block\"]/tbody/tr[6]/td/div/div[1]/label/span/span/input")).Click();
            Thread.Sleep(1000);

        }        
        public void InputCode()
        {
            driver.FindElement(By.XPath("//*[@id=\"promoCodeField\"]/div/input")).Click();
            Thread.Sleep(1000);

            IWebElement usernameInput = driver.FindElement(By.XPath("//*[@id=\"promoCodeField\"]/div/input"));
            usernameInput.Click();
            usernameInput.SendKeys("Проверочка");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id=\"promoCodeSubmit\"]")).Click();
            Thread.Sleep(1000);

        }

        public void ChooseDelivery()
        {
            driver.FindElement(By.XPath("//*[@id=\"select-delivery-link\"]/div/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"popup\"]/div/div/div/div/div/div/div/div[1]/div/ul/li[32]/label/div[1]/div[1]")).Click();
            Thread.Sleep(1000);
        }

        public void ChoosePayType()
        {
            driver.FindElement(By.XPath("//*[@id=\"select-payment-link\"]/div/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"popup\"]/div/div/div/div/div/div/div/div[1]/div/ul/li[2]/label/div[1]/div[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"popup\"]/div/div/div/div/div/div/div/footer/div/div/button")).Click();
            Thread.Sleep(1000);
        }

    }
}

