using OpenQA.Selenium;
using System.Security.AccessControl;

namespace MargBooks1.Pages
{
    public class SaleBill : Base.BasePage
    {
        public enum DiscountOption
        {
            DontStore,
            ProductSpecial,
            AgencyList
        }
        public SaleBill(IWebDriver driver) : base(driver) { }

        private readonly By SaleMenu          = By.XPath("//a[@id='menu112725066']//span[contains(text(),'Sale')]");
        private readonly By BillBtn           = By.XPath("//ul[@id='menu-2-112725066']//li[1]//a[2]");
        private readonly By SelectLedger      = By.XPath("//input[@id='txtLedgerName11']");
        private readonly By SearchParty       = By.XPath("//input[@id='SearchBox']");
        private readonly By ItemSelectionBar = By.XPath("//input[@id='txt-itemLinkID-0']");
        private readonly By SecondItemSelectionBar = By.XPath("//input[@id='txt-itemLinkID-1']");
        
        private readonly By SearchItemInMaster = By.XPath("//input[@id='searchItems']");
        private readonly By QTY = By.XPath("//input[@id='txt-quantity-0']");
        private readonly By SaleRate = By.XPath("//input[@id='txt-salePurchaseRate-0']");
        private readonly By Dis = By.XPath("//input[@id='txt-discount1-0']");
        private readonly By UpdateDiscountDontStore = By.XPath("//button[@id='dontStore']");
        private readonly By UpdateDiscountProductSpecial = By.XPath("//button[@id='specialRate']");
        private readonly By UpdateDiscountAgencyList = By.XPath("//button[@id='priceList']");
        private readonly By Mobile = By.XPath("//input[contains(@id,'txtptmobile')]");
        private readonly By SearchCustomerList = By.XPath("//input[@id='SearchBox']");
        private readonly By OtherHead = By.XPath("//input[contains(@id,'txt-ledgerLinkID')]");
        private readonly By CustomerName = By.XPath("//input[contains(@id,'txtptname')]");
        private readonly By Address=By.XPath("//input[contains(@id,'txtpatientaddress')]");
        private readonly By SaveBill = By.XPath("//code[normalize-space()='F10 / End']");


        //div[@class='warning p-2']



        public void OpenSale() => Click(SaleMenu);

        public void OpenBill() => Click(BillBtn);

        //(Retail billing without asking ledger name)
        // public void OpenAllledegr()
        //{
        //    GetElement(SelectLedger).SendKeys(Keys.Backspace);
        //} 
        public void OpenSearchPartyBox()
        {
            GetElement(SearchParty)
                .SendKeys("Vinod Medica");

            Thread.Sleep(5000);

            GetElement(SearchParty)
                .SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            GetElement(ItemSelectionBar)
                .SendKeys(Keys.Space);
        }

        public void SearchItemInMasterBox()
        {
            GetElement(SearchItemInMaster)
                .SendKeys("Dolo");
            Thread.Sleep(5000);

            GetElement(SearchItemInMaster)
                .SendKeys(Keys.Enter);
            Thread.Sleep(5000);

        } 

        public void EnterQTY()
        {
            GetElement(QTY)
                .SendKeys("2");
            Thread.Sleep(5000);

            GetElement (QTY).SendKeys(Keys.Enter);
        } 

        public void EnterSaleRate() => Type(SaleRate, "100"+Keys.Enter);
        public void EnterDis(int discount)
        {
            Type(Dis, discount.ToString() + Keys.Enter);
        }

