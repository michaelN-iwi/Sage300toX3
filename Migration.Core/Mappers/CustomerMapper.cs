using Migration.Core.Options;
using Migration.Core.Transformation;
using Sage300API.SDK.Models.AR;
using SageX3.SDK.Models;

namespace Migration.Core.Mappers;

public sealed class CustomerMapper
{
    private readonly ValueTransformer _transformer;
    private readonly X3DefaultValuesOptions _defaults;
    private readonly CustomerOptionalFieldMapper _optionalFieldMapper;

    public CustomerMapper(
        ValueTransformer transformer,
        X3DefaultValuesOptions defaults,
        CustomerOptionalFieldMapper optionalFieldMapper)
    {
        _transformer = transformer;
        _defaults = defaults;
        _optionalFieldMapper = optionalFieldMapper;
    }

    public X3CustomerDto Map(
        ARCustomer source,
        ARCustomerGroup? group = null)
    {
        var name = ValueTransformer.FirstNonBlank(source.CustomerName, source.CustomerNumber);
        var shortDescription = ValueTransformer.FirstNonBlank(source.ShortName, source.CustomerName, source.CustomerNumber);
        var country = _transformer.Country(source.Country);
        var currency = _transformer.Currency(source.CurrencyCode);
        var taxRule = _transformer.TaxRule(ValueTransformer.FirstNonBlank(source.TaxGroup, group?.TaxGroup));
        var paymentTerm = _transformer.PaymentTerm(ValueTransformer.FirstNonBlank(source.Terms, group?.Terms));
        var accountingCode = _transformer.AccountingCode(group?.AccountSet);

        return new X3CustomerDto
        {
            CustomerNumber = ValueTransformer.NormalizeCode(source.CustomerNumber),
            CategoryCode = _transformer.CustomerCategory(ValueTransformer.FirstNonBlank(source.GroupCode, group?.GroupCode)),
            IsActive = _transformer.ActiveFlag(source.Status),

            ShortDescription = ValueTransformer.Truncate(shortDescription, 10),
            Acronym = ValueTransformer.Truncate(shortDescription, 10),
            NameLine1 = ValueTransformer.Truncate(name, 35),
            NameLine2 = name.Length > 35 ? ValueTransformer.Truncate(name[35..], 35) : null,
            Country = country,
            Language = _defaults.Language,
            Currency = currency,
            TaxIdNumber = _defaults.TaxIdNumber,

            AddressCode = _defaults.AddressCode,
            AddressDescription = _defaults.AddressDescription,
            AddressCountry = country,
            AddressLine1 = ValueTransformer.Truncate(source.AddressLine1, 50),
            AddressLine2 = ValueTransformer.Truncate(source.AddressLine2, 50),
            PostalCode = ValueTransformer.Truncate(source.ZipPostalCode, 10),
            City = ValueTransformer.Truncate(source.City, 40),
            StateProvince = ValueTransformer.Truncate(source.StateProvince, 35),
            Phone1 = ValueTransformer.Truncate(source.PhoneNumber, 20),
            Email1 = ValueTransformer.Truncate(source.Email, 80),
            IsDefaultAddress = _defaults.ActiveValue,

            TaxRule = taxRule,
            PaymentTerm = paymentTerm,
            AccountingCode = accountingCode,
            OptionalFields = _optionalFieldMapper.Map(source.CustomerOptionalFieldValues)
        };
    }
}
