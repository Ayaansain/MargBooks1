using DocumentFormat.OpenXml.Wordprocessing;

public class LedgerData
{
    public string LedgerName { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string City { get; set; }
    public string Pincode { get; set; }
    public string MobileNo { get; set; }
   // public string type {  get; set; }
    public string Country { get; set; }
    public string GSTDetails { get; set; }

    public string EnterGSTNum {  get; set; }


}

public class ItemDetails
{

    public string ItemName { get; set; }

    public string Packing { get; set; }

    public string HSN { get; set; }

    public string HSNSACName {  get; set; }

    public string TaxCategory { get; set; }

    public string Company { get; set; }

    public string MRP { get; set; }

    public string Purcahserate { get; set; }

    public string Salerate { get; set; }


    public string FreeScheme { get; set; }

    public string FreeQTY {  get; set; }

}

public class ItemCompanyDetails
{
    public string CompanyName {  get; set; }

    public string PrintRemark { get; set; }


    public string InvoicePrintIndex { get; set; }


    public string ReorderFormula { get; set; }


    public string ReorderPrefence { get; set; }


    public string StoreRoom { get; set; }


    public string DumDays  { get; set; }


    public string MinimumMargin {  get; set; }

    public string Email {  get; set; }

    public string CC { get; set; }


    public string BCC { get; set; }

    public string Website { get; set; }

}

public class SaleBillDetails
{
    public int Date { get; set; }
    public int BillNo { get; set; }
    public string LedgerName { get; set; }
    public string ItemName { get; set; }
    public string QTY { get; set; }
    public string SaleRate { get; set; }
    public string Discount { get; set; }
    public string Mobile { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string OtherHead { get; set; }
    public string Unit1 { get; set; }
    public string Unit2 { get; set; }
    public string BillDiscount { get; set; }
    public string Packing { get; set; }
    public string HSN { get; set; }
    public string TaxCategory { get; set; }
    public string Company { get; set; }
    public string MRP { get; set;} }