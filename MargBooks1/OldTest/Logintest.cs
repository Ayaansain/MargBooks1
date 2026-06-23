using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MargBooks1.OldTest
{
    public class LoginTest : IDisposable
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://accounts.margbooks.com/login");

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Enterusername("9319093101");
            loginPage.clicksignin();
            loginPage.Enterpassword("Holi#2244");
            loginPage.Clicklogin();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(d => d.Url.Contains("dashboard"));

        }

        [Test]
        public void CreateBill()
        {
            LedgerMaster master = new LedgerMaster(driver);
            master.ClickOnSale();
            master.clickbill();
            master.Clickpartyname();
            master.clickbill();
        }

        [TearDown]
        public void TearDown()
        {
            Dispose();
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}