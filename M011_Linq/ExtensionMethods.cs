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
}
