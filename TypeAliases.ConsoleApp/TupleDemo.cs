namespace TypeAliases.ConsoleApp;

using Point2D = (int x, int y);

public class TupleDemo
{
    public static void Run()
    {
        Point2D point1 = (10, 20);
        Console.WriteLine($"{point1.x}, {point1.y}");

        Point2D point2 = new Point2D(20, 30);
        Console.WriteLine($"{point2.x}, {point2.y}");

        Point2D point3 = new (30, 40);
        Console.WriteLine($"{point3.x}, {point3.y}");
    }
}