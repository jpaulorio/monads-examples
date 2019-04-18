using System;
using static OptionFactory;
using static WriterFactory;

namespace c_sharp
{
    class WriterMonadExample
    {
        static void Main(string[] args)
        {
            var result1 =
              Writer(1 + 1, "started with 2")
              .SelectMany(x => Writer(x + 3, "added 3"), (r1,r2) => new {r1 = r1, r2 = r2})
              .SelectMany(x => Writer(x.r2.ToString(), "converted to string"), (r2,r3) => $"INFO: Result is {r3}");

            Console.WriteLine($"{result1.Value} and the log is: {result1.Log}");

            var result2 =
              from r1 in Writer(1 + 1, "started with 2")
              from r2 in Writer(r1 + 3, "added 3")
              from r3 in Writer(r2.ToString(), "converted to string")
              select $"INFO: Result is {r3}";

            Console.WriteLine($"{result2.Value} and the log is: {result2.Log}");
        }
    }
}
