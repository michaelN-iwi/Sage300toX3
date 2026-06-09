using Sage300API.SDK.Models.AR;

namespace Migration.Core.Validation;

public sealed class CustomerSourceValidator
{
    public MigrationValidationResult ValidateCustomer(ARCustomer customer)
    {
        var result = new MigrationValidationResult();
        var key = customer.CustomerNumber ?? string.Empty;

        Required(result, "Customer", key, nameof(customer.CustomerNumber), customer.CustomerNumber);
        Required(result, "Customer", key, nameof(customer.CustomerName), customer.CustomerName);
        Required(result, "Customer", key, nameof(customer.GroupCode), customer.GroupCode);

        WarnIfBlank(result, "Customer", key, nameof(customer.Country), customer.Country, "Default X3 country will be used.");
        WarnIfBlank(result, "Customer", key, nameof(customer.CurrencyCode), customer.CurrencyCode, "Default X3 currency will be used.");
        WarnIfBlank(result, "Customer", key, nameof(customer.Terms), customer.Terms, "Default X3 payment term will be used.");
        WarnIfBlank(result, "Customer", key, nameof(customer.TaxGroup), customer.TaxGroup, "Default X3 tax rule will be used.");

        return result;
    }

    public MigrationValidationResult ValidateCustomerGroup(ARCustomerGroup group)
    {
        var result = new MigrationValidationResult();
        var key = group.GroupCode ?? string.Empty;

        Required(result, "CustomerGroup", key, nameof(group.GroupCode), group.GroupCode);
        Required(result, "CustomerGroup", key, nameof(group.Description), group.Description);

        return result;
    }

    public MigrationValidationResult ValidateShipTo(
        CustomerContactSelection contact,
        ARCustomer parentCustomer)
    {
        var result = new MigrationValidationResult();
        var key = $"{parentCustomer.CustomerNumber}/{contact.ContactCode}";

        Required(result, "ShipToCustomer", key, nameof(parentCustomer.CustomerNumber), parentCustomer.CustomerNumber);
        Required(result, "ShipToCustomer", key, nameof(contact.ContactCode), contact.ContactCode);
        WarnIfBlank(result, "ShipToCustomer", key, nameof(contact.ContactName), contact.ContactName, "Parent customer name will be used.");

        return result;
    }

    private static void Required(
        MigrationValidationResult result,
        string entityName,
        string sourceKey,
        string fieldName,
        string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            result.AddError(entityName, sourceKey, fieldName, "Required source field is missing.");
    }

    private static void WarnIfBlank(
        MigrationValidationResult result,
        string entityName,
        string sourceKey,
        string fieldName,
        string? value,
        string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            result.AddWarning(entityName, sourceKey, fieldName, message);
    }
}
