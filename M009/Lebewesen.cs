namespace M009;

public abstract class Lebewesen //Verhindert Erstellung vom Objekt
{
	public string Name { get; set; }

	public Lebewesen(string name)
	{
		Name = name;
	}

	public abstract void WasBinIch(); //Abstrakte Methode ohne Body
}

public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name)
	{
		Alter = alter;
	}

	//override <Leertaste>: Vorschläge holen
	public override void WasBinIch() //überschreiben mittels override
	{
		Console.WriteLine($"Ich bin ein Mensch und mein Name ist {Name}"); //Name wird vererbt
	}
}

public class Hund : Lebewesen
{
	public Hund(string name) : base(name) { }

	public override void WasBinIch()
	{
		throw new NotImplementedException();
	}
}