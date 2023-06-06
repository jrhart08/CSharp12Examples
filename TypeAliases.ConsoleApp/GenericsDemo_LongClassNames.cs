using OneOf;

namespace TypeAliases.ConsoleApp;

using Person = ThisIsAVeryLongClassNameForAPersonDto;
using PeopleById = Dictionary<int, ThisIsAVeryLongClassNameForAPersonDto>;

public record AddPersonError(string FirstName, string LastName);

public record GetPersonError(int Id);

public class GenericsDemo_LongClassNames
{
    readonly PeopleById _peopleById;

    public GenericsDemo_LongClassNames()
    {
        _peopleById = new()
        {
            [18] = new Person(1, "Alice", "In Wonderland"),
            [13] = new Person(2, "Bob", "'s Burgers"),
            [14] = new Person(3, "Captain", "America"),
        };
    }
    
    public PeopleById GetAll() => _peopleById;

    public OneOf<Person, GetPersonError> GetById(int id)
    {
        if (_peopleById.TryGetValue(id, out var byId))
            return byId;

        return new GetPersonError(id);
    }

    public OneOf<int, AddPersonError> TryAdd(Person person)
    {
        var id = GetHashedId(person);

        if (_peopleById.TryGetValue(id, out var existing))
        {
            return new AddPersonError(existing.FirstName!, existing.LastName!);
        }
        
        _peopleById.Add(id, person);
        
        return id;
    }

    static int GetHashedId(Person person) => person.FirstName.Length + person.LastName.Length;
}