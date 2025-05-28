namespace Lesson_7
{
    public class Person2
    {
        public string Name;
        public int Age { get; set; }

        public Person2(string name, int age)
        {
            Name= name;
            Age= age;
        }
        protected virtual void Test()
        {
            
        }
    }

    class MyClass:Person2
    {
        public MyClass(string name, int age) : base(name, age)
        {
        }

        protected override void Test()
        {
            
        }
    }
}
