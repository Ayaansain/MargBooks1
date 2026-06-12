using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MargBooks1.Base
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        // Constructor
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(40));
        }

        public IWebElement GetElement(By locator)
        {
            wait.Until(
                ExpectedConditions.ElementExists(locator));

            return driver.FindElement(locator);
        }

        public void Click(By locator)
        {
            GetElement(locator).Click();
        }

        public void Type(By locator, string text)
        {
            GetElement(locator).Clear();
            GetElement(locator).SendKeys(text);
        }
    }
}