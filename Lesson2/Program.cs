﻿Plus plus = new Plus();
Minus minus = new Minus();
Drop drop = new Drop();
Multiple multiple = new Multiple();

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
            result = plus.Plusses(num1, num2);
            break;
        case "-":
            result = minus.Minuses(num1, num2);
            break;
        case "*":
            result = multiple.Multiples(num1, num2);
            break;
        case "/":
            result = drop.Dropes(num1, num2);
            break;
        default:
            Console.WriteLine("Operation error");
            continue;
    }

    Console.WriteLine($"Result: {result}");
    Console.WriteLine("Do you want to continue yes or no?");
    var operate = Console.ReadLine();
    Console.ReadKey();

    if (operate == "no")
    {
        break;
    }
}





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