using OneOf;

namespace TypeAliases.ConsoleApp;

using StringOrNumber = OneOf<string, int>;

public class GenericsDemo_Unions
{
    public static void Run(StringOrNumber val)
    {
        string message = val.Match(
            stringValue => $"{stringValue} is a string",
            numberValue => $"{numberValue} is an integer");

        Console.WriteLine(message);
    }
}