        public void HandleDiscountPopupByValue(int discount)
        {
            if (!IsElementPresent(By.XPath("//div[@class='warning p-2']")))
                return;

            if (discount <= 10)
            {
                ClickUpdateDiscountDontStore();
            }
            else if (discount <= 20)
            {
                ClickUpdateDiscountProductSpecial();
            }
            else
            {
                ClickUpdateDiscountAgencyList();
            }
        }
        private bool IsElementPresent(By by)
        {
            return driver.FindElements(by).Count > 0;
        }
        private void ClickUpdateDiscountProductSpecial()
        {
            GetElement(UpdateDiscountProductSpecial).Click();
        }
        private void ClickUpdateDiscountAgencyList()
        {
            GetElement(UpdateDiscountAgencyList).Click();
         
        }
        private void ClickUpdateDiscountDontStore()
        {
            GetElement(UpdateDiscountDontStore).Click();
            Thread.Sleep(5000);

        }
        public void PressTabKey()
        {
            GetElement(SecondItemSelectionBar).SendKeys(Keys.Tab);
            
        }

        public void EnterMobile()
        {
            Console.WriteLine(
    driver.FindElements(
        By.XPath("//input[contains(@id,'txtptmobile')]")
    ).Count);
            var mobile = GetElement(Mobile);


            Console.WriteLine("Displayed = " + mobile.Displayed);
            Console.WriteLine("Enabled = " + mobile.Enabled);

            mobile.Click();

            Thread.Sleep(2000);

            mobile.SendKeys(Keys.Space);
        }
        //public void EnterMobile()
        //{
        //    GetElement(Mobile).Click();


        //    GetElement(Mobile).SendKeys(Keys.Space);

        //}

        public void EnterCustomerPhone()
        {
            GetElement(SearchCustomerList)
                .SendKeys("9319093101" + Keys.Enter);

           

        }
        

        public void EnterCustomerName()
        {

            Console.WriteLine(
                driver.FindElements(
                    By.XPath("//input[contains(@id,'txtptname')]")
                ).Count);

            var customerName = GetElement(CustomerName);

            Console.WriteLine("Displayed = " + customerName.Displayed);
            Console.WriteLine("Enabled = " +customerName.Enabled);

            customerName.Click();

            Thread.Sleep(1000);
            GetElement(CustomerName)
                .SendKeys(Keys.Enter);


        }

        public void EnterAddress()
        {
            Console.WriteLine(
              driver.FindElements(
                  By.XPath("//input[contains(@id,'txtpatientaddress')]")
              ).Count);

            var address = GetElement(Address);

            Console.WriteLine("Displayed = " + address.Displayed);
            Console.WriteLine("Enabled = " + address.Enabled);

            address.Click();
            GetElement(Address)
                .SendKeys(Keys.Enter);
        }

        public void EnterOtherHead()
        {
            Console.WriteLine(
              driver.FindElements(
                  By.XPath("//input[contains(@id,'txt-ledgerLinkID')]")
              ).Count);
            var otherHead = GetElement(OtherHead);
            Console.WriteLine("Displayed = " + otherHead.Displayed);
            Console.WriteLine("Enabled = " + otherHead.Enabled);
            otherHead.Click();
            GetElement(OtherHead)
                .SendKeys(Keys.Enter);
        }
        public void Billsave() => Click(SaveBill);

        //    // Dropdown open
        //    GetElement(EnterPhone)
        //        .SendKeys(Keys.Space);

        //    // Scroll down 5 times
        //    for (int i = 0; i < 5; i++)
        //    {
        //        GetElement(EnterPhone)
        //            .SendKeys(Keys.ArrowDown);
        //    }

        //    // Select option
        //    GetElement(EnterPhone)
        //        .SendKeys(Keys.Enter);
        //}


        //public void EnterCustName()
        //{
        //    GetElement(EnterCustomerName)
        //        .SendKeys("Sundry Debtors");

        //    // Dropdown open
        //    GetElement(EnterCustomerName)
        //        .SendKeys(Keys.Space);

        //    // Scroll down 5 times
        //    for (int i = 0; i < 1; i++)
        //    {
        //        GetElement(EnterCustomerName)
        //            .SendKeys(Keys.ArrowDown);
        //    }

        //    // Select option
        //    GetElement(EnterCustomerName)
        //        .SendKeys(Keys.Enter);

        //}
    }
}