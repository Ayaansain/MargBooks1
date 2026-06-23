//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using System;
//using System.Security.AccessControl;

//namespace MargBooks1
//{
//    public class ItemMaster
//    {
//        private readonly IWebDriver driver;
//        private readonly WebDriverWait wait;

//        // Locators 
//        private readonly By EnterItem = By.XPath("//input[@id='txtProduct']");
//        private readonly By Packing = By.XPath("//input[@id='txtPacking']");
//        private readonly By Unit1st = By.XPath("//input[@id='unit']");
//        private readonly By Hsn = By.XPath("//input[@id='hsn']");
//        private readonly By HsnCr = By.XPath("//span[contains(text(),'F2 -')]");
        
        


//        public ItemMaster(IWebDriver driver)
//        {
//            this.driver = driver;
//            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        public void ClickOnSale()
//        {
//            wait.Until(ExpectedConditions.ElementToBeClickable(sale)).Click();
//        }

//        public void clickbill()
//        {
//            wait.Until(ExpectedConditions.ElementToBeClickable(bill)).Click();
//        }

//        public void Clickpartyname()
//        {
//            wait.Until(ExpectedConditions.ElementToBeClickable(partynames)).SendKeys(Keys.Space);
//        }
//        public void spaceselectparty()
//        {
//            wait.Until(ExpectedConditions.ElementToBeClickable(selectParty)).Click();
//        }

//        public void Createparty()
//        {

//            wait.Until(ExpectedConditions.ElementToBeClickable(createparty)).SendKeys("Shailender");
//        }

//    }
//}
