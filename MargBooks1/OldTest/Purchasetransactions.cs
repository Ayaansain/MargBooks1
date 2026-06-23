using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MargBooks1.OldTest
{
    internal class Purchasetransactions
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // locator

        private readonly By purchase = By.XPath("");
        private readonly By Purchasebill = By.XPath("");
        private readonly By Purcahsecreateparty = By.XPath("//span[contains(text(),'Create/F2')]");
        private readonly By partyname = By.XPath("//input[@id='txtlegername']");
        private readonly By Station = By.XPath("//input[@id='ddlstation']");
        private readonly By createStation = By.XPath("//span[contains(text(),'F2 -')]");
        private readonly By Enterstationname = By.XPath("//input[@id='txtStaionName']");
        private readonly By Mobileno = By.XPath("//input[@id='txtMobile']");
        private readonly By save = By.XPath("//button[@id='btn-Save']//span[@class='shortcut ng-star-inserted']");
        private readonly By Closeledgercreate = By.XPath("//div[@id='header-ledgerModal']//div//span[@aria-hidden='true'][normalize-space()='×']");
        private readonly By searchparty = By.XPath("//input[@id='SearchBox']");
        private readonly By enterInvNo = By.XPath("//input[@id='txtentryNo71'].");
        //private readonly By

        public void clickonpurchase()
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(purchase)).Click();

        }

        public void clickonpurcahsebill()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Purchasebill)).Click();
        }

        public void clickonpartycr()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Purcahsecreateparty)).Click();

        }
        public void clickpartyname()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(partyname)).Click();

        }

        public void station()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Station)).Click();
        }
        public void createstation ()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(createStation)).Click();

        }   
        public void EnterstatationName()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Enterstationname)).SendKeys("Azadpur");
        }

        public void Entermobileno()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Mobileno)).Click();
        }

        public void clicksave()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(save)).Click();
        }

        public void clickclosecreateledger()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Closeledgercreate)).Click();

        }
            
    }

}
