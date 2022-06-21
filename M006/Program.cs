using AndererNamespace;

namespace M006
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person person = new Person("Max", "Muster", 2000);
			//person.Vorname = "Max";
			//person.Gehalt = 2000; funktioniert nicht
			person.Lieblingsfarbe = "Rot";
			person.PrintPerson();
			Console.WriteLine(person.Gehalt);
		}
	}

	namespace UnternamespaceInnerhalb
	{
		class Program { } //Hier weiter Program Klasse möglich
	}
}

namespace M006.UnternamespaceAusserhalb { }

namespace AndererNamespace
{
	public class AndereKlasse { }
}