namespace M011_Linq;

public static class ExtensionMethods //Statische Klasse
{
	public static int Quersumme(this int x) //Statische Methode, mit this auf Typen beziehen
	{
		return x.ToString().ToCharArray().Sum(e => (int) char.GetNumericValue(e));
	}

	//Erweiterungsmethode mit Generic, wird verwendet wie normale Linq Methode
	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
	{
		return list.OrderBy(e => Random.Shared.Next());
	}

	public static void PrintList(this IEnumerable<Fahrzeug> list)
	{
		Console.WriteLine(list.Aggregate("", (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxGeschwindigkeit}km/h fahren.\n"));
	}
}
