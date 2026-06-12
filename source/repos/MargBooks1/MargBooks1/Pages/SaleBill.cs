using OpenQA.Selenium;
using System.Security.AccessControl;

namespace MargBooks1.Pages
{
    public class SaleBill : Base.BasePage
    {
        public SaleBill(IWebDriver driver) : base(driver) { }

        private readonly By SaleMenu          = By.XPath("//a[@id='menu112725066']//span[contains(text(),'Sale')]");
        private readonly By BillBtn           = By.XPath("//ul[@id='menu-2-112725066']//li[1]//a[2]");
        private readonly By SelectLedger      = By.XPath("//input[@id='txtLedgerName11']");
        private readonly By SearchParty       = By.XPath("//input[@id='txtLedgerName11']");
        private readonly By EnterPhone        = By.XPath("//input[@id='txtptmobile11']");
        private readonly By EnterCustomerName = By.XPath("//input[@id='txtptname11']");

        public void OpenSale() => Click(SaleMenu);

        public void OpenBill() => Click(BillBtn);

        public void OpenAllledegr() => Click(SelectLedger);

        public void OpenSearchPartyBox() => Type(SearchParty, "AhujaMedical" + Keys.Enter);

        public void EnterPhoneNumber()
        {
            GetElement(EnterPhone)
                .Click();
                

            // Dropdown open
            GetElement(EnterPhone)
                .SendKeys(Keys.Space);

            // Scroll down 5 times
            for (int i = 0; i < 5; i++)
            {
                GetElement(EnterPhone)
                    .SendKeys(Keys.ArrowDown);
            }

            // Select option
            GetElement(EnterPhone)
                .SendKeys(Keys.Enter);
        }


        public void EnterCustName()
        {
            GetElement(EnterCustomerName)
                .SendKeys("Sundry Debtors");

            // Dropdown open
            GetElement(EnterCustomerName)
                .SendKeys(Keys.Space);

            // Scroll down 5 times
            for (int i = 0; i < 1; i++)
            {
                GetElement(EnterCustomerName)
                    .SendKeys(Keys.ArrowDown);
            }

            // Select option
            GetElement(EnterCustomerName)
                .SendKeys(Keys.Enter);

        }
    }
}