using Lesson_7;

//List<Person> person = new List<Person>
//{
//    new Person("Ali",12),
//    new Person("Vali",13),
//    new Person("Habib",19),
//    new Person("Islam",10),
//};


//var names = person.Select(s => s.Name);

//foreach (var name in names)
//{
//    Console.WriteLine(name);
//}


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


record class Person(string Name, int Age);