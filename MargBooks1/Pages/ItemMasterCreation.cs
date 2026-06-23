using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MargBooks1.Pages
{
    public class ItemMasterCreation:Base.BasePage
    {

        public ItemMasterCreation(IWebDriver driver) : base(driver)

        {
            ItemDetails = ExcelHelper.GetItemDetails(2);
        }

        public ItemDetails ItemDetails { get; set; } = new ItemDetails();

        private readonly By Mastermenu = By.XPath("//span[normalize-space()='Master']");
        private readonly By InventoryMaster = By.XPath("//span[normalize-space()='Inventory Master']");
        private readonly By Item = By.XPath("//ul[@id='menu-1-1-622142206']//li[1]//a[2]");
        private readonly By Itemname = By.Id("txtProduct");
        private readonly By Packing = By.Id("txtPacking");
        private readonly By Unit = By.Id("unit");
        private readonly By UnitDecimal = By.Id("deciaml");
        private readonly By Hsn=By.XPath("//input[@id='hsn']");
        private readonly By CreateHSN = By.XPath("//span[contains(text(),'F2 -')]");
        private readonly By HSNCode = By.Id("inphsncode");
        private readonly By HSNSACName = By.Id("inphsnname");
        private readonly By SaveHSN = By.Id("btn-Save");
        private readonly By TaxCategory = By.Id("taxxCategory");
        private readonly By Company = By.Id("txtcompName");
        private readonly By SearchBoxComp = By.XPath("//input[@id='SearchBox']");
        private readonly By MRP = By.Id("txtmrp");
        private readonly By PurchaseRate = By.Id("txtprate");
        private readonly By SaleRate = By.Id("txtratea");
        private readonly By FreeScheme = By.Id("txtFree");
        private readonly By FreeQTY = By.Id("txtScheme");
        private readonly By ColorType = By.Id("txtcolortype");
        private readonly By SaveItem = By.XPath("//span[normalize-space()='Save']");
       // private readonly By CreateHSNButton = By.Id("");


        public void OpenMaster1() => Click(Mastermenu);
        public void OpenInventory()=>Click(InventoryMaster);
        public void OpenItem()=>Click(Item);

        public void EnterRandomItemName()
        {
            Random rnd = new Random();

            string randomItemName =
                "Item_" + rnd.Next(1000, 999999);

            Type(Itemname, randomItemName);
        }
        public void EnterItemName() => Type(Itemname,ItemDetails.ItemName);

        public void EnterPacking()=>Type(Packing,ItemDetails.Packing);

        public void EnterUnit()
        {
            //Dropdown Open
            GetElement(Unit).SendKeys(Keys.Space);
            
            //For scroll loop chalana hai
            for (int i = 0; i < 5; i++)
            {
                GetElement(Unit).SendKeys(Keys.ArrowDown);
            }
            GetElement(Unit).SendKeys(Keys.Enter);
        }
        public void EnterUnitdecimal()
        {
            //Dropdown Open
            GetElement(UnitDecimal).SendKeys(Keys.Space);

            for(int i = 0;i < 1; i++)
            {
                GetElement(UnitDecimal).SendKeys(Keys.ArrowDown);
            }
            GetElement(UnitDecimal).SendKeys(Keys.Enter);
        }

        public void EnterHSN()
        {
            var hsn = GetElement(Hsn);

            hsn.Click();
            hsn.Clear();

            // Excel se HSN type
            hsn.SendKeys(ItemDetails.HSN);

            // Typeahead dropdown trigger karne ke liye
            Thread.Sleep(1000);
            hsn.SendKeys(Keys.Space);
            hsn.SendKeys(Keys.Backspace);

            Thread.Sleep(2000);

            var options = driver.FindElements(
                By.XPath("//button[contains(@class,'dropdown-item')]")
            );

            Console.WriteLine("Count = " + options.Count);

            bool hsnFound = false;

            foreach (var option in options)
            {
                Console.WriteLine("Option = " + option.Text);

                if (option.Text.Trim() == ItemDetails.HSN.Trim())
                {
                    option.Click();
                    hsnFound = true;
                    break;
                }
            }

            // HSN nahi mili to Create New
            if (!hsnFound)
            {
                Console.WriteLine("HSN Not Found - Creating New HSN");

                Click(CreateHSN);

                Thread.Sleep(1000);

                Type(HSNCode, ItemDetails.HSN+Keys.Tab);

                Type(HSNSACName,ItemDetails.HSNSACName);

                Click(SaveHSN);

             }
        }
       
                public void SelectTaxcategory()
        {
            //Dropdown Open
            GetElement(TaxCategory).SendKeys(Keys.Space);

            //For loop chala kar add karna hai
            for( int i = 0; i<2; i++)
            {
                GetElement(TaxCategory).SendKeys(Keys.ArrowDown);
            }
            GetElement(TaxCategory ).SendKeys(Keys.Enter);

        }

        public void EnterItemCompany() => Type(Company,Keys.Space);
        public void EnterCompanyName()
        {
            Type(SearchBoxComp, ItemDetails.Company + Keys.ArrowDown+Keys.Enter+Keys.Enter);
        }

        public void EnterMRP()=> Type(MRP,ItemDetails.MRP);

        public void EnterPurRate()=>Type(PurchaseRate,ItemDetails.Purcahserate);

        public void EnterSaleRate() => Type(SaleRate, ItemDetails.Salerate);

        public void EnterFreeScheme()=> Type(FreeScheme,ItemDetails.FreeScheme);

        public void EnterFreeQTY() => Type(FreeQTY, ItemDetails.FreeQTY);

        public void ClickOnsave() => Click(SaveItem);
        //public void EnterHSN()
        //{

        //    //Dropdown open
        //    GetElement(Hsn).SendKeys(Keys.Space);

        //    //for scroll 
        //    for( int i = 0; i<4; i++)
        //    {
        //        GetElement(Hsn).SendKeys(Keys.ArrowDown);
        //    }

        //    GetElement(Hsn ).SendKeys(Keys.Enter);
        //}

    }
}
