public class Person
{
    public string Name { get; set; }
    public void GetInfo()
    {
        Console.WriteLine($"Original: {Name}");
    }
}

public static class PersonExtensions
{
    public static void GetInfo(this Person person, string name)
    {
        Console.WriteLine($"Extention {name}");
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Andrey" };
        person.GetInfo("as");

        Console.ReadLine();
    }
}