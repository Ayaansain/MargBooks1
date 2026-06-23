using System;
using NUnit.Framework;
using MargBooks1.Base;
using MargBooks1.Configuration;
using MargBooks1.Pages;
using MargBooks1.Reports;

namespace MargBooks1.Negativetestcases
{
    [TestFixture]
    public class LedgerGSTinValidation : BaseTest
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
    }
}