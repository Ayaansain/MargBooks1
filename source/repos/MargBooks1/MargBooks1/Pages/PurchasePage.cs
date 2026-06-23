//using OpenQA.Selenium;

//namespace MargBooks1.Pages
//{
//    public class PurchasePage : Base.BasePage
//    {
//        public PurchasePage(IWebDriver driver) : base(driver)
//        {
//        }

//        private readonly By purchaseMenu = By.XPath("//span[contains(text(),'Purchase')]");
//        private readonly By purchaseBill = By.XPath("//a[contains(text(),'Bill')]");
//        private readonly By SearchParty = By.Id("//input[@id='SearchBox']");
//        private readonly By 

//        public void OpenPurchase() => Click(purchaseMenu);

//        public void OpenPurchaseBill() => Click(purchaseBill);

//        public void EnterStation(string name) => Type(stationName, name);

//        public void EnterMobile(string number) => Type(mobile, number);

//        public void Save() => Click(saveBtn);
//    }
//}