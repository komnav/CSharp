namespace Lesson_5;

public class Person
{
    public string Name { get; set; }

    private int _age;

    public virtual int Age
    {
        get => _age;
        set
        {
            if (value > 0 && value < 100)
            {
                _age = value;
            }
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Write()
    {
        Console.WriteLine(Name + "   " + Age);
    }
}