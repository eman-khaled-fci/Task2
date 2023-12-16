public class TransactionModel
{
    public string RemittanceBank { get; set; }
    public string ReceiptNumber { get; set; }
    public decimal ReceiptAmount { get; set; }
    public string InvoiceNumberReference { get; set; }
    public decimal InvoiceAmount { get; set; }
}