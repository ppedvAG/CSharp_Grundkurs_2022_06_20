namespace M009
{
	public static class StaticClass //kein Objekt erstellen, und keine Vererbung möglich
	{
		public static void Test() { }
	}

	public class PrivateKonstruktor //kein Objekt erstellen, aber Vererbung möglich
	{
		private PrivateKonstruktor() { }
	}
}
