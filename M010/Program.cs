namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		//Mensch m = new Mensch();
		//m.Lohnauszahlung();

		Mensch mensch = new Mensch();
		IArbeit arbeit = mensch;
		arbeit.Lohnauszahlung();

		ITeilzeitArbeit ta = arbeit as ITeilzeitArbeit; //as-cast: funktioniert nur wenn Objekt null sein kann, selber Effekt wie regulärer Cast
		ta.Lohnauszahlung();

		((IArbeit) mensch).Lohnauszahlung();
		(mensch as ITeilzeitArbeit).Lohnauszahlung(); //Lohnauszahlung aufrufen ohne Variblenzuweisung

		int wochenlohn = arbeit.Gehalt / 160 * IArbeit.Wochenstunden; //statisches Feld
	}
}

public interface IArbeit //Interfaces fangen per Konvention mit I an
{
	static int Wochenstunden = 40;

	int Gehalt { get; set; }

	string Job { get; set; } //Properties werden auch vererbt

	void Lohnauszahlung(); //Leere Methode wie bei abstrakt

	public void Test()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit : IArbeit
{
	static new int Wochenstunden = 20; //new um Hierarchie zu trennen

	new void Lohnauszahlung(); //new um seperate Methode zu haben
}

public abstract class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit
{
	public int Gehalt { get; set; } = 3000;

	public string Job { get; set; } = "Softwareentwickler";

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt} für den Job {Job} bekommen. " +
			$"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche."); //Auf statische Variable zugreifen
	}

	void ITeilzeitArbeit.Lohnauszahlung() //explizite Implementierung, da zwei Interfaces mit gleichnamigen Methoden
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt} für den Job {Job} bekommen. " +
			$"Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche."); //Auf statische Variable zugreifen
	}
}