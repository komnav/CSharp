﻿namespace Lesson2.Operation
{
    public static partial class Drop
    {
        public static double Dropes(double num1, double num2)
        {
            if (num1 == 0)
            {
                Console.WriteLine("Error");
            }

            return num1 / num2;
        }
    }
}