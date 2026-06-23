using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MargBooks1.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}