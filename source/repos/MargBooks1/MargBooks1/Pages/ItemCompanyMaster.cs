using OpenQA.Selenium;

namespace MargBooks1.Pages
{
    public class ItemCompanyMaster : Base.BasePage
    {

        public ItemCompanyMaster(IWebDriver driver) : base(driver)
        {
            ItemCompanyDetails = ExcelHelper.GetItemCompanyDetails(3);
        }
        public ItemCompanyDetails ItemCompanyDetails { get; set; }
           = new ItemCompanyDetails();

        private readonly By MasterMenu = By.XPath("//span[normalize-space()='Master']");
        private readonly By InventoryMaster = By.XPath("//span[normalize-space()='Inventory Master']");
        private readonly By ItemCompany = By.XPath("//ul[@id='menu-1-1-622142206']//li[3]//a[2]");
        private readonly By ItemCompanyName = By.XPath("//input[@id='txtCName']");
        private readonly By MoreOption = By.XPath("//span[@class='mks-custom-checkbox custom-control-label']");
        private readonly By PrintRemark = By.XPath("//input[@id='txtRemark']");
        private readonly By Status = By.XPath("//select[@id='drpContinued']");
        private readonly By ReorderPreferance = By.XPath("//input[@id='txtReorderPref']");
        private readonly By StoreRoom = By.XPath("//input[@id='txtStoreNo']");
        private readonly By Prohibit = By.XPath("//select[@id='drpProhibit']");
        private readonly By InvoicePrintIndex = By.XPath("//input[@id='txtbillprint']");
        private readonly By DumpDays = By.XPath("//input[@id='txtDumpdays']");
        private readonly By ReorderFormula = By.XPath("//input[@id='txtReorderFormula']");
        private readonly By MinimumMargin = By.XPath("//input[@id='txtMinmargin']");
        private readonly By EmailBtn = By.XPath("//button[@id='btnAddMore']");
        private readonly By EMain = By.XPath("//input[@id='txtEmain']");
        private readonly By ECC = By.XPath("//input[@id='txtEcc']");
        private readonly By EBCC = By.XPath("//input[@id='txtEbcc']");
        private readonly By EWebsite = By.XPath("//input[@id='txtWebsite']");
        private readonly By F10Update = By.XPath("//span[normalize-space()='Update']");
        private readonly By SaveBtn = By.XPath("//button[@id='btn-Save']//span[@class='shortcut ng-star-inserted']");
        private readonly By F9ClearBtn = By.XPath("//span[normalize-space()='Clear']");
        private readonly By ClearYes = By.XPath("//button[@id='btnYes']");
        private readonly By ClearNo = By.XPath("//button[@id='btnNo']");
        


        public void OpenMasterMenu() => Click(MasterMenu);

        public void OpenInventory() => Click(InventoryMaster);

        public void OpenCompany() => Click(ItemCompany);

        public void EnterCompanyName() => Type(ItemCompanyName, ItemCompanyDetails.CompanyName);

        public void OpenMoreInfo() => Click(MoreOption);

        public void EnterPrintRemark()=> Type(PrintRemark,ItemCompanyDetails.PrintRemark);

        public void SelectStatus()
        {
            GetElement(Status).SendKeys(Keys.Space);

            for (int i = 0; i < 1; i++) 
            {
                GetElement(Status).SendKeys(Keys.ArrowDown);
            }

            GetElement(Status).SendKeys(Keys.Enter);
        }
        public void EnterReorderPreference()=> Type(ReorderPreferance,ItemCompanyDetails.ReorderPrefence);

        public void EnterStoreRoom()=> Type(StoreRoom,ItemCompanyDetails.StoreRoom);

        public void ClickProhibit()
        {
            GetElement(Prohibit).SendKeys(Keys.Space);

            for (var i = 0; i < 1; i++)
            {
                GetElement(Prohibit).SendKeys(Keys.ArrowDown);
            }

            GetElement(Prohibit).SendKeys(Keys.Enter);
        }


        public void EnterPrintIndex() => Type(InvoicePrintIndex, ItemCompanyDetails.InvoicePrintIndex);

        public void EnterDumDays() => Type(DumpDays, ItemCompanyDetails.DumDays);
        
        public void EnterReorderFormula() => Type(ReorderFormula,ItemCompanyDetails.ReorderFormula);

        public void EnterMinimumMargin()=> Type(MinimumMargin,ItemCompanyDetails.MinimumMargin);

        public void ClickEmailBtn() => Click(EmailBtn);

        public void EnterEMain() => Type(EMain, ItemCompanyDetails.Email);

        public void EnterECC() => Type(ECC, ItemCompanyDetails.CC);

        public void EnterEBcc() => Type(EBCC, ItemCompanyDetails.BCC);

        public void EnterEWebsite() => Type(EWebsite,ItemCompanyDetails.Website);

        public void ClickonF10Update() => Click(F10Update);

        public void SaveCompany() => Click(SaveBtn);

    }
}