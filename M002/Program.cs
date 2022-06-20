namespace M002;

/// <summary>
/// Die Program Klasse
/// </summary>
internal class Program
{
	/// <summary>
	/// Die Main Methode
	/// </summary>
	/// <param name="args">Die Programmargumente</param>
	static void Main(string[] args)
	{
		#region Variablen
		int zahl;
		zahl = 5;
		Console.WriteLine(zahl); //cw + Tab + Tab -> Console.WriteLine

		int zahlMitZuweisung = 5;
		Console.WriteLine(zahlMitZuweisung);

		int zahlMalZwei = zahl * 2;
		Console.WriteLine(zahlMalZwei);

		string wort = "Hallo";
		Console.WriteLine(wort);

		/*
		 * Mehrzeiliger
		 * Kommentar
		 */

		char zeichen = 'A';
		Console.WriteLine(zeichen);

		double kostenDouble = 94.28;

		float kostenFloat = 446_729_842_375_988.38f; //Konvertierung von double zu float mit f, Tausendertrennzeichen mit _

		decimal kostenDecimal = 446_729_842_375_988.22m; //Konvertierung mit m, decimal für Geldwerte (weil geringe Gleitkommaungenauigkeit)

		bool b = true;
		b = false;

		string kombination = "Das Wort ist " + wort;
		Console.WriteLine(kombination);

		string interpolation = $"Das Wort ist {wort}"; //String Interpolation mit $ vor dem string und Code in { }
		Console.WriteLine(interpolation);

		Console.WriteLine("Das Wort ist {0}", wort);

		//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170

		string umbruch = $"Das Wort \n ist {wort}";
		Console.WriteLine(umbruch);

		string tab = $"Das Wort ist\t{wort}";
		Console.WriteLine(tab);

		char leer = '\0';
		char einzelHK = '\'';

		string pfad = "C:\\Users\\User";

		//Verbatim string nimmt alles wie geschrieben
		string verbatim = @$"Das Wort \n
ist {wort}";
		Console.WriteLine(verbatim);

		string pfadVerbatim = @"C:\Users\User";
		#endregion

		#region Eingabe
		string eingabe = Console.ReadLine();
		Console.WriteLine(eingabe);

		int inputZahl = int.Parse(eingabe); //string zu int konvertieren
		Console.WriteLine(inputZahl * 2);

		char c = Console.ReadKey().KeyChar; //Enter automatisch

		int convert = Convert.ToInt32(eingabe); //Convert statt Parse (funktioniert fast gleich)
		#endregion

		#region Konvertierungen
		//Impliziter Cast
		int implizit = 50;
		double implizitDoble = implizit; //int passt in double

		//Expliziter Cast
		double d = 435.382;
		float f = (float) d; //double ist größer float -> möglicher Verlust

		Console.WriteLine(implizit.ToString()); //ToString um alles mögliche zu einem string zu konvertieren
		#endregion

		#region Arithmetik
		int zahl1 = 7;
		int zahl2 = 3;
		Console.WriteLine(zahl1 % zahl2); //Rest der Division: 1

		Console.WriteLine(zahl1 + zahl2); //Originale Zahlen werden nicht verändert

		zahl1 += zahl2; //Addition auf zahl1 -> 10
		zahl1++; //Erhöhe Zahl um 1

		Math.Ceiling(4.2); //5
		Math.Floor(4.2); //4
		Math.Round(4.9); //Nächste gerade Zahl: 4
		Math.Round(5.1); //Nächste gerade Zahl: 6

		Math.Round(5.328579, 2); //Auf 2 Kommastellen runden

		Console.WriteLine(zahl1 / zahl2); //int Division, Ergebnis 2
		Console.WriteLine((double) zahl1 / zahl2); //double Division, Ergebnis 2.3333
		#endregion

		//Strg + K, C: Alle markierten Zeilen auskommentieren
		//Strg + K, U: Alle markierten Zeilen einkommentieren
		//Console.WriteLine("Test");
		//Console.WriteLine("Test");
		//Console.WriteLine("Test");
		//Console.WriteLine("Test");
	}
}