# Sage 300 to Sage X3 Migration

Initial migration scope:

| Area                           | Web Service / Public Name | X3 Object         | X3 Alias | DTO Class               | Service Class               |
| ------------------------------ | ------------------------: | ----------------- | -------- | ----------------------- | --------------------------- |
| Customer Groups                |                 `S300BCG` | Customer Category | `BCG`    | `X3CustomerCategoryDto` | `X3CustomerCategoryService` |
| Customers                      |                 `S300BPC` | Customer          | `BPC`    | `X3CustomerDto`         | `X3CustomerService`         |
| Ship-to Customers              |                 `S300BPD` | Ship-to Customer  | `BPD`    | `X3ShipToCustomerDto`   | `X3ShipToCustomerService`   |
| Companies                      |                 `S300CPY` | Company           | `CPY`    | `X3CompanyDto`          | `X3CompanyService`          |
| Sites                          |                 `S300FCY` | Site              | `FCY`    | `X3SiteDto`             | `X3SiteService`             |
| Dimension Types                |                 `S300DIE` | Dimension Type    | `DIE`    | `X3DimensionTypeDto`    | `X3DimensionTypeService`    |
| Dimensions / Analytical Values |                 `S300CCE` | Dimension Value   | `CCE`    | `X3DimensionValueDto`   | `X3DimensionValueService`   |
| Ledgers                        |                 `S300LED` | Ledger            | `LED`    | `X3LedgerDto`           | `X3LedgerService`           |
| Ledger Groups                  |                 `S300GCM` | Ledger Group      | `GCM`    | `X3LedgerGroupDto`      | `X3LedgerGroupService`      |
| Fiscal Years                   |                 `S300FIY` | Fiscal Year       | `FIY`    | `X3FiscalYearDto`       | `X3FiscalYearService`       |
| Periods                        |                 `S300PER` | Period            | `PER`    | `X3PeriodDto`           | `X3PeriodService`           |


## Configuration

Runtime values are loaded from:

```text
Sage300toX3.Console/appsettings.json
```

Current X3 values configured:

```json
"SageX3": {
  "EndpointUrl": "http://172.16.0.66:8124/soap-generic/syracuse/collaboration/syracuse/CAdxWebServiceXmlCC",
  "Language": "ENG",
  "PoolAlias": "S300"
}
```

## Notes

- `SageX3WebServiceClient.SaveAsync()` is used for X3 object web services.
- `SageX3WebServiceClient.RunAsync()` remains available for X3 subprogram web services.
- The SOAP payload wraps `objectXml` / `inputXml` in CDATA to avoid escaping issues.
