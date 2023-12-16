public class CsvDataModel
{
    public string BusinessUnit { get; set; }
    public string ReceiptMethodID { get; set; }
    public string RemittanceBank { get; set; }
    public string RemittanceBankAccount { get; set; }
    public string ReceiptNumber { get; set; }
    public decimal ReceiptAmount { get; set; }
    public string ReceiptDate { get; set; }
    public string AccountingDate { get; set; }
    public string ConversionDate { get; set; }
    public string Currency { get; set; }
    public string ConversionRateType { get; set; }

    public string ConversionRateString { get; set; }

    public decimal? ConversionRate
    {
        get
        {
            if (string.IsNullOrEmpty(ConversionRateString))
                return null;

            return decimal.Parse(ConversionRateString);
        }
    }
    public string CustomerName { get; set; }
    public string CustomerAccountNumber { get; set; }
    public string CustomerSiteNumber { get; set; }
    public string InvoiceNumberReference { get; set; }
    public decimal InvoiceAmount { get; set; }
    public string Comments { get; set; }

    public TransactionModel Transactions { get; set; }

    public TransactionModel ToTransactionModel()
    {
        return new TransactionModel
        {
            RemittanceBank = RemittanceBank,
            ReceiptNumber = ReceiptNumber,
            ReceiptAmount = ReceiptAmount,
            InvoiceNumberReference = InvoiceNumberReference,
            InvoiceAmount = InvoiceAmount
        };
    }
}
