using Migration.Core.Options;
using Migration.Core.Transformation;
using Sage300API.SDK.Models.AR;
using SageX3.SDK.Models;

namespace Migration.Core.Mappers;

public sealed class CustomerCategoryMapper
{
    private readonly ValueTransformer _transformer;
    private readonly X3DefaultValuesOptions _defaults;

    public CustomerCategoryMapper(
        ValueTransformer transformer,
        X3DefaultValuesOptions defaults)
    {
        _transformer = transformer;
        _defaults = defaults;
    }

    public X3CustomerCategoryDto Map(ARCustomerGroup source)
    {
        var description = ValueTransformer.FirstNonBlank(source.Description, source.GroupCode);

        return new X3CustomerCategoryDto
        {
            CategoryCode = _transformer.CustomerCategory(source.GroupCode),
            Description = ValueTransformer.Truncate(description, 30),
            ShortDescription = ValueTransformer.Truncate(description, 12),
            Country = _defaults.Country,
            Language = _defaults.Language,
            Currency = _defaults.Currency,
            TaxRule = _transformer.TaxRule(source.TaxGroup),
            PaymentTerm = _transformer.PaymentTerm(source.Terms),
            AccountingCode = _transformer.AccountingCode(source.AccountSet),
            AuthorizedCredit = source.CreditLimit1Amount
        };
    }
}
