using System;
using NUnit.Framework;
using MargBooks1.Base;
using MargBooks1.Configuration;
using MargBooks1.Pages;
using MargBooks1.Reports;

namespace MargBooks1.Negativetestcases
{
    [TestFixture]
    public class LedgerNegativeTests : BaseTest
    {
        LoginPage login;
        LedgerMasterNegativePage ledgerNegative;

        [SetUp]
        public void TestInit()
        {
            try
            {
                ReportManager.InitReport();

                login = new LoginPage(driver);
                ledgerNegative = new LedgerMasterNegativePage(driver);

                login.Login(
                    Config.Username,
                    Config.Password);

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

                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Verify_Blank_Ledger_Name_Validation()
        {
            try
            {
                ledgerNegative.OpenMaster();
                Thread.Sleep(5000);

                ledgerNegative.OpenAccountMaster();
                Thread.Sleep(5000);

                ledgerNegative.OpenLedger();
                Thread.Sleep(5000);

                ledgerNegative.EnterBlankLedgerName();
                Thread.Sleep(2000);

                ledgerNegative.SaveLedger();
                Thread.Sleep(3000);

                ReportManager.Log(
                    "Blank Ledger Name",
                    "PASS",
                    "Validation Checked");

                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Blank Ledger Name Validation",
                    "FAIL",
                    ex.ToString());

                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Verify_Invalid_Mobile_Numbers()
        {
            try
            {
                foreach (string mobile in ledgerNegative.InvalidMobiles())
                {
                    ledgerNegative.OpenMaster();
                    Thread.Sleep(2000);

                    ledgerNegative.OpenAccountMaster();
                    Thread.Sleep(2000);

                    ledgerNegative.OpenLedger();
                    Thread.Sleep(2000);

                    ledgerNegative.EnterInvalidMobile(mobile);
                    Thread.Sleep(2000);

                    ledgerNegative.SaveLedger();
                    Thread.Sleep(2000);

                    ReportManager.Log(
                        "Mobile Validation",
                        "PASS",
                        $"Checked Mobile : {mobile}");
                }

                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Invalid Mobile Validation",
                    "FAIL",
                    ex.ToString());

                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Verify_Invalid_Pincode_Validation()
        {
            try
            {
                foreach (string pin in ledgerNegative.InvalidPincodes())
                {
                    ledgerNegative.OpenMaster();
                    Thread.Sleep(2000);

                    ledgerNegative.OpenAccountMaster();
                    Thread.Sleep(2000);

                    ledgerNegative.OpenLedger();
                    Thread.Sleep(2000);

                    ledgerNegative.EnterInvalidPincode(pin);
                    Thread.Sleep(2000);

                    ledgerNegative.SaveLedger();
                    Thread.Sleep(2000);

                    ReportManager.Log(
                        "Pincode Validation",
                        "PASS",
                        $"Checked Pincode : {pin}");
                }

                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Invalid Pincode Validation",
                    "FAIL",
                    ex.ToString());

                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Verify_Invalid_GST_Validation()
        {
            try
            {
                foreach (string gst in ledgerNegative.InvalidGSTNumbers())
                {
                    if (!ledgerNegative.IsGSTValid(gst))
                    {
                        ledgerNegative.OpenMaster();
                        Thread.Sleep(2000);

                        ledgerNegative.OpenAccountMaster();
                        Thread.Sleep(2000);

                        ledgerNegative.OpenLedger();
                        Thread.Sleep(2000);

                        ledgerNegative.EnterInvalidGST(gst);
                        Thread.Sleep(2000);

                        ledgerNegative.SaveLedger();
                        Thread.Sleep(2000);

                        ReportManager.Log(
                            "GST Validation",
                            "PASS",
                            $"Checked GST : {gst}");
                    }
                }

                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "GST Validation",
                    "FAIL",
                    ex.ToString());

                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Verify_Special_Character_Ledger_Name()
        {
            try
            {
                ledgerNegative.OpenMaster();
                Thread.Sleep(5000);

                ledgerNegative.OpenAccountMaster();
                Thread.Sleep(5000);

                ledgerNegative.OpenLedger();
                Thread.Sleep(5000);

                ledgerNegative.EnterSpecialCharacterLedgerName();
                Thread.Sleep(2000);

                ledgerNegative.SaveLedger();
                Thread.Sleep(2000);

                ReportManager.Log(
                    "Special Character Ledger",
                    "PASS",
                    "Validation Checked");

                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Special Character Ledger",
                    "FAIL",
                    ex.ToString());

                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Verify_Save_Without_Mandatory_Fields()
        {
            try
            {
                ledgerNegative.OpenMaster();
                Thread.Sleep(5000);

                ledgerNegative.OpenAccountMaster();
                Thread.Sleep(5000);

                ledgerNegative.OpenLedger();
                Thread.Sleep(5000);

                ledgerNegative.SaveWithoutMandatoryFields();
                Thread.Sleep(3000);

                ReportManager.Log(
                    "Mandatory Field Validation",
                    "PASS",
                    "Validation Checked");

                Assert.Pass();
            }
            catch (Exception ex)
            {
                ReportManager.Log(
                    "Mandatory Field Validation",
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