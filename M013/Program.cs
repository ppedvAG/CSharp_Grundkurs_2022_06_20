namespace M013
{
	internal class Program
	{
		delegate void Vorstellungen(string name); //Speichert Referenzen zu Methoden mit der selben Struktur

		static void Main(string[] args)
		{
			Vorstellungen vorstellungen = new Vorstellungen(VorstellungDE);
			vorstellungen += VorstellungEN;
			vorstellungen += VorstellungEN;
			vorstellungen += VorstellungEN; //Methoden können mehrmals angehängt werden
			vorstellungen -= VorstellungDE; //Methode abziehen
			vorstellungen("Max");

			if (vorstellungen != null) //Null-Check vor Ausführung
				vorstellungen("Max");

			vorstellungen?.Invoke("Max"); //Null-Check mit ? vor Punkt (wenn Variable nicht null, führe den Code aus, sonst mach nichts)

			foreach (Delegate dg in vorstellungen.GetInvocationList()) //Alle Methoden vom Delegate anschauen
			{
				Console.WriteLine(dg.Method.Name);
			}

			vorstellungen = null; //Alle Methoden entfernen
		}

		public static void VorstellungDE(string name)
		{
			Console.WriteLine($"Mein Name ist {name}");
		}

		public static void VorstellungEN(string name)
		{
			Console.WriteLine($"My name is {name}");
		}
	}
}