# About

Shared class project used for .NET Core 5 projects.

--- 

:green_circle:  **ControlExtensions.InvokeIfRequired**

Provides generic [Invoke](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.invoke?view=net-5.0) method to prevent cross thread violation for async operations



# Requires

:heavy_check_mark: The following [database script](https://gist.github.com/karenpayneoregon/9bdf1a7d5310ac1d562b2326d79d6038) to run.

:heavy_check_mark: C# 9

![net](assets/Versions.png)

**SortableBindingList&lt;T&gt;**

Provides capability to sort a DataGridView.

:white_medium_square: Setup private variable in a form

```csharp
/*
 * Strong type container which provides sorting ability in the DataGridView
 */
private SortableBindingList<Products> _productView;

/*
 * Container for DataGridView.DataSource
 */
private readonly BindingSource _productBindingSource = new BindingSource();

```

:white_medium_square: Read data, assign to the BindingList

```csharp
_productView = new SortableBindingList<Products>(await Operations.GetProducts(categoryIdentifier));
```

Assign the BindingList to the BindingSource

```csharp
_productBindingSource.DataSource = _productView;
```

:white_medium_square: Get the current item

```csharp
var currentProduct = _productView[_productBindingSource.Position];
```



