namespace M006;

public class Person
{
	#region Variable
	private string name;

	public string GetName()
	{
		return name;
	}

	public void SetName(string name) //Überprüfungen machen vor Wertzuweisung
	{
		if (name.Length >= 2 && name.Length <= 15)
			this.name = name;
	}
	#endregion

	#region Properties
	private string vorname;

	public string Vorname //Property statt Get und Set
	{
		get => vorname; //Expression Body mit => statt { } bei Einzeilern
		set //Hier auch wieder Checks
		{
			if (value.Length >= 2 && value.Length <= 15)
				vorname = value;
		}
	}

	private int gehalt;

	public int Gehalt
	{
		get => gehalt;
		private set => gehalt = value; //Gehalt kann von außen nicht gesetzt werden
	}

	public int Jahresgehalt => gehalt * 14; //Get-Only Property mit =>

	public string Lieblingsfarbe { get; set; } = "Blau"; //Property setzen wie normale Variable

	public string Auto { get; init; } = "VW"; //Init: Nur hier oder im Konstruktor setzbar
	#endregion

	#region Konstruktor
	//ctor + Tab + Tab
	public Person(string vorname, string nachname) //Standardkonstruktor (ohne Werte) wird überschrieben
	{
		this.vorname = vorname; //mit this nach oben greifen
		name = nachname;
	}

	public Person(string vorname, string nachname, int gehalt) : this(vorname, nachname)
	{
		this.gehalt = gehalt;
	}
	#endregion

	public void PrintPerson()
	{
		Console.WriteLine($"{Vorname} {name}");
	}
}
