using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MargBooks1.Configuration
{
    public class LedgerLocater
    {
       // public readonly By MasterMenu = By.Id("//span[normalize-space()='Master']");
        private readonly By AccountMaster = By.Id("//span[normalize-space()='Accounts Master']");
        private readonly By CreateLedger = By.Id("//ul[@id='menu-1-1-688399954']//li[1]//a[2]");
        private readonly By PartyName = By.Id("//input[@id='txtlegername']");
        private readonly By GroupName = By.Id("//input[@id='drpAccountGroup']");
        private readonly By EnterStationName = By.Id("//input[@id='ddlstation']");
        private readonly By ledgerMailto = By.Id("//input[@id='txtMailTo']");
        private readonly By address1 = By.Id("//input[@id='txtaddress1']");
        private readonly By address2 = By.Id("//input[@id='txtaddress2']");
        private readonly By address3 = By.Id("//input[@id='txtaddress3']");
        private readonly By Country = By.Id("//input[@id='ddlCountryLinkID']");
        private readonly By City = By.Id("//input[@id='ddlCity']");
        private readonly By Pincode = By.Id("//input[@id='txtPostalCode']");
        private readonly By GSTDetails = By.Id("//select[@id='ddlLedgerType']");
        private readonly By EnterGSTNum = By.Id("//input[@id='txtGSTNo']");
        private readonly By SaveGST = By.Id("//button[@id='btnYes']");
        private readonly By BillMethod = By.Id("//select[@id='ddlBalancingMethod']");
        // private readonly By ledgerType = By.Id("//select[@id='ddlLedgerType']");
        private readonly By MobileNo = By.Id("//input[@id='txtMobile']");
        private readonly By SaveButton = By.Id("//span[normalize-space()='Save']");
    }
}
