public static class WriterFactory {
    public static Writer<T> Writer<T>(T value, string log) => new Writer<T>(value, log);

}