# Sage300toX3

Migration framework for moving selected Sage 300 data into Sage X3 through published X3 SOAP web services.

## Current architecture

- `Sage300.SDK` extracts data from Sage 300 Web API / OData.
- `SageX3.SDK` builds and sends Sage X3 SOAP web service payloads.
- `Migration.Core` contains mapping, validation, and transformation logic.
- `Sage300toX3.Console` is the current runner / smoke-test application.

## Current mapped scope

- Customer Groups -> `S300BCG` / `X3CustomerCategoryDto`
- Customers -> `S300BPC` / `X3CustomerDto`
- Customer Optional Fields -> embedded into `S300BPC` through `YOPTBPC` and `YOPTBPCV` lists
- Customer Contact Selection -> `S300BPD` / `X3ShipToCustomerDto`

## X3 web services prepared in the SDK

- `S300CPY` Company
- `S300FCY` Site
- `S300DIE` Dimension Type
- `S300CCE` Dimension Value
- `S300LED` Ledger
- `S300GCM` Ledger Group
- `S300FIY` Fiscal Year
- `S300PER` Period
- `S300BCG` Customer Category
- `S300BPC` Customer
- `S300BPD` Ship-to Customer

## Run the console

```powershell
dotnet run --project .\Sage300toX3.Console\Sage300toX3.Console.csproj
```

## Next implementation step

Create migration orchestrators:

- `CustomerMigrationOrchestrator`
- `FinancialStructureMigrationOrchestrator`
- `FullMigrationOrchestrator`

These will execute extraction, validation, mapping, X3 save calls, and result logging in order.
