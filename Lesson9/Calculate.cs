using System.Numerics;

namespace Losson9;

public class Calculate
{
    public T Add<T>(T a, T b) where T : INumber<T>
    {
        return a + b;
    }

    public T Minus<T>(T a, T b) where T : INumber<T>
    {
        return a - b;
    }

    public T Multiple<T>(T a, T b) where T : INumber<T>
    {
        return a * b;
    }

    public T Drop<T>(T a, T b) where T : INumber<T>
    {
        return a / b;
    }
}