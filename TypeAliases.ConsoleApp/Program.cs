using TypeAliases.ConsoleApp;

Console.WriteLine("\n-- TUPLES --");
TupleDemo.Run();

Console.WriteLine("\n-- GENERICS - Discriminated Unions --");
GenericsDemo_Unions.Run("one");
GenericsDemo_Unions.Run(1);

Console.WriteLine("\n-- GENERICS - Long type names --");

var terseDemo = new GenericsDemo_LongClassNames();
DemoGetAll();
DemoGetById(15);
DemoGetById(9001);
DemoTryAdd("Donald", "Duck");
DemoTryAdd("Captain", "America");

void DemoGetAll()
{
    foreach (var (id, person) in terseDemo.GetAll())
    {
        Console.WriteLine($"{id}: {person}");
    }
}

void DemoGetById(int id)
{
    terseDemo.GetById(id).Switch(
        found => Console.WriteLine($"Found person with id {id}: {found}"),
        notFound => Console.WriteLine($"Could not find person with id {id}. Details: {notFound}"));
}

void DemoTryAdd(string firstName, string lastName)
{
    var result = terseDemo.TryAdd(new(0, firstName, lastName));
    var message = result.Match(
        success => $"Person added successfully with id {success}",
        error => $"Failed to add person. Another exists with the same hashed id: {error}");

    Console.WriteLine(message);
}