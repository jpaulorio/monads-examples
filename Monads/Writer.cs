using System;

public class Writer<TValue>
{
    private readonly TValue value;

    private readonly String log;

    internal Writer(TValue value, String log)
    {
        this.value = value;
        this.log = log;
    }

    public TValue Value => value;

    public string Log => log;

    public Writer<TResult> Select<TResult>(Func<TValue, TResult> mapperExpression)
    {
        return BuildWriter(mapperExpression(this.value), this.log);
    }

    public Writer<TResult> SelectMany<TIntermediate, TResult>(
    Func<TValue, Writer<TIntermediate>> mapper,
    Func<TValue, TIntermediate, TResult> getResult)
    {
        var intermediate = mapper(this.value);
        var result = BuildWriter(getResult(this.value, intermediate.value),
        this.log + " " + intermediate.log);
        return result;
    }

    public static Writer<T> BuildWriter<T>(T value, string log) => new Writer<T>(value, log);
}