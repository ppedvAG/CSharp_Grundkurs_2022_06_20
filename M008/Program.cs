namespace M008;

public class Program
{
	static void Main(string[] args)
	{
		Lebewesen lw = new Lebewesen("Max");
		Mensch m = new Mensch("Max", 23);
		lw.WasBinIch();
		m.WasBinIch();
	}
}

public class Lebewesen //Basisklasse
{
	public string Name { get; set; }

	public Lebewesen(string name)
	{
		Name = name;
	}

	public virtual void WasBinIch() //virtual: kann überschrieben werden, muss aber nicht
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}
}

public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name)
	{
		Alter = alter;
	}

	//override <Leertaste>: Vorschläge holen
	public sealed override void WasBinIch() //überschreiben mittels override
	{
		Console.WriteLine($"Ich bin ein Mensch und mein Name ist {Name}"); //Name wird vererbt
	}
}

//public class Kind : Mensch //Vererbung nicht möglich, da sealed
//{
//	public Kind(string name, int alter) : base(name, alter)
//	{
//	}

//	override void WasBinIch() { }
//}