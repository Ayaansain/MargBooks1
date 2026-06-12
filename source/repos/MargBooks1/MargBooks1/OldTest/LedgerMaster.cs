using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MargBooks1.OldTest
{
    public class LedgerMaster
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Locators
        private readonly By sale = By.XPath("//a[@id='menu112725066']//span[contains(text(),'Sale')]");
        private readonly By bill = By.XPath("//ul[@id='menu-2-112725066']//li[1]//a[2]");
        private readonly By partynames = By.XPath("//input[@id='txt-itemLinkID-0']");
        private readonly By selectParty = By.XPath("//input[@id='SearchBox']");
        private readonly By createparty = By.XPath("//span[contains(text(),'Create/F2')]");
        

        public LedgerMaster(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickOnSale()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(sale)).Click();
        }

        public void clickbill()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(bill)).Click();
        }

        public void Clickpartyname()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(partynames)).SendKeys(Keys.Space);
        }
        public void spaceselectparty()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(selectParty)).Click();
        }

        public void Createparty()
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(createparty)).SendKeys("Shailender");
        }

    }
}
