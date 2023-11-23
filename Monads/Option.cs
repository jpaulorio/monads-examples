using System;

public class Option<TValue>
{
    private readonly TValue value;
    private readonly bool hasValue;

    internal Option(TValue value, bool hasValue)
    {
        this.value = value;
        this.hasValue = hasValue;
    }

    public Option<TResult> Select<TResult>(Func<TValue, TResult> mapperExpression)
    {
        if (this.hasValue)
        {
            return Some(mapperExpression(this.value));
        }
        return None<TResult>();
    }

    public Option<TResult> SelectMany<TIntermediate, TResult>(
    Func<TValue, Option<TIntermediate>> mapper,
    Func<TValue, TIntermediate, TResult> getResult)
    {
        if (this.hasValue)
        {
            var intermediate = mapper(this.value);
            if (intermediate.hasValue)
            {
                return Some(getResult(this.value, intermediate.value));
            }
        }
        return None<TResult>();
    }

    public TValue GetOrElse(TValue orElse)
    {
        return this.hasValue ? this.value : orElse;
    }

    public static Option<T> Some<T>(T value) => new Option<T>(value, true);

    public static Option<T> None<T>() => new Option<T>(default(T), false);
}