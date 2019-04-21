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

            RegularPerson regularPersonWithSupervisor = new RegularPerson("Person",
                new RegularPerson("Persons's supervisor",
                    new RegularPerson("Persons's supervisor's supervisor", null)));

            String result3 = RegularPerson.GetSupervisorName(regularPersonWithSupervisor);

            Console.WriteLine(result3);

            RegularPerson regularPersonWithoutSupervisor = new RegularPerson("Person",
              new RegularPerson("Persons's supervisor", null));

            String result4 = RegularPerson.GetSupervisorName(regularPersonWithoutSupervisor);

            if (result4 == null)
                Console.WriteLine("Person does not have a supervisor's supervisor.");

            Option<String> result5 = Person.GetSupervisorName2(personWithSupervisor);

            Console.WriteLine(result5.GetOrElse("Person does not have a supervisor's supervisor."));

            Option<String> result6 = Person.GetSupervisorName2(personWithoutSupervisor);

            Console.WriteLine(result6.GetOrElse("Person does not have a supervisor's supervisor."));
        }
    }
}
