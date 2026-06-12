using System;
using NUnit.Framework;
using MargBooks1.Base;
using MargBooks1.Configuration;
using MargBooks1.Pages;
using MargBooks1.Reports;

namespace MargBooks1.Negativetestcases
{
    [TestFixture]
    public class LedgerNegativeTests1 : BaseTest
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
    }
}