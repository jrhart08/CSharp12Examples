namespace Lambdas.ConsoleApp;

public class LambdaDemo
{
    public static void RunWithLocalFunction()
    {
        int Add1WithDefault(int number = 0) => number + 1;

        Console.WriteLine(Add1WithDefault());
        Console.WriteLine(Add1WithDefault(10));
    }
    
    public static void RunWithLambda()
    {
        var add1WithDefault = (int number = 0) => number + 1;

        Console.WriteLine(add1WithDefault());
        Console.WriteLine(add1WithDefault(10));
    }
}