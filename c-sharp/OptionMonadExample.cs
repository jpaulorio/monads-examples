using System;
using static OptionFactory;

namespace c_sharp
{
    class OptionMonadExample
    {
        static void Main(string[] args)
        {
            Option<Person> personWithSupervisor = Some(new Person("Person",
                Some(new Person("Persons's supervisor",
                    Some(new Person("Persons's supervisor's supervisor", None<Person>()))))));

            Option<String> result = Person.GetSupervisorName(personWithSupervisor);

            Console.WriteLine(result.GetOrElse("Person does not have a supervisor's supervisor."));

            Option<Person> personWithoutSupervisor = Some(new Person("Person",
              Some(new Person("Persons's supervisor", None<Person>()))));

            Option<String> result2 = Person.GetSupervisorName(personWithoutSupervisor);

            Console.WriteLine(result2.GetOrElse("Person does not have a supervisor's supervisor."));
        }
    }
}
