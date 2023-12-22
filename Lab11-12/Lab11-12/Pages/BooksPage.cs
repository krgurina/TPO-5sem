using Lab11_12.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Pages
{
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
}
