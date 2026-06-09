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
