using OpenQA.Selenium;

namespace MargBooks1.Negativetestcases
{
    public class LedgerMasterNegativePage : Base.BasePage
    {
        public LedgerMasterNegativePage(IWebDriver driver) : base(driver)
        {
        }

        #region Locators

        private readonly By MasterMenu = By.XPath("//span[normalize-space()='Master']");
        private readonly By AccountMaster = By.XPath("//span[normalize-space()='Accounts Master']");
        private readonly By CreateLedger = By.XPath("//ul[@id='menu-1-1-688399954']//li[1]//a[2]");

        private readonly By PartyName = By.XPath("//input[@id='txtlegername']");
        private readonly By MobileNo = By.XPath("//input[@id='txtMobile']");
        private readonly By Pincode = By.XPath("//input[@id='txtPostalCode']");
        private readonly By EnterGSTNum = By.XPath("//input[@id='txtGSTNo']");
        private readonly By address1 = By.XPath("//input[@id='txtaddress1']");
        private readonly By SaveButton = By.XPath("//span[normalize-space()='Save']");

        #endregion

        #region Navigation

        public void OpenMaster() => Click(MasterMenu);

        public void OpenAccountMaster() => Click(AccountMaster);

        public void OpenLedger() => Click(CreateLedger);

        #endregion

        #region Negative Ledger Name

        public void EnterBlankLedgerName()
        {
            Type(PartyName, "");
        }

        public void EnterSpecialCharacterLedgerName()
        {
            Type(PartyName, "@@@###$$$");
        }

        public void EnterNumericLedgerName()
        {
            Type(PartyName, "123456789");
        }

        public void EnterLongLedgerName()
        {
            string longName = new string('A', 150);
            Type(PartyName, longName);
        }

        #endregion

        #region Negative Mobile

        public void EnterInvalidMobile(string mobile)
        {
            Type(MobileNo, mobile);
        }

        public bool IsMobileValid(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                return false;

            if (mobile.Length != 10)
                return false;

            foreach (char ch in mobile)
            {
                if (!char.IsDigit(ch))
                    return false;
            }

            return true;
        }

        #endregion

        #region Negative Pincode

        public void EnterInvalidPincode(string pin)
        {
            Type(Pincode, pin);
        }

        public bool IsPincodeValid(string pin)
        {
            if (string.IsNullOrWhiteSpace(pin))
                return false;

            if (pin.Length != 6)
                return false;

            foreach (char ch in pin)
            {
                if (!char.IsDigit(ch))
                    return false;
            }

            return true;
        }

        #endregion

        #region Negative GST

        public void EnterInvalidGST(string gst)
        {
            Type(EnterGSTNum, gst);
        }

        public bool IsGSTValid(string gst)
        {
            if (string.IsNullOrWhiteSpace(gst))
                return false;

            if (gst.Length != 15)
                return false;

            foreach (char ch in gst)
            {
                if (!char.IsLetterOrDigit(ch))
                    return false;
            }

            return true;
        }

        #endregion

        #region Address Validation

        public void EnterBlankAddress()
        {
            Type(address1, "");
        }

        public bool IsAddressValid(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;

            return true;
        }

        #endregion

        #region Save Actions

        public void SaveLedger()
        {
            Click(SaveButton);
        }

        public void SaveWithoutMandatoryFields()
        {
            Click(SaveButton);
        }

        #endregion

        #region Data Driven Negative Validation

        public string[] InvalidMobiles()
        {
            return new string[]
            {
                "",
                "123",
                "ABCDE12345",
                "123456789012",
                "@@@@@@@@"
            };
        }

        public string[] InvalidPincodes()
        {
            return new string[]
            {
                "",
                "12",
                "ABCDE",
                "1234567",
                "@@@@@"
            };
        }

        public string[] InvalidGSTNumbers()
        {
            return new string[]
            {
                "",
                "123",
                "@@@@@@@",
                "ABCDE",
                "123456789123456789"
            };
        }

        #endregion
    }
}