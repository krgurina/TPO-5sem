using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab11_12.Driver;

namespace Lab11_12.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly StringBuilder verificationErrors;
        private readonly string baseURL;


        public LoginPage(IWebDriver driver, StringBuilder verificationErrors)
        {
            this.driver = driver;
            this.verificationErrors = verificationErrors;
        }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            verificationErrors = new StringBuilder();
            baseURL = "https://oz.by/personal/login.phtml?back_uri=https%3A%2F%2Foz.by%2Fbusiness%2F%3Frefsource%3Dgoogle_stationary%26utm_source%3Dgoogle%26utm_medium%3Dcpc%26utm_campaign%3D%7Bcampaign_id%7D%26utm_content%3D%7Bad_id%7D%26utm_term%3D%26gad_source%3D1%26gclid%3DEAIaIQobChMI8a7tqNWjgwMViILCCh2gageJEAAYASAAEgIHh_D_BwE";
        }
        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            //Assert.That(driver.Title, Is.EqualTo("OZ.by — интернет-магазин. Книги, игры, косметика, товары для дома, творчества, подарки, продукты. Доставка по Беларуси."));
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
}