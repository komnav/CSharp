

using Lesson_7;

List<Person2> person = new List<Person2>
{
    new Person2("Ali",12),
    new Person2("Vali",13),
    new Person2("Habib",19),
    new Person2("Islam",10),
};


var names = person.Select(s => s.Name);

foreach (var name in names)
{
    Console.WriteLine(name);
}


 var people = new List<Person>
 {
     new Person ("Tom", 23),
     new Person ("Bob", 27)
 };

 var personel = from p in people
                select new
                {
                    FirstName = p.Name,
                    Year = DateTime.Now.Year - p.Age
                };

 foreach (var p in personel)
     Console.WriteLine($"{p.FirstName} - {p.Year}");


 namespace Lesson_7
 {
     record class Person(string Name, int Age);
 }