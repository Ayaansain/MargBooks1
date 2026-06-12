using OpenQA.Selenium;

namespace MargBooks1.Pages
{
    public class LoginPage : Base.BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private readonly By username = By.XPath("//input[@id='userid']");
        private readonly By signIn = By.XPath("//button[@id='SIGNin']");
        private readonly By password = By.XPath("//input[@id='password']");
        private readonly By loginBtn = By.XPath("//button[@type='submit']");

        public void Login(string user, string pass)
        {

            GetElement(username).SendKeys(user);
            Thread.Sleep(5000);
            
            GetElement(signIn).Click();
            Thread.Sleep(5000);
            GetElement(password).SendKeys(pass);
            Thread.Sleep(5000);
            GetElement(loginBtn).Click();
        }
    }
}