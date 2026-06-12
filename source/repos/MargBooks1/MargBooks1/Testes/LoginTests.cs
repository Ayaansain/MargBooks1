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
    public class MargBooksTests : BaseTest 
    {
        LoginPage login;
        LedgerMasterPage ledger;
       // PurchasePage purchase;

        [SetUp]
        public void TestInit()
        {
            try
            {
                ReportManager.InitReport();

                login = new LoginPage(driver);
                ledger = new LedgerMasterPage(driver);
               // purchase = new PurchasePage(driver);

               login.Login(Config.Username,Config.Password);
             
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
        public void Verify_Ledger_Creation_Flow()
        {
            try
            {
                ledger.OpenMaster();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Open Master",
                    "PASS",
                    "Master menu opened");

                ledger.OpenAccountMaster();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Open AccountMaster",
                    "PASS",
                    "Account Master page opened");

                //Ledger Creation
                ledger.OpenLedger();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Clickoncreate",
                    "PASS",
                    "CreateLedger");

                //PartyName
                ledger.NewPartyName();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Enter Party Name",
                    "PASS",
                    "Party name entered");
                //GroupName
                ledger.GroupNameSelect();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Open GroupName",
                    "PASS",
                    "selected Succesfully");

                //Station name
                ledger.StationName();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Station Name",
                    "PASS",
                    "Station name entered");
                //Ledger mail
                ledger.LedgerMail();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Enter Ledger Mail",
                    "PASS",
                    "Ledger mail entered");
                //Ledger address
                ledger.Ledgeraddress();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Ledger Address1",
                    "PASS",
                    "Ledger address entered");
                ledger.Ledgeraddress2();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Ledger Address2",
                    "PASS",
                    "Ledger address entered");
                ledger.Ledgeraddress3();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Ledger Address3",
                    "PASS",
                    "Ledger address entered");


                ledger.CityEnter();
                Thread.Sleep(2000);
                ReportManager.Log(
                    "Enter City",
                    "PASS",
                    "City entered");
                ledger.PincodeEnter();
                Thread.Sleep(5000);
                ReportManager.Log
                    (" Pincode enter", 
                    "Pass", 
                    "Pinocde successfully");

                ledger.EnterMob();
                Thread.Sleep(2000);
                ReportManager.Log(
                    "Enter Mobile Number",
                    "PASS",
                    "Mobile number entered");

                ledger.EnterGSTDetails();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Select Gst Type",
                    "Pass",
                    "Select Successfully");

                ledger.EnterGSTNumber();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "EnterGSTNumber", 
                    "Pass", 
                    "Entered successfully");

                ledger.SaveGSTDetails();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "save Ledger", 
                    "pass",
                    "Save Ledger successfully");


                ledger.SaveLedger();
                 Thread.Sleep(2000);
                ReportManager.Log(
                    "Save Ledger",
                    "PASS",
                    "Ledger saved successfully");

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
        public void Verify_Ledger_Name_Max_Length()
        {
            try
            {
                ledger.OpenMaster();
                Thread.Sleep(5000);

                ledger.OpenAccountMaster();
                Thread.Sleep(5000);

                ledger.OpenLedger();
                Thread.Sleep(5000);

                string longName =
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";

                ledger.EnterPartyName(longName);

                Thread.Sleep(2000);

                int actualLength = ledger.GetPartyNameLength();

                Console.WriteLine("Actual Length = " + actualLength);

                Assert.That(actualLength, Is.LessThanOrEqualTo(45));

                ReportManager.Log(
                    "Ledger Name Length Validation",
                    "PASS",
                    "Ledger Name length validation successful");
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Ledger Name Length Validation",
                    "FAIL",
                    ex.ToString());

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