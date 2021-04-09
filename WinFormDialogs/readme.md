# About

provides two easy too use wrappers for MessageBox to ask a question which defaults to the `No` button and returns a `bool`.

![img](https://img.shields.io/badge/Karen%20Payne-MVP-lightgrey)


![img](../assets/Versions.png)


# Usage

Add this `using` statement to where the dialog will be used

```csharp
using static WinFormDialogs.Dialogs;
```

Ask a question

```csharp
if (Question("Want to go for lunch?"))
{
    
}
```

