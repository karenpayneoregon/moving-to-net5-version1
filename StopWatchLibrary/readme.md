# About

Provides a single point for accurately measure elapsed time for task.

![img](https://img.shields.io/badge/Karen%20Payne-MVP-lightgrey)

![version](../assets/Versions.png)

The following line in [StopWatcher](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-5.0) class provides thread safe usage.
```csharp
private static readonly Lazy<StopWatcher> Lazy = new(() => new StopWatcher());
```

Access point to methods and properties in StopWatcher.

```csharp
public static StopWatcher Instance => Lazy.Value;
```