case class Person(name: String, reportsTo: MyOption[Person]) {

}

object Person {
  def getSupervisorName(maybeEmployee: MyOption[Person]): MyOption[String] = {
    for {
      employee <- maybeEmployee
      supervisor <- employee.reportsTo
      supervisorSupervisor <- supervisor.reportsTo
    } yield supervisorSupervisor.name
  }

  def getSupervisorName2(maybeEmployee: MyOption[Person]): MyOption[String] = {
    maybeEmployee
      .flatMap(employee => employee.reportsTo
        .flatMap(supervisor => supervisor.reportsTo
          .map(supervisorSupervisor => supervisorSupervisor.name)))
  }
}