sealed trait MyOption[+A] {
  def map[B](f: A => B): MyOption[B]

  def flatMap[B](f: A => MyOption[B]): MyOption[B]

  def getOrElse[T](orElse: T): T = {
    this match {
      case value: MySome[T] => value.value
      case _ => orElse
    }
  }
}

case class MySome[A](value: A) extends MyOption[A] {
  def map[B](f: A => B): MyOption[B] = MySome[B](f(value))

  def flatMap[B](f: A => MyOption[B]): MyOption[B] = f(value)
}

case object MyNone extends MyOption[Nothing] {
  def map[B](f: Nothing => B): MyOption[B] = MyNone

  def flatMap[B](f: Nothing => MyOption[B]): MyOption[B] = MyNone
}
