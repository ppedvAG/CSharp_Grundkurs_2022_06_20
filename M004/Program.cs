namespace M004
{
	public class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b)
			{
				Console.WriteLine("while: " + a);
				if (a == 5)
					break; //Break: beendet die Schleife
				a++;
			}

			while (true)
			{
				//Endlosschleife
			}

			int c = 0;
			int d = 10;
			do //wird mindestens einmal ausgeführt
			{
				c++;
				if (c == 5)
					continue;
				Console.WriteLine("do-while: " + c);
			}
			while (c < d);

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("for: " + i);
			}

			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine("forr: " + i);
			}

			for (int i = 0, j = 1; ; i++, j *= 2) //Mehrere Zähler und Inkrementierungen, Endlosschleife wenn keine Bedingung
			{

			}

			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			foreach (int item in zahlen) //Kein daneben greifen bei Arrays möglich
			{
				Console.WriteLine(item);
			}
			#endregion

			#region Enums
			Wochentag heute = Wochentag.Mo;

			int x = 4;
			Wochentag wt = (Wochentag) x; //int zu Wochentag casten
			Wochentag stringWochentag = Enum.Parse<Wochentag>("Mo"); //string zu enum parsen
			//Wochentag stringWochentag2 = (Wochentag) Enum.Parse(typeof(Wochentag), "Mo"); //string zu enum parsen

			for (int i = 0; i < Enum.GetValues<Wochentag>().Length; i++)
				Console.WriteLine((Wochentag) i); //Alle Werte printen

			switch (heute)
			{
				case Wochentag.Mo:
					Console.WriteLine("Wochenanfang");
					break;
				case Wochentag.Di:
				case Wochentag.Mi:
				case Wochentag.Do:
					Console.WriteLine("Wochenmitte");
					break;
				case Wochentag.Fr:
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default:
					Console.WriteLine("Fehler");
					break;
			}

			switch (heute) //switch mit boolscher Logik
			{
				//and und or statt && und ||
				case >= Wochentag.Mo and <= Wochentag.Fr:
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
			}
			#endregion
		}

		public void PrintWochentag(Wochentag wt) { } //Werte fixieren statt mit strings

		public enum Wochentag
		{
			Mo = 1, //Startindex setzen
			Di,
			Mi,
			Do = 10, //ab hier neu zählen
			Fr,
			Sa,
			So
		}
	}
}