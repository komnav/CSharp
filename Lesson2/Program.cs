using Lesson2.Operations;

Operations operations1 = Plus.Plusses;
Operations operations2 = Minus.Minuses;
Operations operations3 = Multiple.Multiples;
Operations operations4 = Drop.Dropes;


while (true)
{
    Console.Clear();

    Console.WriteLine("Num1: ");
    var num1 = double.Parse(Console.ReadLine());
    Console.WriteLine("Num2: ");
    var num2 = double.Parse(Console.ReadLine());

    Console.WriteLine("please enter correct number");


    Console.WriteLine("What operation do you want: +, -, /, *");
    var operation = Console.ReadLine();

    double result = 0;
    switch (operation)
    {
        case "+":
            result = operations1(num1, num2);
            Func<double, double, string> add = (num1, num2) => $"{num1} + {num2} = {num1 + num2}";
            var plus = add(num1, num2);
            Console.WriteLine(plus);
            break;
        case "-":
            result = operations2(num1, num2);
            Func<double, double, string> min = (num1, num2) => $"{num1} + {num2} = {num1 - num2}";
            var minus = min(num1, num2);
            Console.WriteLine(minus);
            break;
        case "*":
            result = operations3(num1, num2);
            Func<double, double, string> zarb = (num1, num2) => $"{num1} + {num2} = {num1 * num2}";
            var multiple = zarb(num1, num2);
            Console.WriteLine(multiple);
            break;
        case "/":
            result = operations4(num1, num2);
            Func<double, double, string> dr = (num1, num2) => $"{num1} + {num2} = {num1 / num2}";
            var drop = dr(num1, num2);
            Console.WriteLine(drop);
            break;
        default:
            Console.WriteLine("Operation error");
            continue;
    }




    Console.WriteLine($"Result: {result}");

    Action<string> write = null;
    write = Console.WriteLine;
    write(" Do you want to continue yes or no?");
    var operate = Console.ReadLine();
    Console.ReadKey();

    if (operate == "no")
    {
        break;
    }
}

delegate double Operations(double num1, double num2);



//var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7 };

//for (int i = 0; i < numbers.Length; i++)
//{
//    var value = numbers[i];
//    Console.WriteLine($"Index: {i}, value {value}");
//}

//foreach (int i in numbers)
//{
//    Console.WriteLine($"Value: {i}");
//    continue;
//}

//var index = 0;

//while (index < numbers.Length)
//{
//    var value = numbers[index];
//    Console.WriteLine($"Index: {index},  value: {value}");
//    index++;
//}

//do
//{
//    var value = numbers[index];
//    Console.WriteLine($"Index: {index},  value: {value}");
//    index++;
//} while (index < numbers.Length);