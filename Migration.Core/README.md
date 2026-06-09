# Migration.Core

This project contains the first migration intelligence layer for Sage 300 -> Sage X3.

Current scope:
- Customer Groups -> X3 Customer Category
- Customers -> X3 Customer, including embedded customer optional fields
- Customer Contact Selection -> X3 Ship-to Customer / BPD

Responsibilities:
- Mapping Sage 300 models to X3 DTOs
- Transformation of values through configurable mapping dictionaries
- Source-data validation helpers

The X3 SDK remains responsible only for building/sending X3 web service XML.
The Sage 300 SDK remains responsible only for extracting Sage 300 data.
