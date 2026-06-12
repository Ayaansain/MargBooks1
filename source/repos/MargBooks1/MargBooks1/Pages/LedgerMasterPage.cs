//using MargBooks1.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using MargBooks1.Configuration;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace MargBooks1.Pages
{
    public class LedgerMasterPage : Base.BasePage
    {
        public LedgerMasterPage(IWebDriver driver) : base(driver) 
        
        {
            LedgerData = ExcelHelper.GetLedgerData(2);
        }

       
        public LedgerData LedgerData { get; set; } = new LedgerData();
        

        private readonly By MasterMenu = By.XPath("//span[normalize-space()='Master']");
        private readonly By AccountMaster = By.XPath("//span[normalize-space()='Accounts Master']");
        private readonly By CreateLedger = By.XPath("//ul[@id='menu-1-0-688399954']//li[1]//a[2]");
        private readonly By PartyName = By.XPath("//input[@id='txtlegername']");
        private readonly By GroupName = By.XPath("//input[@id='drpAccountGroup']");
        private readonly By EnterStationName = By.XPath("//input[@id='ddlstation']");
        private readonly By ledgerMailto = By.XPath("//input[@id='txtMailTo']");
        private readonly By address1 = By.XPath("//input[@id='txtaddress1']");
        private readonly By address2 = By.XPath("//input[@id='txtaddress2']");
        private readonly By address3 = By.XPath("//input[@id='txtaddress3']");
        private readonly By Country = By.XPath("//input[@id='ddlCountryLinkID']");
        private readonly By City = By.XPath("//input[@id='ddlCity']");
        private readonly By Pincode = By.XPath("//input[@id='txtPostalCode']");
        private readonly By GSTDetails = By.XPath("//select[@id='ddlLedgerType']");
        private readonly By EnterGSTNum = By.XPath("//input[@id='txtGSTNo']");
        private readonly By SaveGST = By.XPath("//button[@id='btnYes']");
        private readonly By BillMethod = By.XPath("//select[@id='ddlBalancingMethod']");
        // private readonly By ledgerType = By.XPath("//select[@id='ddlLedgerType']");
        private readonly By MobileNo=By.XPath("//input[@id='txtMobile']");
        private readonly By SaveButton = By.XPath("//span[normalize-space()='Save']");
        public void OpenMaster() => Click(MasterMenu);

        public void OpenAccountMaster() => Click(AccountMaster);

        public void OpenLedger() => Click(CreateLedger);

        public void NewPartyName() => Type(PartyName, LedgerData.LedgerName + Keys.Backspace);

        //Ledger ke naam 45 chacrator se jayda check karne wala method
        public void EnterPartyName(string ledgerName)
        {
            Type(PartyName, ledgerName);
        }

        public int GetPartyNameLength()
        {
            return GetElement(PartyName)
                .GetAttribute("value")
                .Length;
        }

        // Yaha par khatam hai 45 Charctor wala method
        public void GroupNameSelect()
        {
            
            // Dropdown open
            GetElement(GroupName)
                .SendKeys(Keys.Space);

            // Scroll down 5 times
            for (int i = 0; i < 37; i++)
            {
                GetElement(GroupName)
                    .SendKeys(Keys.ArrowDown);
            }

            // Select option
            GetElement(GroupName)
                .SendKeys(Keys.Enter);
        }


        public void StationName()
        {

            // Dropdown open
            GetElement(EnterStationName)
                .SendKeys(Keys.Space);

            // Scroll down 5 times
            for (int i = 0; i < 2; i++)
            {
                GetElement(EnterStationName)
                    .SendKeys(Keys.ArrowDown);
            }

            // Select option
            GetElement(EnterStationName)
                .SendKeys(Keys.Enter);
        }
           public void LedgerMail() => GetElement(ledgerMailto).SendKeys(Keys.Enter);
            
           public void  Ledgeraddress()=> Type(address1,LedgerData.Address1+Keys.Tab);

           public void Ledgeraddress2() => Type(address2, LedgerData.Address2 + Keys.Tab);

           public void Ledgeraddress3() => Type(address3,LedgerData.Address3 + Keys.Tab+Keys.Tab+Keys.Tab);
        
        public void CountryEnter()
        {
            //GetElement
            GetElement(Country)
                .SendKeys(Keys.Space);

            //Scroll down 5 times
            for (int i = 0; i < 2; i++)
            {
                GetElement(Country)
                    .SendKeys(Keys.ArrowDown);
            }


            GetElement (Country).SendKeys(Keys.Enter);
        }

        public void CityEnter() => Type(City,LedgerData.City + Keys.Tab);

        public void PincodeEnter() => Type(Pincode,LedgerData.Pincode + Keys.Tab);

        public void EnterMob() => Type(MobileNo,LedgerData.MobileNo+Keys.Tab);


        public void EnterGSTDetails()
        {
            GetElement(GSTDetails).SendKeys(Keys.Space);

            for (int i = 0; i < 1; i++)
            {
                GetElement(GSTDetails).SendKeys(Keys.ArrowDown);
            }

            GetElement(GSTDetails).SendKeys(Keys.Enter);
        }

        public void EnterGSTNumber() => Type(EnterGSTNum, LedgerData.EnterGSTNum);

        public void SaveGSTDetails() => Click(SaveGST);
        public void SaveLedger() => Click(SaveButton);


    }
}
