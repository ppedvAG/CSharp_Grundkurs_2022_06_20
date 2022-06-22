namespace M011_Linq;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Erstellt eine Liste von Start mit einer bestimmten Anzahl Elementen
		//(0, 10) -> 0 bis 9, (5, 10) -> 5 bis 14
		List<int> ints = Enumerable.Range(1, 9).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());
		Console.WriteLine(ints.Sum());

		Console.WriteLine(ints.First()); //Erstes Element, Exception wenn kein Element gefunden
		Console.WriteLine(ints.FirstOrDefault()); //Erstes Element, null wenn kein Element gefunden

		Console.WriteLine(ints.Last()); //Letztes Element, Exception wenn kein Element gefunden
		Console.WriteLine(ints.LastOrDefault()); //Letztes Element, null wenn kein Element gefunden
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Schreibweisen
		//Alle BMWs mit foreach
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsSQL = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Einfaches Linq mit Objektliste
		//Höchste Geschwindigkeit
		Console.WriteLine(fahrzeuge.Max(e => e.MaxGeschwindigkeit));

		//Fahrzeug mit Höchstgeschwindigkeit statt nur Geschwindigkeit
		Fahrzeug schnellstes = fahrzeuge.MaxBy(e => e.MaxGeschwindigkeit);

		//Fahrzeuge nach Geschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.MaxGeschwindigkeit).ToList();

		//Fahrzeuge nach mehreren Kriterien sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxGeschwindigkeit).ToList();

		//Langsamstes Fahrzeug
		fahrzeuge.OrderBy(e => e.MaxGeschwindigkeit).First();

		//Schnellstes Fahrzeug
		fahrzeuge.OrderByDescending(e => e.MaxGeschwindigkeit).First();

		//Alle Marken
		List<FahrzeugMarke> marken = fahrzeuge.Select(e => e.Marke).ToList();

		//Marken einmalig machen
		List<FahrzeugMarke> markenDistinct = marken.Distinct().ToList();

		//Alle Geschwindigkeiten aufsummieren
		fahrzeuge.Sum(e => e.MaxGeschwindigkeit);

		//Alle VWs aufsummieren mit mindestens 200km/h
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxGeschwindigkeit >= 200).Sum(e => e.MaxGeschwindigkeit);

		//Können alle Fahrzeuge über 150km/h fahren?
		fahrzeuge.All(e => e.MaxGeschwindigkeit >= 150);

		//Kann mindestens ein Fahrzeug über 150km/h fahren?
		fahrzeuge.Any(e => e.MaxGeschwindigkeit >= 150);

		//Mindestens ein Element in der Liste
		fahrzeuge.Any(); //fahrzeuge.Count > 0
		#endregion

		#region Komplexes Linq
		//Nach Fahrzeugmarke gruppieren (Audi Gruppe, BMW Gruppe, VW Gruppe)
		IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>> x = fahrzeuge.GroupBy(e => e.Marke);

		//Einzelne Gruppe holen (Audi Gruppe)
		List<Fahrzeug> audis = x.First(e => e.Key == FahrzeugMarke.Audi).ToList();

		//Group zu Dictionary konvertieren
		Dictionary<FahrzeugMarke, List<Fahrzeug>> dict = x.ToDictionary(e => e.Key, e => e.ToList());

		//Liste ausgeben
		Console.WriteLine(fahrzeuge.Aggregate("", (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxGeschwindigkeit}km/h fahren.\n"));

		foreach (Fahrzeug f in fahrzeuge)
			Console.WriteLine($"Das Fahrzeug hat die Marke {f.Marke} und kann maximal {f.MaxGeschwindigkeit}km/h fahren.");
		#endregion

		Console.WriteLine(38265.Quersumme());

		int zahl = 384275;
		Console.WriteLine(zahl.Quersumme());

		List<Fahrzeug> shuffled = fahrzeuge.Shuffle().ToList();
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}