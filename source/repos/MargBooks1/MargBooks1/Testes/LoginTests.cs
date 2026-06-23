using MargBooks1.Base;
using MargBooks1.Configuration;
using MargBooks1.Helpers;
using MargBooks1.Pages;
using MargBooks1.Reports;
using MargBooks1.Utils;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V143.DOM;
using System;
using System.Security.Cryptography.X509Certificates;

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
                VideoRecorder.StartRecording
                    
               (TestContext.CurrentContext.Test.Name);

                ReportManager.InitReport();

                login = new LoginPage(driver);
                ledger = new LedgerMasterPage(driver);
               // purchase = new PurchasePage(driver);

               login.Login(Config.Username,Config.Password);
             
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
        public void Verify_Ledger_Creation_Flow()
        {
            try
            {
                ledger.OpenMaster();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Open Master",
                    "PASS",
                    "Master menu opened", "Image");
                string screenshotPath1 = ScreenshotHelper.Capture(driver,"OpenMaster");
                

                ledger.OpenAccountMaster();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Open AccountMaster",
                    "PASS",
                    "Account Master page opened", "Image");

                string screenshotPath2 = ScreenshotHelper.Capture(driver, "OpenAccountMaster");

                //Ledger Creation
                ledger.OpenLedger();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Clickoncreate",
                    "PASS",
                    "CreateLedger", "Image");

                string screenshotPath3 = ScreenshotHelper.Capture(driver, "OpenLedger");

                //PartyName
                ledger.NewPartyName();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Enter Party Name",
                    "PASS",
                    "Party name entered", "Image");

                string screenshotPath4 = ScreenshotHelper.Capture(driver, "NewPartyName");
                //GroupName
                ledger.GroupNameSelect();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Open GroupName",
                    "PASS",
                    "selected Succesfully", "Image");

                string screenshotPath5 = ScreenshotHelper.Capture(driver, "GroupNameSelect");
                //Station name
                ledger.StationName();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Station Name",
                    "PASS",
                    "Station name entered", "Image");

                string screenshotPath6 = ScreenshotHelper.Capture(driver, "StationName");
                //Ledger mail
                ledger.LedgerMail();
                Thread.Sleep(5000);

                ReportManager.Log(
                    "Enter Ledger Mail",
                    "PASS",
                    "Ledger mail entered", "Image");

                string screenshotPath7= ScreenshotHelper.Capture(driver, "Ledegrmail");
                //Ledger address
                ledger.Ledgeraddress();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Ledger Address1",
                    "PASS",
                    "Ledger address entered", "Image");
                string screenshotPath8 = ScreenshotHelper.Capture(driver, "Ledger");

                ledger.Ledgeraddress2();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Ledger Address2",
                    "PASS",
                    "Ledger address entered", "Image");
                ledger.Ledgeraddress3();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Enter Ledger Address3",
                    "PASS",
                    "Ledger address entered", "Image");


                ledger.CityEnter();
                Thread.Sleep(2000);
                ReportManager.Log(
                    "Enter City",
                    "PASS",
                    "City entered", "Image");
                ledger.PincodeEnter();
                Thread.Sleep(5000);
                ReportManager.Log
                    (" Pincode enter", 
                    "Pass", 
                    "Pinocde successfully", "Image");

                ledger.EnterMob();
                Thread.Sleep(2000);
                ReportManager.Log(
                    "Enter Mobile Number",
                    "PASS",
                    "Mobile number entered", "Image");

                ledger.EnterGSTDetails();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "Select Gst Type",
                    "Pass",
                    "Select Successfully", "Image");

                ledger.EnterGSTNumber();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "EnterGSTNumber", 
                    "Pass", 
                    "Entered successfully", "Image");

                ledger.SaveGSTDetails();
                Thread.Sleep(5000);
                ReportManager.Log(
                    "save Ledger", 
                    "pass",
                    "Save Ledger successfully", "Image");


                ledger.SaveLedger();
                 Thread.Sleep(2000);
                ReportManager.Log(
                    "Save Ledger",
                    "PASS",
                    "Ledger saved successfully","Image");

                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "LedgerMasterCreation",
                    "FAIL","Image",
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
                    "Ledger Name length validation successful","Image");
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Ledger Name Length Validation",
                    "FAIL","Image",
                    ex.ToString());

                Assert.Fail(ex.Message);
            }
        }
        [Test]
        public void Verify_Random_Ledger_Creation_Flow()
        {
            try
            {
                ledger.OpenMaster();
                Thread.Sleep(5000);

                string ss1 = ScreenshotHelper.Capture(driver, "OpenMaster");
                ReportManager.Log(
                    "Open Master",
                    "PASS",
                    "Master menu opened",
                    ss1);

                ledger.OpenAccountMaster();
                Thread.Sleep(5000);

                string ss2 = ScreenshotHelper.Capture(driver, "OpenAccountMaster");
                ReportManager.Log(
                    "Open Account Master",
                    "PASS",
                    "Account Master page opened",
                    ss2);

                ledger.OpenLedger();
                Thread.Sleep(5000);

                string ss3 = ScreenshotHelper.Capture(driver, "OpenLedger");
                ReportManager.Log(
                    "Open Ledger",
                    "PASS",
                    "Ledger page opened",
                    ss3);

                ledger.EnterRandomPartyName();
                Thread.Sleep(5000);

                string ss4 = ScreenshotHelper.Capture(driver, "RandomPartyName");
                ReportManager.Log(
                    "Enter Random Party Name",
                    "PASS",
                    "Random party name entered",
                    ss4);

                ledger.GroupNameSelect();
                Thread.Sleep(5000);

                string ss5 = ScreenshotHelper.Capture(driver, "GroupName");
                ReportManager.Log(
                    "Group Name",
                    "PASS",
                    "Group selected successfully",
                    ss5);

                ledger.StationName();
                Thread.Sleep(5000);

                string ss6 = ScreenshotHelper.Capture(driver, "StationName");
                ReportManager.Log(
                    "Station Name",
                    "PASS",
                    "Station selected successfully",
                    ss6);

                ledger.LedgerMail();
                Thread.Sleep(5000);

                string ss7 = ScreenshotHelper.Capture(driver, "LedgerMail");
                ReportManager.Log(
                    "Ledger Mail",
                    "PASS",
                    "Ledger mail processed",
                    ss7);

                ledger.Ledgeraddress();
                Thread.Sleep(5000);

                string ss8 = ScreenshotHelper.Capture(driver, "Address1");
                ReportManager.Log(
                    "Address1",
                    "PASS",
                    "Address1 entered",
                    ss8);

                ledger.Ledgeraddress2();
                Thread.Sleep(5000);

                string ss9 = ScreenshotHelper.Capture(driver, "Address2");
                ReportManager.Log(
                    "Address2",
                    "PASS",
                    "Address2 entered",
                    ss9);

                ledger.Ledgeraddress3();
                Thread.Sleep(5000);

                string ss10 = ScreenshotHelper.Capture(driver, "Address3");
                ReportManager.Log(
                    "Address3",
                    "PASS",
                    "Address3 entered",
                    ss10);

                ledger.CityEnter();
                Thread.Sleep(5000);

                string ss11 = ScreenshotHelper.Capture(driver, "City");
                ReportManager.Log(
                    "City",
                    "PASS",
                    "City entered",
                    ss11);

                ledger.PincodeEnter();
                Thread.Sleep(5000);

                string ss12 = ScreenshotHelper.Capture(driver, "Pincode");
                ReportManager.Log(
                    "Pincode",
                    "PASS",
                    "Pincode entered",
                    ss12);

                ledger.EnterMob();
                Thread.Sleep(5000);

                string ss13 = ScreenshotHelper.Capture(driver, "Mobile");
                ReportManager.Log(
                    "Mobile",
                    "PASS",
                    "Mobile entered",
                    ss13);

                ledger.EnterGSTDetails();
                Thread.Sleep(5000);

                string ss14 = ScreenshotHelper.Capture(driver, "GSTDetails");
                ReportManager.Log(
                    "GST Details",
                    "PASS",
                    "GST type selected",
                    ss14);

                ledger.EnterGSTNumber();
                Thread.Sleep(5000);

                string ss15 = ScreenshotHelper.Capture(driver, "GSTNumber");
                ReportManager.Log(
                    "GST Number",
                    "PASS",
                    "GST number entered",
                    ss15);

                ledger.SaveGSTDetails();
                Thread.Sleep(5000);

                string ss16 = ScreenshotHelper.Capture(driver, "SaveGST");
                ReportManager.Log(
                    "Save GST",
                    "PASS",
                    "GST details saved",
                    ss16);

                ledger.SaveLedger();
                Thread.Sleep(5000);

                string ss17 = ScreenshotHelper.Capture(driver, "SaveLedger");
                ReportManager.Log(
                    "Save Ledger",
                    "PASS",
                    "Random ledger created successfully",
                    ss17);

                Assert.Pass();
            }
            catch (Exception ex)
            {
                string ss18 = ScreenshotHelper.Capture(driver, "RandomLedgerFailed");

               

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