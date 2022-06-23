namespace M013;

internal class Events
{
	static event EventHandler Event; //Standard EventArgs

	static event EventHandler<TestEventArgs> TestEvent; //Event mit eigenen EventArgs

	static void Main(string[] args)
	{
		Event += Events_Event; //Ähnlich wie Delegate, kein new
		Event(null, EventArgs.Empty); //Aufruf

		TestEvent += Events_TestEvent;
		TestEvent(null, new TestEventArgs() { Status = "Ein Event" });

		EventComponent component = new();
		component.ValueChanged += (x) => Console.WriteLine("Status: " + x); //Action mit einem Parameter: (x) =>
		component.ProcessCompleted += () => Console.WriteLine("EventComponent Fertig"); //Action ohne Parameter mit () =>
		component.StartProcess();
	}

	private static void Events_TestEvent(object? sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
	}

	private static void Events_Event(object? sender, EventArgs e)
	{
		Console.WriteLine("Event wurde aufgerufen");
	}
}

public class TestEventArgs : EventArgs
{
	public string Status { get; set; }
}
