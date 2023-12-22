using Lab11_12.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
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
}
