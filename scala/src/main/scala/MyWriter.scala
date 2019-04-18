case class MyWriter[A](value: A, log: String) {
  def map[B](f: A => B) = MyWriter(f(value), log)

  def flatMap[B](f: A => MyWriter[B]): MyWriter[B] = {
    f(value) match {
      case MyWriter(result, d) => MyWriter(result, s"$log $d")
    }
  }
}
