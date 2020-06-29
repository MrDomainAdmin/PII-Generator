# PII-Generator (BETA)
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

```

Credit Cards are generated using https://github.com/gustavofrizzo/CreditCardValidator and are luhn-valid

Social Security Numbers are generated using a random number generator -> into the ###-##-#### format.



FSUtil.exe, a native windows tool, is used to generate the file. This tool ran a lot faster than all of the native C# writefile examples that I found.
