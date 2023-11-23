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

    public static Option<String> GetSupervisorName2(Option<Person> maybeEmployee)
    {
        return maybeEmployee
        .SelectMany(x => x.ReportsTo, (r1, r2) => new { r1 = r1, r2 = r2 })
        .SelectMany(x => x.r2.ReportsTo, (r2, r3) => new { r2 = r2, r3 = r3 })
        .Select(x => x.r3.Name);
    }
}