using System;
using NUnit.Framework;
using MargBooks1.Base;
using MargBooks1.Configuration;
using MargBooks1.Pages;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.DevTools.V143.DOM;
using MargBooks1.Utils.Reports;

namespace MargBooks1.Tests
{
    [TestFixture]
    public class MargBooksTests1 : BaseTest
    {
        LoginPage login;
        ItemMasterCreation ItemCreation;
        ItemCompanyMaster CompanyMasterCreation;

        [SetUp]
        public void TestInit()
        {
            try
            {
                ReportManager.InitReport();

                login = new LoginPage(driver);
                ItemCreation=new ItemMasterCreation(driver);
                CompanyMasterCreation=new ItemCompanyMaster(driver);
            


                login.Login(Config.Username, Config.Password);

                Thread.Sleep(20000);

                ReportManager.Log(
                    "Login",
                    "PASS",
                    "Login successful");
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Login",
                    "FAIL",
                    ex.ToString());

                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
            }


        }
                
        [Test]
        public void Verify_Item_Creation_Flow()
        {
            try
            {
                ItemCreation.OpenMaster1();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Open Master",
                    "PASS",
                    "Master menu opened");

                ItemCreation.OpenInventory();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Open AccountMaster",
                    "PASS",
                    "Account Master page opened");

                //Ledger Creation
                ItemCreation.OpenItem();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Clickoncreate",
                    "PASS",
                    "CreateLedger");

                //PartyName
                ItemCreation.EnterItemName();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Enter Party Name",
                    "PASS",
                    "Party name entered");
                //GroupName
                
               ItemCreation.EnterPacking();
                Thread.Sleep(5000);

               

                ItemCreation.EnterUnit();
                Thread.Sleep(5000);

                ItemCreation.EnterUnitdecimal();
                Thread.Sleep(5000);

                ItemCreation.EnterHSN();
                Thread.Sleep(5000);

                
                ItemCreation.SelectTaxcategory();
                Thread.Sleep(5000);

                ItemCreation.EnterItemCompany();
                Thread.Sleep(5000);

                ItemCreation.EnterCompanyName();
                Thread.Sleep(5000);

                ItemCreation.EnterMRP();
                Thread.Sleep(5000);

                ItemCreation.EnterPurRate();
                Thread.Sleep(5000);

                ItemCreation.EnterSaleRate();
                Thread.Sleep(5000);

                ItemCreation.EnterFreeScheme();
                Thread.Sleep(5000);

                ItemCreation.EnterFreeQTY();
                Thread.Sleep(5000);

                ItemCreation.ClickOnsave();
                Thread.Sleep(5000);


                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "LedgerMasterCreation",
                    "FAIL",
                    ex.ToString());

                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
            }
        }

        [Test]

        public void Create_Item_Company() 
        {
            try
            {
                CompanyMasterCreation.OpenMasterMenu();
                Thread.Sleep(5000);
                ReportManager.Log("OpenMaster", "Pass", "Master Open Successfully");

                CompanyMasterCreation.OpenInventory();
                Thread.Sleep(5000);
                ReportManager.Log("OpenInventory", "Pass", "Inventory master Open Successfully");

                CompanyMasterCreation.OpenCompany();
                Thread.Sleep(5000);
                ReportManager.Log("Open CompanyCreation", "Pass", "Open Company Creation Successfully");

                CompanyMasterCreation.EnterCompanyName();
                Thread.Sleep(5000);
                ReportManager.Log("Enter Company Name", "Pass", "Company Name Successfully Enter");

                CompanyMasterCreation.OpenMoreInfo();
                Thread.Sleep(5000);
                ReportManager.Log("Open More Info", "Pass", "OpenMore Info successfully");

                CompanyMasterCreation.EnterPrintRemark();
                Thread.Sleep(5000);
                ReportManager.Log("Print Remark", "Pass", "Print Remark Successfully Enter");

                CompanyMasterCreation.SelectStatus();
                Thread.Sleep(5000);
                ReportManager.Log("Status","Pass","Status Select Successfully");

                CompanyMasterCreation.EnterReorderPreference();
                Thread.Sleep(5000);
                ReportManager.Log("Enter Reorder Pre", "Pass", "Reorder pre successfully Enter");

                CompanyMasterCreation.EnterStoreRoom();
                Thread.Sleep(5000);
                ReportManager.Log("Store", "Pass", "Store Room Enter successfully");

                CompanyMasterCreation.ClickProhibit();
                Thread.Sleep(5000);
                ReportManager.Log("Prohibit", "Pass", "Item Prohibit or not selection successfully");

                CompanyMasterCreation.EnterPrintIndex();
                Thread.Sleep(5000);
                ReportManager.Log("Print Index", "Pass", "Print index enter successfully");

                CompanyMasterCreation.EnterDumDays();
                Thread.Sleep(5000);
                ReportManager.Log("DumpDays", "Pass", "Enter Dump Days Successfully");

                CompanyMasterCreation.EnterReorderFormula();
                Thread.Sleep(5000);
                ReportManager.Log("Reorder Formula", "Pass", "Enter Reorder Formula successfully");

                CompanyMasterCreation.EnterMinimumMargin();
                Thread.Sleep(5000);
                ReportManager.Log("Enter MinimumMargin", "Pass", "Margin Enter Successfully");

                CompanyMasterCreation.SaveCompany();
                Thread.Sleep(5000);
                ReportManager.Log("Save", "Pass", "Company Created Successfully");


                Assert.Pass();

            }
            catch (Exception ex) 
            {

                ReportManager.Log(
                    "LedgerMasterCreation",
                    "FAIL",
                    ex.ToString());

                Console.WriteLine(ex.Message);

                Assert.Fail(ex.Message);
            }

        }

        [TearDown]
        public void Cleanup()
        {
            ReportManager.FlushReport();
        }
    }
}