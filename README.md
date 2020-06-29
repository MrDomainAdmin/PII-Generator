# PII-Generator
Generate fake PII data for exfiltration exercises - Designed for use with Cobalt Strike's `execute-assembly`.

```
Usage:
  PII-Generator.exe --filename c:\full\path\to\file --filesize size-in-bytes --type pii-data-type

  --filename
    This is the name of the file generated. If the full path is not specified, it is relative to current directory.

  --filesize
    This is the size of the file in bytes. It is capped at 5GB to prevent catastrophic typos.

  --type
    This is the type of PII to generate - This program only supports 'creditcard' and 'ssn' at release.

