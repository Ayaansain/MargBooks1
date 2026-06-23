using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MargBooks1.OldTest
{
    public class LoginPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        private By username = By.XPath("//input[@id='userid']");
        private By signin = By.XPath("//button[@id='SIGNin']");
        private By password = By.XPath("//input[@id='password']");
        private By loginbtn = By.XPath("//button[@type='submit']");

        // Action methods with Explicit Wait

        public void Enterusername(string user)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(username)).SendKeys(user);
        }


        public void clicksignin()
        {

            wait.Until(ExpectedConditions.ElementIsVisible(signin)).Click();
        }
        public void Enterpassword(string pass)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(password)).SendKeys(pass);
        }

        public void Clicklogin()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loginbtn)).Click();
            Thread.Sleep(120000);
        }


        // Combined action
        public void login(string user, string pass)
        {
            Enterusername(user);
            Enterpassword(pass);
            Clicklogin();
        }

        
    }
}