using Microsoft.Extensions.Configuration;
using Sage300API.SDK.Core;
using Sage300toX3.ConsoleApp;
using SageX3.SDK.Core;
using SageX3.SDK.Models;
using SageX3.SDK.Services;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .Build();

var sage300Options = configuration
    .GetSection("Sage300")
    .Get<Sage300Options>()
    ?? throw new InvalidOperationException("Missing Sage300 configuration section.");

var sageX3Options = configuration
    .GetSection("SageX3")
    .Get<SageX3Options>()
    ?? throw new InvalidOperationException("Missing SageX3 configuration section.");

var migrationOptions = configuration
    .GetSection("Migration")
    .Get<MigrationOptions>()
    ?? new MigrationOptions();

sageX3Options.Validate();

Console.WriteLine("Sage 300 -> Sage X3 Migration");
Console.WriteLine($"Sage 300 Company : {sage300Options.Company}");
Console.WriteLine($"Sage X3 PoolAlias : {sageX3Options.PoolAlias}");
Console.WriteLine($"Sage X3 Language  : {sageX3Options.Language}");
Console.WriteLine($"Batch Size        : {migrationOptions.BatchSize}");
Console.WriteLine();

using var httpClient = new HttpClient();
var x3WebServiceClient = new SageX3WebServiceClient(httpClient, sageX3Options);

var categoryService = new X3CustomerCategoryService(x3WebServiceClient);
var customerService = new X3CustomerService(x3WebServiceClient);
var shipToCustomerService = new X3ShipToCustomerService(x3WebServiceClient);

Console.WriteLine("X3 services ready:");
Console.WriteLine("- S300CRMCAT  Customer Category");
Console.WriteLine("- S300CRM     Customer");
Console.WriteLine("- S300STCRM   Ship-to Customer / BPD");
Console.WriteLine();

Console.WriteLine("Running X3 smoke test: S300STCRM...");

var shipTo = new X3ShipToCustomerDto
{
    CustomerNumber = "TSTCUST03",
    ShipToCode = "002",

    IsActive = 2,
    Language = "ENG",
    NameLine1 = "Test Ship-to 02",

    TaxRule = "ON",

    AddressDescription = "Ship Address",
    Country = "CA",
    AddressLine1 = "456 Ship Street",
    City = "Toronto",
    StateProvince = "ON",
    PostalCode = "M2M2M2",

    Phone1 = "4165551234",
    Email1 = "shipto@test.com"
};

Console.WriteLine(shipTo.ToX3Xml());

var shipToResult = await shipToCustomerService.SaveAsync(shipTo);

Console.WriteLine("Success : " + shipToResult.Success);
Console.WriteLine("Status  : " + shipToResult.Status);
Console.WriteLine("Error   : " + shipToResult.ErrorMessage);

Console.WriteLine();
Console.WriteLine("Result XML:");
Console.WriteLine(shipToResult.ResultXml);

Console.WriteLine();
Console.WriteLine("Raw Response:");
Console.WriteLine(shipToResult.RawResponse);