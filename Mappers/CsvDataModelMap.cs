using CsvHelper.Configuration;
public sealed class CsvDataModelMap : ClassMap<CsvDataModel>
{
    public CsvDataModelMap()
    {
        Map(m => m.BusinessUnit).Name("Business Unit");
        Map(m => m.ReceiptMethodID).Name("Receipt Method ID");
        Map(m => m.RemittanceBank).Name("Remittance Bank");
        Map(m => m.RemittanceBankAccount).Name("Remittance Bank Account");
        Map(m => m.ReceiptNumber).Name("Receipt Number");
        Map(m => m.ReceiptAmount).Name("Receipt Amount");
        Map(m => m.ReceiptDate).Name("Receipt Date");
        Map(m => m.AccountingDate).Name("Accounting Date");
        Map(m => m.ConversionDate).Name("Conversion Date");
        Map(m => m.Currency).Name("Currency");
        Map(m => m.ConversionRateType).Name("Conversion Rate Type");
        Map(m => m.ConversionRateString).Name("Conversion Rate");
        Map(m => m.CustomerName).Name("Customer Name");
        Map(m => m.CustomerAccountNumber).Name("Customer Account Number");
        Map(m => m.CustomerSiteNumber).Name("Customer Site Number");
        Map(m => m.InvoiceNumberReference).Name("Invoice number reference");
        Map(m => m.InvoiceAmount).Name("Invoice Amount");
        Map(m => m.Comments).Name("Comments");
        References<TransactionModelMap>(m => m.Transactions);
    }
}

