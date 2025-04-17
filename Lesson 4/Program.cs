public class Person
{
    public string Name { get; set; }



    public void GetInfo()
    {
        Console.WriteLine($"Original: {Name}");
    }
    void test()
    {
        int a = 5;
        object mya = a;

        int b = 5;
        object myb = b;


        bool res1 = a == b;//true
        bool result = mya == myb;//?

        


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