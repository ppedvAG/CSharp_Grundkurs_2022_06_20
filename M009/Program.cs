namespace M009
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Mensch m = new Mensch("Max", 23);

			Lebewesen lw = new Mensch("Max", 23); //Lebewesen: Variablentyp + Mensch: Laufzeittyp

			object o = new Mensch("Max", 23); //object: Basisklasse von allem

			o = m; //Zuweisung funktioniert auch
			lw = m;

			Console.WriteLine(o.GetType()); //M009.Mensch, Typ Objekt über bereits vorhandenes Object holen
			Console.WriteLine(typeof(Mensch).FullName); //M009.Mensch, Typ Objekt über Klassenname holen

			#region Laufzeittypvergleich
			if (lw.GetType() == typeof(Mensch)) //genauer Typvergleich
			{
				Console.WriteLine("lw ist Mensch"); //true
			}

			if (lw.GetType() == typeof(Lebewesen)) //keine Übereinstimmung
			{
				Console.WriteLine("lw ist Lebewesen"); //false
			}
			#endregion

			#region Variablentypvergleich
			if (lw is Mensch)
			{
				//true
			}

			if (lw is Lebewesen)
			{
				//true, weil Vererbungshierarchie wird beachtet
			}
			#endregion

			#region Virtual Override
			Mensch mensch = new Mensch("Max", 34);
			mensch.WasBinIch(); //Ich bin ein Mensch und mein Name ist Max

			Lebewesen l = mensch;
			l.WasBinIch(); //Ich bin ein Mensch und mein Name ist Max
			#endregion

			#region New
			Mensch mensch2 = new Mensch("Max", 34);
			mensch2.WasBinIch(); //Ich bin ein Mensch und mein Name ist Max

			Lebewesen l2 = mensch;
			l2.WasBinIch(); //Ich bin ein Lebewesen
			#endregion

			//new Lebewesen(); nicht möglich, da abstract

			Lebewesen[] array = new Lebewesen[3]; //Array von Lebewesen
			array[0] = new Mensch("Max", 34); //Alle Klassen die von Lebewesen erben können hinzugefügt werden
			array[1] = new Hund("Bello");
			array[2] = new Mensch("Max", 45);

			foreach (Lebewesen a in array)
			{
				a.WasBinIch(); //Überschreibung erzwungen, da WasBinIch() bei jedem Lebewesen aufrufbar
			}

			//new PrivateKonstruktor(); nicht möglich, da private Konstruktor
		}
	}
}