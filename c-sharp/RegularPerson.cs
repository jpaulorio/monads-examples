using System;

public class RegularPerson
{
    public String Name { get; set; }

    public RegularPerson ReportsTo { get; set; }

    public RegularPerson(String name, RegularPerson reportsTo)
    {
        this.Name = name;
        this.ReportsTo = reportsTo;
    }

    public static String GetSupervisorName(RegularPerson employee)
    {
        if (employee != null)
        {
            var supervisor = employee.ReportsTo;

            if (supervisor != null)
            {
                var supervisorsSupervisor = supervisor.ReportsTo;

                if (supervisorsSupervisor != null)
                {
                    return supervisorsSupervisor.Name;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}