<a name='assembly'></a>
# CommonLanguageExtensions

## Contents

- [BoolExtensions](#T-CommonLanguageExtensions-BoolExtensions 'CommonLanguageExtensions.BoolExtensions')
  - [ToYesNoString(value)](#M-CommonLanguageExtensions-BoolExtensions-ToYesNoString-System-Boolean- 'CommonLanguageExtensions.BoolExtensions.ToYesNoString(System.Boolean)')
- [DateTimeExtensions](#T-CommonLanguageExtensions-DateTimeExtensions 'CommonLanguageExtensions.DateTimeExtensions')
  - [ShowPossibleTimeZones(offsetTime)](#M-CommonLanguageExtensions-DateTimeExtensions-ShowPossibleTimeZones-System-DateTimeOffset- 'CommonLanguageExtensions.DateTimeExtensions.ShowPossibleTimeZones(System.DateTimeOffset)')
  - [ZeroPad(dt)](#M-CommonLanguageExtensions-DateTimeExtensions-ZeroPad-System-DateTime- 'CommonLanguageExtensions.DateTimeExtensions.ZeroPad(System.DateTime)')
  - [ZeroPad(dt,dateSeparator,timeSeparator)](#M-CommonLanguageExtensions-DateTimeExtensions-ZeroPad-System-DateTime,System-String,System-String- 'CommonLanguageExtensions.DateTimeExtensions.ZeroPad(System.DateTime,System.String,System.String)')
- [GenericExtensions](#T-CommonLanguageExtensions-GenericExtensions 'CommonLanguageExtensions.GenericExtensions')
  - [BetweenExclusive\`\`1(sender,minimumValue,maximumValue)](#M-CommonLanguageExtensions-GenericExtensions-BetweenExclusive``1-System-IComparable{``0},``0,``0- 'CommonLanguageExtensions.GenericExtensions.BetweenExclusive``1(System.IComparable{``0},``0,``0)')
  - [Between\`\`1(sender,minimumValue,maximumValue)](#M-CommonLanguageExtensions-GenericExtensions-Between``1-System-IComparable{``0},``0,``0- 'CommonLanguageExtensions.GenericExtensions.Between``1(System.IComparable{``0},``0,``0)')
  - [IsNegative\`\`1(value)](#M-CommonLanguageExtensions-GenericExtensions-IsNegative``1-``0- 'CommonLanguageExtensions.GenericExtensions.IsNegative``1(``0)')
  - [IsPositive\`\`1(value)](#M-CommonLanguageExtensions-GenericExtensions-IsPositive``1-``0- 'CommonLanguageExtensions.GenericExtensions.IsPositive``1(``0)')
- [StringExtensions](#T-CommonLanguageExtensions-StringExtensions 'CommonLanguageExtensions.StringExtensions')
  - [AlphaToInteger(text,result)](#M-CommonLanguageExtensions-StringExtensions-AlphaToInteger-System-String,System-Int32@- 'CommonLanguageExtensions.StringExtensions.AlphaToInteger(System.String,System.Int32@)')
  - [Contains(sender,pSubString,pCaseInSensitive)](#M-CommonLanguageExtensions-StringExtensions-Contains-System-String,System-String,System-Boolean- 'CommonLanguageExtensions.StringExtensions.Contains(System.String,System.String,System.Boolean)')
  - [DumpHRefs(inputString,key)](#M-CommonLanguageExtensions-StringExtensions-DumpHRefs-System-String,System-String- 'CommonLanguageExtensions.StringExtensions.DumpHRefs(System.String,System.String)')
  - [IsNullOrWhiteSpace(sender)](#M-CommonLanguageExtensions-StringExtensions-IsNullOrWhiteSpace-System-String- 'CommonLanguageExtensions.StringExtensions.IsNullOrWhiteSpace(System.String)')
  - [IsNumeric(text)](#M-CommonLanguageExtensions-StringExtensions-IsNumeric-System-String- 'CommonLanguageExtensions.StringExtensions.IsNumeric(System.String)')
  - [RemoveExtraSpaces(sender)](#M-CommonLanguageExtensions-StringExtensions-RemoveExtraSpaces-System-String- 'CommonLanguageExtensions.StringExtensions.RemoveExtraSpaces(System.String)')
  - [SplitCamelCase(sender)](#M-CommonLanguageExtensions-StringExtensions-SplitCamelCase-System-String- 'CommonLanguageExtensions.StringExtensions.SplitCamelCase(System.String)')
  - [StripperNumbers(text)](#M-CommonLanguageExtensions-StringExtensions-StripperNumbers-System-String- 'CommonLanguageExtensions.StringExtensions.StripperNumbers(System.String)')
  - [ToEnum\`\`1(value,defaultValue)](#M-CommonLanguageExtensions-StringExtensions-ToEnum``1-System-String,``0- 'CommonLanguageExtensions.StringExtensions.ToEnum``1(System.String,``0)')
- [TimeSpanExtensions](#T-CommonLanguageExtensions-TimeSpanExtensions 'CommonLanguageExtensions.TimeSpanExtensions')
  - [Formatted(sender,format)](#M-CommonLanguageExtensions-TimeSpanExtensions-Formatted-System-TimeSpan,System-String- 'CommonLanguageExtensions.TimeSpanExtensions.Formatted(System.TimeSpan,System.String)')
- [ValidateExtensions](#T-CommonLanguageExtensions-ValidateExtensions 'CommonLanguageExtensions.ValidateExtensions')
  - [CleanSsn(ssn)](#M-CommonLanguageExtensions-ValidateExtensions-CleanSsn-System-String- 'CommonLanguageExtensions.ValidateExtensions.CleanSsn(System.String)')
  - [IsValidSsnSimple(value)](#M-CommonLanguageExtensions-ValidateExtensions-IsValidSsnSimple-System-String- 'CommonLanguageExtensions.ValidateExtensions.IsValidSsnSimple(System.String)')
  - [IsValidSsnWithoutDashes(value)](#M-CommonLanguageExtensions-ValidateExtensions-IsValidSsnWithoutDashes-System-String- 'CommonLanguageExtensions.ValidateExtensions.IsValidSsnWithoutDashes(System.String)')

<a name='T-CommonLanguageExtensions-BoolExtensions'></a>
## BoolExtensions `type`

##### Namespace

CommonLanguageExtensions

##### Summary

Language extensions for type bool

<a name='M-CommonLanguageExtensions-BoolExtensions-ToYesNoString-System-Boolean-'></a>
### ToYesNoString(value) `method`

##### Summary

Convert bool to English text

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='T-CommonLanguageExtensions-DateTimeExtensions'></a>
## DateTimeExtensions `type`

##### Namespace

CommonLanguageExtensions

##### Summary

Date time extensions

<a name='M-CommonLanguageExtensions-DateTimeExtensions-ShowPossibleTimeZones-System-DateTimeOffset-'></a>
### ShowPossibleTimeZones(offsetTime) `method`

##### Summary

Show possible time zone for a DateTimeOffset

##### Returns

list of possible time zones

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| offsetTime | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | [DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') |

##### Remarks

var dstDate = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
DateTimeOffset thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));
Console.WriteLine("{0} could belong to the following time zones:", thisTime.ToString());
thisTime.ShowPossibleTimeZones().ForEach(Console.WriteLine);

<a name='M-CommonLanguageExtensions-DateTimeExtensions-ZeroPad-System-DateTime-'></a>
### ZeroPad(dt) `method`

##### Summary

Returns passed datetime with zero padding using current culture separators

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dt | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |  |

##### Remarks

order of date parts year, month, day which can be changed to say month, day, year

<a name='M-CommonLanguageExtensions-DateTimeExtensions-ZeroPad-System-DateTime,System-String,System-String-'></a>
### ZeroPad(dt,dateSeparator,timeSeparator) `method`

##### Summary

Returns passed datetime with zero padding using user supplied separators

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dt | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | [DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') |
| dateSeparator | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| timeSeparator | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Remarks

order of date parts year, month, day which can be changed to say month, day, year

<a name='T-CommonLanguageExtensions-GenericExtensions'></a>
## GenericExtensions `type`

##### Namespace

CommonLanguageExtensions

##### Summary

Generic language extensions

<a name='M-CommonLanguageExtensions-GenericExtensions-BetweenExclusive``1-System-IComparable{``0},``0,``0-'></a>
### BetweenExclusive\`\`1(sender,minimumValue,maximumValue) `method`

##### Summary

Determines if a value is between two values, exclusive.

##### Returns

`true` if the value is between the two values, exclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.IComparable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IComparable 'System.IComparable{``0}') | The source value. |
| minimumValue | [\`\`0](#T-``0 '``0') | The minimum value. |
| maximumValue | [\`\`0](#T-``0 '``0') | The Maximum value. |

<a name='M-CommonLanguageExtensions-GenericExtensions-Between``1-System-IComparable{``0},``0,``0-'></a>
### Between\`\`1(sender,minimumValue,maximumValue) `method`

##### Summary

Determine if T is between lower and upper

##### Returns

True if in range, false if not in range

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.IComparable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IComparable 'System.IComparable{``0}') | Value to determine if between lower and upper |
| minimumValue | [\`\`0](#T-``0 '``0') | Lower of range |
| maximumValue | [\`\`0](#T-``0 '``0') | Upper of range |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Data type |

##### Example

```csharp
var startDate = new DateTime(2018, 12, 2, 1, 12, 0);
var endDate = new DateTime(2018, 12, 15, 1, 12, 0);
var theDate = new DateTime(2018, 12, 13, 1, 12, 0);
Assert.IsTrue(theDate.Between(startDate,endDate));
```

<a name='M-CommonLanguageExtensions-GenericExtensions-IsNegative``1-``0-'></a>
### IsNegative\`\`1(value) `method`

##### Summary

Determine if value is negative

##### Returns

true if negative, false otherwise

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [\`\`0](#T-``0 '``0') | Value to test |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type implementing IComparable |

<a name='M-CommonLanguageExtensions-GenericExtensions-IsPositive``1-``0-'></a>
### IsPositive\`\`1(value) `method`

##### Summary

Determine if value is positive

##### Returns

true if positive, false otherwise

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [\`\`0](#T-``0 '``0') | Value to test |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type implementing IComparable |

<a name='T-CommonLanguageExtensions-StringExtensions'></a>
## StringExtensions `type`

##### Namespace

CommonLanguageExtensions

##### Summary

String extensions

<a name='M-CommonLanguageExtensions-StringExtensions-AlphaToInteger-System-String,System-Int32@-'></a>
### AlphaToInteger(text,result) `method`

##### Summary

Get numbers from string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| result | [System.Int32@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32@ 'System.Int32@') |  |

<a name='M-CommonLanguageExtensions-StringExtensions-Contains-System-String,System-String,System-Boolean-'></a>
### Contains(sender,pSubString,pCaseInSensitive) `method`

##### Summary

Overload of the standard String.Contains method which provides case sensitivity.

##### Returns

True if string is in sent string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String to search |
| pSubString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Sub string to match |
| pCaseInSensitive | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Use case or ignore case |

<a name='M-CommonLanguageExtensions-StringExtensions-DumpHRefs-System-String,System-String-'></a>
### DumpHRefs(inputString,key) `method`

##### Summary

Get parameters from a web address

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inputString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | web address |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | parameter name |

<a name='M-CommonLanguageExtensions-StringExtensions-IsNullOrWhiteSpace-System-String-'></a>
### IsNullOrWhiteSpace(sender) `method`

##### Summary

Determine if string is empty

##### Returns

true if empty or false if not empty

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String to test if null or whitespace |

<a name='M-CommonLanguageExtensions-StringExtensions-IsNumeric-System-String-'></a>
### IsNumeric(text) `method`

##### Summary

Determine if a string can be represented as a numeric.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | value to determine if can be converted to a string |

<a name='M-CommonLanguageExtensions-StringExtensions-RemoveExtraSpaces-System-String-'></a>
### RemoveExtraSpaces(sender) `method`

##### Summary

Remove extra spaces in a string

##### Returns

string with no extra spaces

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string value |

<a name='M-CommonLanguageExtensions-StringExtensions-SplitCamelCase-System-String-'></a>
### SplitCamelCase(sender) `method`

##### Summary

Split string with space e.g. FirstName becomes First Name

##### Returns

Original string if not in proper format or a string with space between variable upper cased tokens

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | string value with value like FirstName |

<a name='M-CommonLanguageExtensions-StringExtensions-StripperNumbers-System-String-'></a>
### StripperNumbers(text) `method`

##### Summary

Strip alpha characters from a string

##### Returns

A string devoid of anything other than numeric values

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | text to work against |

<a name='M-CommonLanguageExtensions-StringExtensions-ToEnum``1-System-String,``0-'></a>
### ToEnum\`\`1(value,defaultValue) `method`

##### Summary

Convert string to an enum member

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Value to convert |
| defaultValue | [\`\`0](#T-``0 '``0') | Default value if an issue arises in the form of an empty string |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Enum type |

<a name='T-CommonLanguageExtensions-TimeSpanExtensions'></a>
## TimeSpanExtensions `type`

##### Namespace

CommonLanguageExtensions

##### Summary

TimeSpan extensions

<a name='M-CommonLanguageExtensions-TimeSpanExtensions-Formatted-System-TimeSpan,System-String-'></a>
### Formatted(sender,format) `method`

##### Summary

Format a TimeSpan with AM PM

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan') | TimeSpan to format |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional format |

<a name='T-CommonLanguageExtensions-ValidateExtensions'></a>
## ValidateExtensions `type`

##### Namespace

CommonLanguageExtensions

##### Summary

Validation extensions

<a name='M-CommonLanguageExtensions-ValidateExtensions-CleanSsn-System-String-'></a>
### CleanSsn(ssn) `method`

##### Summary

Remove hyphens from string

##### Returns

SSN without hyphens

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ssn | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SSN to work with |

<a name='M-CommonLanguageExtensions-ValidateExtensions-IsValidSsnSimple-System-String-'></a>
### IsValidSsnSimple(value) `method`

##### Summary

Simple validate 9 digits

##### Returns

SSN passed validation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SSN to validate |

<a name='M-CommonLanguageExtensions-ValidateExtensions-IsValidSsnWithoutDashes-System-String-'></a>
### IsValidSsnWithoutDashes(value) `method`

##### Summary

Validate
  Don't allow "219-09-999" or "078-05-1120" explicitly
  Don't allow the SSN to begin with 666, 000 or anything between 900-999
  Explicit dash (separating Area and Group numbers)
  Don't allow the Group Number to be "00"
  Another dash (separating Group and Serial numbers)
  Don't allow last four digits to be "0000"

##### Returns

SSN passed validation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SSN to validate |
