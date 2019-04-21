
object OptionMonadExample {
  def main(args: Array[String]): Unit = {
    val personWithSupervisor = MySome(new Person("Person",
      MySome(new Person("Persons's supervisor",
        MySome(new Person("Persons's supervisor's supervisor", MyNone))))))

    val result = Person.getSupervisorName(personWithSupervisor)

    println(result.getOrElse("Person does not have a supervisor's supervisor."))

    val personWithoutSupervisor = MySome(new Person("Person",
      MySome(new Person("Persons's supervisor", MyNone))))

    val result2 = Person.getSupervisorName(personWithoutSupervisor)

    println(result2.getOrElse("Person does not have a supervisor's supervisor."))

    val regularPersonWithSupervisor = new RegularPerson("Person",
      new RegularPerson("Persons's supervisor",
        new RegularPerson("Persons's supervisor's supervisor", null)))

    val result3 = RegularPerson.getSupervisorName(regularPersonWithSupervisor)
    println(result3)

    val regularPersonWithoutSupervisor = new RegularPerson("Person",
      new RegularPerson("Persons's supervisor", null))

    val result4 = RegularPerson.getSupervisorName(regularPersonWithoutSupervisor)
    if (result4 == null)
      println("Person does not have a supervisor's supervisor.")

    val result5 = Person.getSupervisorName2(personWithSupervisor)

    println(result5.getOrElse("Person does not have a supervisor's supervisor."))

    val result6 = Person.getSupervisorName2(personWithoutSupervisor)

    println(result6.getOrElse("Person does not have a supervisor's supervisor."))
  }
}