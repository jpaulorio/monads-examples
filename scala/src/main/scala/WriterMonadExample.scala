
object WriterMonadExample {
  def main(args: Array[String]): Unit = {
    val result =
      MyWriter(1 + 1, "started with 2")
        .flatMap(r1 => MyWriter(r1 + 3, "added 3")
          .flatMap(r2 => MyWriter(r2.toString, "converted to string")
            .map(r3 => s"INFO: Result is $r3")))

    println(s"${result.value} and the log is: ${result.log}")

    val result2 =
      for {
        r1 <- MyWriter(1 + 1, "started with 2")
        r2 <- MyWriter(r1 + 3, "added 3")
        r3 <- MyWriter(r2.toString, "converted to string")
      } yield s"INFO: Result is $r3"

    println(s"${result2.value} and the log is: ${result2.log}")
  }
}