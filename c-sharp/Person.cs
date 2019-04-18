using System;

public class Person
{
    public String Name { get; set; }

    public Option<Person> ReportsTo { get; set; }

    public Person(String name, Option<Person> reportsTo)
    {
        this.Name = name;
        this.ReportsTo = reportsTo;
    }

    public static Option<String> GetSupervisorName(Option<Person> maybeEmployee)
    {
        return from employee in maybeEmployee
               from supervisor in employee.ReportsTo
               from supervisorSupervisor in supervisor.ReportsTo
               select supervisorSupervisor.Name;
    }
}