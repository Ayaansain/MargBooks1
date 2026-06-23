using NUnit.Framework;
using OpenQA.Selenium;
using MargBooks1.Drivers;
using MargBooks1.Configuration;

namespace MargBooks1.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver();
            driver.Navigate().GoToUrl(Config.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}