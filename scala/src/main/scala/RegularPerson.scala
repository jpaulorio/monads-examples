case class RegularPerson(name: String, reportsTo: RegularPerson) {

}

object RegularPerson {
  def getSupervisorName(employee: RegularPerson): String = {
    if (employee != null) {
      val supervisor = employee.reportsTo

      if (supervisor != null) {
        val supervisorsSupervisor = supervisor.reportsTo

        if (supervisorsSupervisor != null) {
          supervisorsSupervisor.name
        } else {
          null
        }
      } else {
        null
      }
    } else {
      null
    }
  }
}