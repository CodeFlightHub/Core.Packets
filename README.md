<p align="center">
  <a href="https://github.com/CodeFlightHub/Core.Packets/commits/dev"><img src="https://img.shields.io/github/commit-activity/t/CodeFlightHub/Core.Packets?style=for-the-badge"></a>
  <a href="https://github.com/CodeFlightHub/Core.Packets/graphs/contributors"><img src="https://img.shields.io/github/contributors/CodeFlightHub/Core.Packets.svg?style=for-the-badge"></a>
  <a href="https://github.com/CodeFlightHub/Core.Packets/network/members"><img src="https://img.shields.io/github/forks/CodeFlightHub/Core.Packets.svg?style=for-the-badge"></a>
  <a href="https://github.com/CodeFlightHub/Core.Packets/stargazers"><img src="https://img.shields.io/github/stars/CodeFlightHub/Core.Packets.svg?style=for-the-badge"></a>
  <a href="https://github.com/CodeFlightHub/Core.Packets/issues"><img src="https://img.shields.io/github/issues/CodeFlightHub/Core.Packets.svg?style=for-the-badge"></a>
  <a href="https://github.com/CodeFlightHub/Core.Packets/blob/master/LICENSE"><img src="https://img.shields.io/github/license/CodeFlightHub/Core.Packets.svg?style=for-the-badge"></a>
</p><br />

# CodeFlightHub CorePackets

In development stage.


#  About

This project aims to enrich the open source community by providing core tools and patterns available as NuGet packages. It includes a set of tools and patterns covering recurring needs, common methods and functionalities commonly used in projects in the .NET core ecosystem. It aims to increase productivity by accelerating development processes.


# Packages

| Package Name | Package | Download |
| ------------- | ------------- | ------------- |
| CodeFlightHub.CorePackets.QuickExtend | - | - |
| CodeFlightHub.CorePackets.QuickRepository | - | - |
| CodeFlightHub.CorePackets.QuickCache | - | - |

# About QuickExtend 
QuickExtend is a library of extension methods that provide additional functionality to various .Net Core projects. This library aims to quickly solve common and recurring needs, usually facilitating the use of HttpClient to manage HTTP requests, from string manipulation to date and time operations, from Reflection operations to collection operations.
<ul>
  <li>Total 211 extension method</li>
  <li>Total 457 unit test</li>
</ul>


| Extension Name | Method Count|
| ------------- | ------------- | 
| Array | 17 | 
| Collection | 6 | 
| DateTime | 21 | 
| Dictionary | 17 | 
| Enum | 2 | 
| Enumerable | 9 | 
| HttpClient | 30 | 
| IPAddress | 36 | 
| Reflection | 10 | 
| Stream | 12 | 
| String | 25 | 
| Task | 4 | 
| Uri | 22 | 

### Array
- `T[] Flatten<T>(this T[][] array)` : Flattens a jagged array (array of arrays) into a one-dimensional array.
- `T[] FilterElements<T>(this T[] array, Func<T, bool> predicate)` : Filters the elements of an array based on a specified predicate function and returns a new array containing the filtered elements in reverse order.


## String

- `String? CapitalizeFirstLetter(this string? input)` : Capitalizes the first letter of each word in a string.
- `TimeSpan ToTimeSpan(this string input, TimeSpan defaultValue = default)` : Converts a string to a TimeSpan. Returns the default value if conversion fails.

## Reflection
- `void InvokeMethodByName(this object obj, string methodName, params object[] parameters)` : Invokes the specified method by name on the provided object with the given parameters.
- `void SetPropertyByName(this object obj, string propertyName, object newValue)` : Extension method that sets the value of a specified property for an object.


## etc..  


# IEnumerable Paginate


```c#
    /// <summary>
    /// Paginates the items in a collection based on a specified page number and page size.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection to be paginated.</param>
    /// <param name="pageNumber">Requested page number.</param>
    /// <param name="pageSize">Page size.</param>
    /// <returns>Collection paginated based on the specified page number and size.</returns>
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }

```

# Example Basic Usage QuickExtend 

```c#
using CodeFlightHub.CorePackets.QuickExtend;

    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> source = Enumerable.Range(1, 100);
            int pageNumber = 3;
            int pageSize = 5;

            var result = source.Paginate(pageNumber, pageSize);

            result.ForEach(x => Console.WriteLine(x)); // 11 12 13 14 15
        }
    }
```

# License

CodeFlightHub.CorePackets is **licensed** under the **[MIT License](https://github.com/Serhatkacmaz/Core.Packets/blob/master/LICENSE)**.
