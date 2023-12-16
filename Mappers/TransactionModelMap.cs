using CsvHelper.Configuration;
public sealed class TransactionModelMap : ClassMap<TransactionModel>
{
    public TransactionModelMap()
    {
        Map(m => m.RemittanceBank).Name("Remittance Bank");
        Map(m => m.ReceiptNumber).Name("Receipt Number");
        Map(m => m.ReceiptAmount).Name("Receipt Amount");
        Map(m => m.InvoiceNumberReference).Name("Invoice number reference");
        Map(m => m.InvoiceAmount).Name("Invoice Amount");
    }
}