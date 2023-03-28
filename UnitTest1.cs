using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void aRegistrationTest()
        {
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
            driver.FindElement(By.XPath("//nav[@id='menu']/div/div[2]/div/div[2]/a[2]")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("dafcfsfsdf2222@gmail.com");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("sifra123");
            driver.FindElement(By.Name("password-repeat")).Click();
            driver.FindElement(By.Name("password-repeat")).Clear();
            driver.FindElement(By.Name("password-repeat")).SendKeys("sifra123");
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Dominik");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Skrinjar");
            driver.FindElement(By.Name("telephone")).Click();
            driver.FindElement(By.Name("telephone")).Clear();
            driver.FindElement(By.Name("telephone")).SendKeys("0489 42 75 42");
            driver.FindElement(By.XPath("//button[@name='']")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/main/div[2]/div/div/div[2]/button")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/main/div[2]/div/div/div[2]/button")).Click();
           

        }

        [Test]
        public void bLogoutTest()
        {
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
            driver.FindElement(By.XPath("//nav[@id='menu']/div/div[2]/div/div[2]/button")).Click();
            driver.FindElement(By.LinkText("Log out")).Click();
        }
        [Test]
        public void cInvalidLoginTest2()
        {
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
            driver.FindElement(By.XPath("//nav[@id='menu']/div/div[2]/div/div[2]/a")).Click();
            driver.FindElement(By.Name("username")).Click();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("pero.peric@gmail.com");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("peric");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
        [Test]
        public void dPlayStoreTest3()
        {
            
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
            driver.FindElement(By.XPath("//header[@id='homepage-search']/div/div/a[2]/img")).Click();
            driver.Navigate().GoToUrl("https://play.google.com/store/apps/details?id=com.localtomorrow.bakeronline");
        }
        [Test]
        public void eAppStoreTest3()
        {
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en");
            driver.FindElement(By.XPath("//header[@id='homepage-search']/div/div/a/img")).Click();
            driver.Navigate().GoToUrl("https://apps.apple.com/app/id1460675618");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}