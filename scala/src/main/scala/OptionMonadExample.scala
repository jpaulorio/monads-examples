
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
  }
}