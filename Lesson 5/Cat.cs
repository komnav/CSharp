namespace Lesson_5;

public class Cat : Animal
{
    private string TypeFood { get; set; }

    public Cat(string name, int age, string typeFood, string type) : base(name, age, type)
    {
        TypeFood = typeFood;
    }

    public void Eat()
    {
        Console.WriteLine($"{Name} is eating {TypeFood} and type of animal:{Type} - age:{Age} ");
    }
}