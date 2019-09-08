# JsonPerformance
Performance test of JSON parsing by the new .NET Core 3 implementation

https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/

``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.6 (18G87) [Darwin 18.7.0]
Intel Core i7-6567U CPU 3.30GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100-preview9-014004
  [Host]     : .NET Core 3.0.0-preview9-19423-09 (CoreCLR 4.700.19.42102, CoreFX 4.700.19.42104), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-preview9-19423-09 (CoreCLR 4.700.19.42102, CoreFX 4.700.19.42104), 64bit RyuJIT


```
| Method |     Mean |    Error |    StdDev |
|------- |---------:|---------:|----------:|
| Newton | 350.7 us | 7.012 us | 17.331 us |
|  Core3 | 336.9 us | 2.313 us |  2.051 us |