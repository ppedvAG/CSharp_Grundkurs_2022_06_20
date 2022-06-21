namespace M007
{
	internal class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 25; i++)
			{
				Person p = new Person(i);
			}

			GC.Collect(); //Hier GC erzwingen
			GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren

			Person person = new Person(2);
			person.PrintID();

			//Person.PrintID(); nicht möglich, da nicht statisch
			Person.ZaehlePerson(); //Statische Methode über Typ aufrufen

			//Wertetyp
			int original = 5;
			int x = original;
			original = 10;

			//Referenztyp
			Person p1 = new Person(1);
			Person p2 = p1;
			p1.ID = 10;

			int anzahl = 0; //bei ref muss der Wert initialisiert sein
			Addiere(4, 5, ref anzahl);
			Addiere(4, 5, ref anzahl);
			Addiere(4, 5, ref anzahl);
		}

		static void Addiere(int z1, int z2, ref int anz) //"Referenz" herstellen, ähnlich wie out
		{
			Console.WriteLine(z1 + z2);
			anz++;
		}
	}
}