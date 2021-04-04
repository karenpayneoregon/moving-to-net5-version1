# About 

Basic language extensions

![ver](../assets/Versions.png) 


# Important

The `namespace` in code is different than under project properties so that when teaching this project code may be used in C# code samples and vice versa.

## String extensions

---


| Extension  | &nbsp; | Description  |
|:-------------|--|:---|
| ToEnum&lt;T&gt;  | &nbsp; | Convert string to enum member   |
| SplitCamelCase  | &nbsp; | Split string on upper cased and space   |
| RemoveMultipleSpaces  | &nbsp; | Replace multiple whitespace to single whitespace   |
| StripperNumbers  | &nbsp; | Strip alpha characters from a string   |
| AlphaToInteger  | &nbsp; | Strip numeric characters from a string    |
| IsNullOrWhiteSpace  | &nbsp; | Method base   |
| Contains  | &nbsp; | Provides case insensitive contains |
| RemoveExtraSpaces  | &nbsp; | Any double spaces to single spaces |
| DumpHRefs  | &nbsp; | Get params from a web address |

## Bool extensions

---


| Extension  | &nbsp; | Description  |
|:-------------|--| :---|
| ToYesNoString  | &nbsp; | to yes/no |


## Validate extensions

---


| Extension  | &nbsp; | Description  |
|:-------------|--|:---|
| IsValidSsnWithoutDashes  | &nbsp; | With rules |
| IsValidSsnWithoutDashes  | &nbsp; | nine digits |


---


## Generic extensions

| Extension  | &nbsp; | Description  |
|:-------------|--|:---|
| Between&lt;T&gt;  | &nbsp; | Is between IComparable |
| BetweenExclusive&lt;T&gt;  | &nbsp; | Is between IComparable |
| IsPositive&lt;T&gt;  | &nbsp; | IComparable |
| IsNegative&lt;T&gt;  | &nbsp; | IComparable |



## DateTime/DateTimeOffset extensions

| Extension  | &nbsp; | Description  |
|:-------------|--|:---|
| ZeroPad  | &nbsp; | Returns passed datetime with zero padding using current culture separators with seconds |
| ZeroPadWithoutSeconds  | &nbsp; | Returns passed datetime with zero padding using current culture separators, without seconds |
| ShowPossibleTimeZones  | &nbsp; | Show possible time zone for a DateTimeOffset |



