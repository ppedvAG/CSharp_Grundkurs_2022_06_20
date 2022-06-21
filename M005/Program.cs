namespace M005;

class Program
{
	static void Main(string[] args)
	{
		PrintAddition(4, 8);
		PrintAddition(7, 22);
		PrintAddition(4, 7);

		int add = Addiere(20, 4); //Rückgabewert zuweisen
		Console.WriteLine(add);

		double addD = Addiere(3, 5.5);
		Console.WriteLine(addD);

		int summe = Addiere(4, 6, 2, 9, 8, 1, 3, 5); //Beliebig viele Parameter
		Console.WriteLine(summe);

		int differenz = SubtrahiereUndAddiere(5, 2, 1);

		int outDifferenz; //Variablen miteinander verbinden über out
		int outSumme = SubtrahiereUndAddiere(8, 2, out outDifferenz);


		int out2 = SubtrahiereUndAddiere(3, 9, out int x); //out Variable direkt in der Funktion erstellt
		Console.WriteLine(x);

		if (int.TryParse("23", out int result)) //Resultat über out Parameter zurückgeben, TryParse gibt einen bool zurück ob Parsen funktioniert hat oder nicht
		{
			Console.WriteLine(result);
		}
		else
		{
			Console.WriteLine("Keine Zahl");
		}


		(int, int) subAdd = SubtrahiereUndAddiere(7, 2);
		Console.WriteLine($"{subAdd.Item1}, {subAdd.Item2}"); //Werte rausholen

		(int add, int sub) subAddNamen = SubtrahiereUndAddiereNamen(4, 2);
		Console.WriteLine($"{subAddNamen.add}, {subAddNamen.sub}"); //Werte rausholen

		(int add2, int sub2) = SubtrahiereUndAddiereNamen(4, 2);
		Console.WriteLine($"{add2}, {sub2}"); //Werte rausholen

		Console.WriteLine(PrintWochentag(Wochentag.Do));
	}

	static void PrintAddition(int z1, int z2) //void: kein Rückgabewert
	{
		Console.WriteLine($"{z1} + {z2} = {z1 + z2}");
	}

	static int Addiere(int z1, int z2)
	{
		return z1 + z2; //return: Wert zurückgeben
	}

	static double Addiere(double d1, double d2) //Methode mit selbem Namen möglich, da unterschiedliche Parameter
	{
		return d1 + d2;
	}

	static int Addiere(params int[] zahlen) //Beliebig viele Parameter, muss immer letzter Parameter sein
	{
		return zahlen.Sum();
	}

	static int SubtrahiereUndAddiere(int z1, int z2, int z3 = 0, bool addiere = false) //optionaler Parameter, beliebig viele, müssen immer nach allen erforderlichen Parametern stehen
	{
		//return addiere ? z1 - z2 + z3 : z1 - z2 - z3;
		if (addiere)
			return z1 - z2 + z3;
		else
			return z1 - z2 - z3;
	}

	static int SubtrahiereUndAddiere(int z1, int z2, out int differenz)
	{
		differenz = z1 - z2; //hier out Wert zurückgeben
		return z1 + z2;
	}

	static (int, int) SubtrahiereUndAddiere(int z1, int z2) //Mehrere Werte zurückgeben über Tupel
	{
		return (z1 + z2, z1 - z2);
	}

	static (int add, int sub) SubtrahiereUndAddiereNamen(int z1, int z2) //Benamte Tupel
	{
		return (z1 + z2, z1 - z2);
	}

	static void PrintZahl(int zahl)
	{
		Console.WriteLine(zahl);
		return; //Aus Funktion herausspringen / Funktion beenden
		Console.WriteLine(zahl); //kann nicht erreicht werden
	}

	static string PrintWochentag(Wochentag tag)
	{
		switch (tag)
		{
			case Wochentag.Mo: return "Montag";
			case Wochentag.Di: return "Dienstag";
			case Wochentag.Mi: return "Mittwoch";
			case Wochentag.Do: return "Donnerstag";
			case Wochentag.Fr: return "Freitag";
			case Wochentag.Sa: return "Samstag";
			case Wochentag.So: return "Sonntag";
			default: return "Fehler";
		}
	}
}

public enum Wochentag
{
	Mo,
	Di,
	Mi,
	Do,
	Fr,
	Sa,
	So
}