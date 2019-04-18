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
            return OptionFactory.Some(mapperExpression(this.value));
        }
        return OptionFactory.None<TResult>();
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
                return OptionFactory.Some(getResult(this.value, intermediate.value));
            }
        }
        return OptionFactory.None<TResult>();
    }

    public TValue GetOrElse(TValue orElse)
    {
        return this.hasValue ? this.value : orElse;
    }
}