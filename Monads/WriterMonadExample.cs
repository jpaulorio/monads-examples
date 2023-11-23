using System;
using static Writer<int>;

namespace monads
{
    public class WriterMonadExample
    {
        public static void Main(string[] args)
        {
            var result1 =
              BuildWriter(1 + 1, "started with 2")
              .SelectMany(x => BuildWriter(x + 3, "added 3"), (r1,r2) => new {r1 = r1, r2 = r2})
              .SelectMany(x => BuildWriter(x.r2.ToString(), "converted to string"), (r2,r3) => $"INFO: Result is {r3}");

            Console.WriteLine($"{result1.Value} and the log is: {result1.Log}");

            var result2 =
              from r1 in BuildWriter(1 + 1, "started with 2")
              from r2 in BuildWriter(r1 + 3, "added 3")
              from r3 in BuildWriter(r2.ToString(), "converted to string")
              select $"INFO: Result is {r3}";

            Console.WriteLine($"{result2.Value} and the log is: {result2.Log}");
        }
    }
}
