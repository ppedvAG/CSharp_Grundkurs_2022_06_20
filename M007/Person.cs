namespace M007;

public class Person
{
	public int ID { get; set; }

	public Person(int id) => ID = id;

	//~ + Tab + Tab
	~Person()
	{
		Console.WriteLine($"Person eingesammelt: {ID}");
	}

	public void PrintID() => Console.WriteLine(ID);

	#region Static
	public static int Zaehler = 0;

	public static void ZaehlePerson() => Zaehler++;
	#endregion
}
