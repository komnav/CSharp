using System.Numerics;

namespace Losson9;

public class Calculate<T>
    where T : INumber<T>
{
    public T Add<T>(T a, T b) where T : INumber<T>
    {
        return a + b;
    }

    public TInternal Minus<TInternal>(TInternal a, TInternal b)
        where TInternal : INumber<TInternal>
    {
        return a - b;
    }

    public T Multiple(T a, T b)
    {
        return a * b;
    }

    public T Drop<T>(T a, T b) where T : INumber<T>
    {
        return a / b;
    }
}