using Migration.Core.Options;
using Migration.Core.Transformation;
using Sage300API.SDK.Models.AR;
using SageX3.SDK.Models;

namespace Migration.Core.Mappers;

public sealed class ShipToCustomerMapper
{
    private readonly ValueTransformer _transformer;
    private readonly X3DefaultValuesOptions _defaults;

    public ShipToCustomerMapper(
        ValueTransformer transformer,
        X3DefaultValuesOptions defaults)
    {
        _transformer = transformer;
        _defaults = defaults;
    }

    public X3ShipToCustomerDto Map(
        CustomerContactSelection source,
        ARCustomer parentCustomer)
    {
        var country = _transformer.Country(parentCustomer.Country);
        var name = ValueTransformer.FirstNonBlank(source.ContactName, parentCustomer.CustomerName, parentCustomer.CustomerNumber);

        return new X3ShipToCustomerDto
        {
            CustomerNumber = ValueTransformer.NormalizeCode(parentCustomer.CustomerNumber),
            ShipToCode = ValueTransformer.Truncate(
                ValueTransformer.FirstNonBlank(source.ContactCode, _defaults.AddressCode),
                5),
            IsActive = _defaults.ActiveValue,
            Language = _defaults.Language,
            NameLine1 = ValueTransformer.Truncate(name, 35),
            TaxRule = _transformer.TaxRule(parentCustomer.TaxGroup),
            AddressDescription = ValueTransformer.Truncate(name, 20),
            Country = country,
            AddressLine1 = ValueTransformer.Truncate(parentCustomer.AddressLine1, 50),
            AddressLine2 = ValueTransformer.Truncate(parentCustomer.AddressLine2, 50),
            PostalCode = ValueTransformer.Truncate(parentCustomer.ZipPostalCode, 10),
            City = ValueTransformer.Truncate(parentCustomer.City, 40),
            StateProvince = ValueTransformer.Truncate(parentCustomer.StateProvince, 35),
            Phone1 = ValueTransformer.Truncate(parentCustomer.PhoneNumber, 20),
            Email1 = ValueTransformer.Truncate(source.Email, 80)
        };
    }
}
