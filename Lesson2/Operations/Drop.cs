namespace Lesson2.Operations
{
    public partial class Drop
    {

        public double Dropes(double num1, double num2)
        {
            if (num1 == 0)
            {
                Console.WriteLine("Eror");
            }

            return num1 / num2;
        }
    }
}
