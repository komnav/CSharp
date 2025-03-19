using System.Threading.Channels;

Operations operations1 = Plus.Plusses;
Operations operations2 = Minus.Minuses;
Operations operations3 = Multiple.Multiples;
Operations operations4 = Drop.Dropes;

while (true)
{
    Console.Clear();

    Console.WriteLine("Num1: ");
    double num1 = double.Parse(Console.ReadLine());
    Console.WriteLine("Num2: ");
    double num2 = double.Parse(Console.ReadLine());


    Console.WriteLine("What operation do you want: +, -, /, *");
    var operation = Console.ReadLine();

    double result = 0;
    switch (operation)
    {
        case "+":
            result = operations1.Invoke(num1, num2);
            break;
        case "-":
            result = operations2.Invoke(num1, num2);
            break;
        case "*":
            result = operations3.Invoke(num1, num2);
            break;
        case "/":
            result = operations4.Invoke(num1, num2);
            break;
        default:
            Console.WriteLine("Operation error");
            continue;
    }
    Func<string, double, string> add = (num1, num2) => $"{num1} + {num2} = {result}";
    var res = add(num1.ToString(), num2);

    Console.WriteLine(res);
    Console.WriteLine($"Result: {result}");
    Console.WriteLine("Do you want to continue yes or no?");
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