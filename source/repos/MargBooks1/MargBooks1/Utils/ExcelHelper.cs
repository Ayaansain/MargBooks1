using ClosedXML.Excel;

public static class ExcelHelper
{
    public static LedgerData GetLedgerData(int rowNo)
    {
        string path = @"D:\MargBooks1\LedgerMasterDeatils.xlsx";

        using (var workbook = new XLWorkbook(path))
        {
            var ws = workbook.Worksheet("Sheet1");

            return new LedgerData
            {
                LedgerName = ws.Cell(rowNo, 1).GetString(),
                Address1 = ws.Cell(rowNo, 2).GetString(),
                Address2 = ws.Cell(rowNo, 3).GetString(),
                Address3 = ws.Cell(rowNo, 4).GetString(),
                City = ws.Cell(rowNo, 5).GetString(),
                Pincode = ws.Cell(rowNo, 6).GetString(),
                EnterGSTNum = ws.Cell(rowNo, 7).GetString(),
                MobileNo = ws.Cell(rowNo, 8).GetString(),
                // Country    = ws.Cell(rowNo, 8).GetString(),
                // type       = ws.Cell(rowNo, 9).GetString(),
                // GSTDetails = ws.Cell(rowNo,).GetString(),

            };
        }


    }

    public static ItemDetails GetItemDetails(int row)
    {
        string path = @"D:\MargBooks1\ItemNameDetails.xlsx";

        using (var workbook = new XLWorkbook(path))
        {
            var ws = workbook.Worksheet("Sheet1");

            return new ItemDetails
            {
                ItemName = ws.Cell(row, 1).GetString(),
                Packing = ws.Cell(row, 2).GetString(),
                HSN = ws.Cell(row, 3).GetString(),
                //TaxCategory = ws.Cell(row, 4).GetString(),
                Company = ws.Cell(row, 4).GetString(),
                MRP = ws.Cell(row, 5).GetString(),
                Purcahserate = ws.Cell(row, 6).GetString(),
                Salerate = ws.Cell(row, 7).GetString(),
                FreeScheme = ws.Cell(row, 8).GetString() ,
                FreeQTY=ws.Cell(row, 9).GetString(),
                HSNSACName=ws.Cell(row, 10).GetString(),
            };
        }
    }


    public static ItemCompanyDetails GetItemCompanyDetails(int row)
    {
        string path = @"D:\MargBooks1\ItemComp.xlsx";

        using (var workbook = new XLWorkbook(path))
        {
            var ws = workbook.Worksheet("Sheet1");

            return new ItemCompanyDetails
            {
                CompanyName = ws.Cell(row, 1).GetString(),
                PrintRemark= ws.Cell(row, 2).GetString(),
                InvoicePrintIndex = ws.Cell(row, 3).GetString(),
                ReorderFormula = ws.Cell(row, 4).GetString(),
                ReorderPrefence = ws.Cell(row, 5).GetString(),
                StoreRoom = ws.Cell(row, 6).GetString(),
                DumDays = ws.Cell(row, 7).GetString(),
                MinimumMargin = ws.Cell(row, 8).GetString(),
                Email = ws.Cell(row, 9).GetString(),
                CC = ws.Cell(row, 10).GetString(),
                BCC = ws.Cell(row, 11).GetString(),
                Website = ws.Cell(row, 12).GetString(),
            };
        }
    }
}
