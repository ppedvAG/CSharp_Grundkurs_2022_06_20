namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new Exception();

		try
		{
			string eingabe = Console.ReadLine();
			int parse = int.Parse(eingabe);
			if (parse == 0)
				throw new TestException("Die eingegebene Zahl ist 0", "parse"); //Eigene Exception werfen
		}
		catch (FormatException e) //Keine Zahl
		{
			Console.WriteLine("Keine Zahl eingegeben");
			Console.WriteLine(e.StackTrace);
		}
		catch (OverflowException e) //Zu große/kleine Zahl
		{
			Console.WriteLine("Zahl außerhalb des gültigen Bereichs");
			Console.WriteLine(e.Message);
		}
		catch (TestException e) //Eigene Exception fangen
		{
			Console.WriteLine(e.Name);
			e.Test();
		}
		catch (Exception e) //Alle anderen Fehler abhandeln
		{
			Console.WriteLine($"Anderer Fehler: {e.Message}");
			if (e is ArithmeticException)
			{
				Console.WriteLine("Es ist eine ArithmeticException aufgetreten");
			}
			throw; //Fataler Fehler
		}
		finally //Wird immer ausgeführt, auch wenn keine Exception
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception; //ExceptionObject holen und casten
		File.WriteAllText(@"C:\Users\lk3\Desktop\Exception.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception
{
	public string Name { get; set; }

	public TestException(string? message, string name) : base(message) => Name = name;

	public void Test() => Console.WriteLine($"TestException ist aufgetreten: {Message}");
}