# SageX3.SDK

This project contains the Sage X3 SOAP Web Service layer for the Sage 300 to Sage X3 migration.

## Web services currently supported

| Public name | X3 object | Alias | Purpose |
|---|---|---|---|
| S300BCG | Customer Category | BCG | Sage 300 Customer Groups |
| S300BPC | Customer | BPC | Sage 300 Customers |
| S300BPD | Ship-to Customer | BPD | Sage 300 Customer contacts / ship-to addresses |

## Payload convention

Payloads are generated as Sage X3 object Web Service XML:

```xml
<PARAM>
  <GRP ID="BPC0_1">
    <FLD NAME="BPCNUM">...</FLD>
  </GRP>
</PARAM>
```

Fields and groups were aligned with the uploaded X3 metadata XML files in `/Metadata`.

## Additional Sage X3 Web Services

The SDK also includes DTOs and services for the following Sage X3 public names:

| Public name | X3 object | SDK service | DTO |
|---|---|---|---|
| S300CPY | CPY Company | X3CompanyService | X3CompanyDto |
| S300FCY | FCY Site | X3SiteService | X3SiteDto |
| S300DIE | DIE Dimension Type | X3DimensionTypeService | X3DimensionTypeDto |
| S300CCE | CCE Dimension Value | X3DimensionValueService | X3DimensionValueDto |
| S300LED | LED Ledger | X3LedgerService | X3LedgerDto |
| S300GCM | GCM Ledger Group / Ledger Model | X3LedgerGroupService | X3LedgerGroupDto |
| S300FIY | FIY Fiscal Year | X3FiscalYearService | X3FiscalYearDto |
| S300PER | PER Period | X3PeriodService | X3PeriodDto |

Customer optional fields are embedded in `X3CustomerDto` and generated as X3 `<LST><ITM>` structures under `YOPTBPC_1` and `YOPTBPC_2`.
