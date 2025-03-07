namespace Lesson2
{
    public class Calaculator
    {
        public double Plus(double num1, double num2)
        {
            return num1 + num2;
        }
        public double Minus(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiple(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Drop(double num1, double num2)
        {
            if (num1 == 0)
            {
                Console.WriteLine("Eror");
            }

            return num1 / num2;
        }
    }
}
