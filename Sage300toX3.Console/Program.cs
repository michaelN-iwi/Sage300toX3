using Microsoft.Extensions.Configuration;
using Migration.Core.Mappers;
using Migration.Core.Options;
using Migration.Core.Transformation;
using Migration.Core.Validation;
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

var x3Defaults = configuration
    .GetSection("X3Defaults")
    .Get<X3DefaultValuesOptions>()
    ?? new X3DefaultValuesOptions();

var mappingOptions = configuration
    .GetSection("Mappings")
    .Get<MigrationMappingOptions>()
    ?? new MigrationMappingOptions();

sageX3Options.Validate();

Console.WriteLine("Sage 300 -> Sage X3 Migration");
Console.WriteLine($"Sage 300 Company : {sage300Options.Company}");
Console.WriteLine($"Sage X3 PoolAlias : {sageX3Options.PoolAlias}");
Console.WriteLine($"Sage X3 Language  : {sageX3Options.Language}");
Console.WriteLine($"Batch Size        : {migrationOptions.BatchSize}");
Console.WriteLine($"Customer Optional Field Capacity : {migrationOptions.CustomerOptionalFieldCapacity}");
Console.WriteLine();

using var httpClient = new HttpClient();
var x3WebServiceClient = new SageX3WebServiceClient(httpClient, sageX3Options);

var categoryService = new X3CustomerCategoryService(x3WebServiceClient);
var customerService = new X3CustomerService(
    x3WebServiceClient,
    migrationOptions.CustomerOptionalFieldCapacity);
var shipToCustomerService = new X3ShipToCustomerService(x3WebServiceClient);

var transformer = new ValueTransformer(mappingOptions, x3Defaults);
var optionalFieldMapper = new CustomerOptionalFieldMapper(transformer);
var customerCategoryMapper = new CustomerCategoryMapper(transformer, x3Defaults);
var customerMapper = new CustomerMapper(transformer, x3Defaults, optionalFieldMapper);
var shipToCustomerMapper = new ShipToCustomerMapper(transformer, x3Defaults);
var sourceValidator = new CustomerSourceValidator();

Console.WriteLine("X3 services ready:");
Console.WriteLine("- S300BCG  Customer Category");
Console.WriteLine("- S300BPC  Customer, including embedded optional fields");
Console.WriteLine("- S300BPD  Ship-to Customer / BPD");
Console.WriteLine();

Console.WriteLine("Migration.Core ready:");
Console.WriteLine("- CustomerCategoryMapper");
Console.WriteLine("- CustomerMapper");
Console.WriteLine("- CustomerOptionalFieldMapper");
Console.WriteLine("- ShipToCustomerMapper");
Console.WriteLine("- CustomerSourceValidator");
Console.WriteLine();

// Manual smoke-test example. Keep this section for direct X3 testing.
// Replace CustomerNumber before each run to avoid duplicate-record messages.
Console.WriteLine("Running X3 smoke test: S300BPC...");

var customer = new X3CustomerDto
{
    CustomerNumber = "TSTCUST08",
    CategoryCode = "TST",
    IsActive = 2,

    ShortDescription = "TEST08",
    Acronym = "TEST08",
    NameLine1 = "Test Customer 08",

    Country = "CA",
    AddressCountry = "CA",
    Language = "ENG",
    Currency = "CAD",
    TaxIdNumber = "999999999",

    AddressCode = "001",
    AddressDescription = "Main Address",
    AddressLine1 = "123 Test Street",
    City = "Toronto",
    StateProvince = "ON",
    PostalCode = "M1M1M1",

    TaxRule = "ON",
    PaymentTerm = "NET30",
    AccountingCode = "STD",

    OptionalFields = new Dictionary<string, string?>
    {
        ["S300GROUP"] = "RETAIL",
        ["S300REGION"] = "ONTARIO",
        ["S300TYPE"] = "CORPORATE",
        ["S300SOURCE"] = "SAGE300",
        ["S300STATUS"] = "ACTIVE"
    }
};

Console.WriteLine(customer.ToX3Xml(migrationOptions.CustomerOptionalFieldCapacity));

var customerResult =
    await customerService.SaveAsync(customer);

Console.WriteLine("Success : " + customerResult.Success);
Console.WriteLine("Status  : " + customerResult.Status);
Console.WriteLine("Error   : " + customerResult.ErrorMessage);

Console.WriteLine();
Console.WriteLine("Raw Response:");
Console.WriteLine(customerResult.RawResponse);
