namespace M013;

public class ActionPredicateFunc
{
	public static void Main(string[] args)
	{
		#region Action
		Action<int, int> action = Addiere; //Action: Methoden mit void und bis zu 16 Parameter
		action += Subtrahiere; //Methode dranhängen wie bei Delegate
		action(43, 90); //Aufruf ohne Null-Check
		action?.Invoke(32, 4); //Aufruf mit Null-Check

		DoSomethingWithNumber(436, 234, Addiere); //Verhalten der Methode anpassen anhand der Action
		DoSomethingWithNumber(436, 234, Subtrahiere); //Anderes Verhalten als darüber
		#endregion

		#region Predicate
		Predicate<int> predicate = CheckForZero; //Methode mit bool als Rückgabewert und genau einem Parameter
		bool isTrue = predicate.Invoke(84);

		CheckSomething(3, CheckForZero);
		#endregion

		#region Func
		Func<int, int, int> func = Multipliziere; //Methode mit beliebigem Rückgabewert (letztes Generic gibt den Rückgabewert an)
		int ergebnis = func.Invoke(34, 87);

		PrintErgebnis(34, 21, Multipliziere);
		PrintErgebnis(34, 21, Dividiere);
		#endregion

		#region Anonyme Methoden
		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode (älteste Form)
		func += (x, y) => { return x + y; }; //Anonyme Methode kürzer
		func += (x, y) => x + y; //Neueste Methode (schon gesehen bei Linq)

		PrintErgebnis(34, 21, (x, y) => x % y); //Anwendung von anonymer Methode
		#endregion
	}

	#region Action
	static void Addiere(int x, int y) => Console.WriteLine(x + y);

	static void Subtrahiere(int x, int y) => Console.WriteLine(x - y);

	static void DoSomethingWithNumber(int x, int y, Action<int, int> action) => action?.Invoke(x, y); //Action als Parameter
	#endregion

	#region Predicate
	static bool CheckForZero(int obj) => obj == 0;

	static bool CheckSomething(int x, Predicate<int> check) => check(x);
	#endregion

	#region Func
	static int Multipliziere(int arg1, int arg2) => arg1 * arg2;

	static int Dividiere(int arg1, int arg2) => arg1 / arg2;

	static void PrintErgebnis(int x, int y, Func<int, int, int> func) => Console.WriteLine(func(x, y));
	#endregion
}
