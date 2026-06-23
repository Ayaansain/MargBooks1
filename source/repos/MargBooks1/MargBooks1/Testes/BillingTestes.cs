using MargBooks1.Configuration;
using MargBooks1.Helpers;
using MargBooks1.Pages;
using MargBooks1.Reports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static MargBooks1.Pages.SaleBill;


namespace MargBooks1.Testes
{
    [TestFixture]
    
    
    public class BillingTestes :Base.BaseTest
    {

        LoginPage login;
        LedgerMasterPage ledger;
        SaleBill SaleBill;

        [SetUp]
        public void TestInit()
        {
            try
            {

                VideoRecorder.StartRecording

               (TestContext.CurrentContext.Test.Name);

                ReportManager.InitReport();


                ReportManager.InitReport();
                login = new LoginPage(driver);
                ledger = new LedgerMasterPage(driver);
                SaleBill= new SaleBill(driver);
                login.Login(Config.Username, Config.Password);
                Thread.Sleep(20000);
                ReportManager.Log(
                    "Login",
                    "PASS",
                    "Login successful", "Image");
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Login",
                    "FAIL", "Image",
                    ex.ToString());
                Console.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Create_Sale_Bill_Flow()
        {
            try
            {
                SaleBill.OpenSale();
                Thread.Sleep(2000);
                ReportManager.Log(
                    "Open Sale Menu",
                    "PASS",
                    "Sale Menu Opened", "Image");

                SaleBill.OpenBill();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Open Sale Bill",
                    "PASS",
                    "Sale Bill Opened", "Image");

                //Ye yab call hoga jab party default select hogi
                //SaleBill.OpenAllledegr();
                //Thread.Sleep(2000);
                //ReportManager.Log(
                //    "Open All Ledger",
                //    "PASS",
                //    "All Ledger Opened", "Image");

                SaleBill.OpenSearchPartyBox();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Open Search Party Box",
                    "PASS",
                    "Search Party Box Opened", "Image");

                SaleBill.SearchItemInMasterBox();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Search Item In Master Box",
                    "PASS",
                    "Item Search Box Opened", "Image");

                SaleBill.EnterQTY();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Quantity",
                    "PASS",
                    "Quantity Entered", "Image");

                SaleBill.EnterSaleRate();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Sale Rate",
                    "PASS",
                    "Sale Rate Entered", "Image");

                int discount = 5;

                SaleBill.EnterDis(discount);
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Enter Discount",
                    "PASS",
                    $"Discount {discount} Entered",
                    "Image");

                SaleBill.HandleDiscountPopupByValue(discount);
                Thread.Sleep(5000);


                ReportManager.Log(
                    "Discount Popup",
                    "PASS",
                    "Dont Store Selected",
                    "Image");

                SaleBill.PressTabKey();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Press Tab Key",
                    "PASS",
                    "Tab Key Pressed", "Image");

                SaleBill.EnterMobile();
                Thread.Sleep(5000);
                ReportManager.Log(
                     "Enter Phone Number",
                     "PASS",
                     "Phone Number Entered", "Image");

                SaleBill.EnterCustomerPhone();
                Thread.Sleep(5000);
                ReportManager.Log(
                     "Enter Customer Phone",
                     "PASS",
                     "Customer Phone Number Entered", "Image");
              SaleBill.EnterCustomerName();
                ReportManager.Log(
                     "Enter Customer Name",
                     "PASS",
                     "Customer Name Entered", "Image");
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                SaleBill.EnterAddress();
                ReportManager.Log(
                     "Enter Address",
                     "PASS",
                     "Address Entered", "Image");

                SaleBill.EnterOtherHead();
                ReportManager.Log(
                     "Enter Other Head",
                     "PASS",
                     "Other Head Entered", "Image");

                SaleBill.Billsave();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Save Bill",
                    "PASS",
                    "Bill Saved Successfully", "Image");
                //    "Enter Phone Number",
                //    "PASS",
                //    "Phone Number Entered", "Image");
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Login",
                    "FAIL", "Image",
                    ex.ToString());

                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
   
            }
        
}

        [TearDown]
        public void Cleanup()
        {

            VideoRecorder.StopRecording();

            ReportManager.FlushReport();
            ReportManager.FlushReport();
        }

    }

}
