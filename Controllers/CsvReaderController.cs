using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/csv")]
public class CsvController : ControllerBase
{
    [HttpPost("upload")]
    public IActionResult UploadCsv(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty");

        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            try
            {
                csv.Context.RegisterClassMap<CsvDataModelMap>();

                var records = csv.GetRecords<CsvDataModel>().ToList();

                var jsonResult = records.Select(record => new
                {
                    businessUnit = record.BusinessUnit,
                    receiptMethodID = record.ReceiptMethodID,
                    transactions = new
                    {
                        remittanceBank = record.RemittanceBank,
                        receiptNumber = record.ReceiptNumber,
                        receiptAmount = record.ReceiptAmount,
                        invoiceNumberReference = record.InvoiceNumberReference,
                        invoiceAmount = record.InvoiceAmount
                    },
                    remitanceBankAccount = record.RemittanceBankAccount,
                    receiptDate = record.ReceiptDate,
                    accountingDate = record.AccountingDate,
                    conversionDate = record.ConversionDate,
                    currency = record.Currency,
                    conversionRateType = record.ConversionRateType,
                    conversionRate = record.ConversionRate,
                    customerName = record.CustomerName,
                    customerAccountNumber = record.CustomerAccountNumber,
                    customerSiteNumber = record.CustomerSiteNumber,
                    innoviceAmount = record.InvoiceAmount,
                    comments = record.Comments,
                }).ToList();

                return Ok(jsonResult);
            }
            // if the uploaded csv doesn't match the CsvDataModel (is not the Receipts csv file that has special json conversion) just convert it normally to json
            catch (CsvHelperException ex)
            {

                try
                {
                    var records = csv.GetRecords<dynamic>().ToList();
                    return Ok(records);
                }
                catch (CsvHelperException ex2)
                {

                    Console.WriteLine($"Error parsing CSV file: {ex.Message}");
                    return BadRequest($"Error parsing CSV file: {ex.Message}");
                }

            }
        }
    }
}
