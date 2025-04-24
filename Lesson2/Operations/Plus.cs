using System.Numerics;

namespace Lesson2.Operations
{
    public static partial class Plus
    {
        public static T Plusses<T>(T num1, T num2)
        where T: INumber<T>
        {
            return num1 + num2;
        }
    }
}