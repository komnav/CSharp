namespace Lesson_5;

public class Client(string name, int age) : Person(name, age)
{
    public override int Age
    {
        get => base.Age;

        set
        {
            if (value >= 18)
            {
                base.Age = value;
            }
        }
    }

    public override void Write()
    {
        Console.WriteLine($"{Name} is a good person his  age {Age}");
    }
}