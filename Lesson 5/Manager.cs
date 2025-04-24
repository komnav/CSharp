namespace Lesson_5;

public class Manager(string name, int age) : Client(name, age)
{
    private int _age1 = age;

    public override int Age
    {
        get => Age;
        set => _age1 = value;
    }

    public override void Write()
    {
        Console.WriteLine($"{Name} is a good manager and his age {_age1}");
    }
}