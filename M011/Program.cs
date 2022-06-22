using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M011
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> staedte = new List<string>(); //Erstellung einer Liste mit Generic
			staedte.Add("Hamburg"); //Elemente hinzufügen
			staedte.Add("Wien");
			staedte.Add("Köln");
			staedte.Add("Berlin");

			Console.WriteLine(staedte[1]); //Wien

			Console.WriteLine(staedte.Count); //Count statt Length, nicht Count()

			staedte[1] = "Linz";

			staedte.Remove("Linz"); //Höhere Elemente werden aufgeschoben

			foreach (string s in staedte) //Liste iterieren wie bei Array
			{
				Console.WriteLine(s);
			}

			staedte.Sort(); //Liste sortieren

			Stack<string> staedteStack = new Stack<string>();
			staedteStack.Push("Hamburg"); //Elemente hinzufügen
			staedteStack.Push("Wien");
			staedteStack.Push("Köln");
			staedteStack.Push("Berlin");

			if (staedteStack.Count > 0)
			{
				Console.WriteLine(staedteStack.Peek()); //Oberstes Element anschauen

				Console.WriteLine(staedteStack.Pop()); //Oberstes Element anschauen und entfernen
			}

			Queue<string> staedteQueue = new Queue<string>();
			staedteQueue.Enqueue("Hamburg"); //Elemente hinzufügen
			staedteQueue.Enqueue("Wien");
			staedteQueue.Enqueue("Köln");
			staedteQueue.Enqueue("Berlin");

			if (staedteQueue.Count > 0)
			{
				Console.WriteLine(staedteQueue.Peek()); //Erstes Element anschauen

				Console.WriteLine(staedteQueue.Dequeue()); //Erstes Element anschauen und entfernen
			}

			Dictionary<string, int> einwohnerzahlen = new(); //Dictionary: Liste von Key-Value Paaren
			einwohnerzahlen.Add("Wien", 2_000_000); //Zwei Parameter (Key und Value)
			einwohnerzahlen.Add("Berlin", 3_650_000);
			einwohnerzahlen.Add("Paris", 2_160_000);

			if (einwohnerzahlen.ContainsKey("Wien"))
				Console.WriteLine(einwohnerzahlen["Wien"]); //Value holen mit [], hier mit dem Key (string)

			einwohnerzahlen.ContainsValue(2_000_000); //Gibt es eine Stadt mit 2m Einwohnern?

			//var: Compiler nimmt Typ automatisch an
			//var zu Typ mit Strg + .
			foreach (KeyValuePair<string, int> kv in einwohnerzahlen)
			{
				Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
			}

			SortedDictionary<string, int> einwohnerzahlenSorted = new(); //Sortiert sich nach jedem Add automatisch nach dem Key
			einwohnerzahlenSorted.Add("Wien", 2_000_000); //Zwei Parameter (Key und Value)
			einwohnerzahlenSorted.Add("Berlin", 3_650_000);
			einwohnerzahlenSorted.Add("Paris", 2_160_000);

			ObservableCollection<string> str = new();
			str.CollectionChanged += Str_CollectionChanged; //Event anhängen
			str.Add("X"); //Nach jedem Add wird das Event aufgerufen
			str.Add("Y");
			str.Add("Z");
		}

		private static void Str_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					Console.WriteLine($"Ein Element wurde hinzugefügt {e.NewItems[0]}");
					break;
				case NotifyCollectionChangedAction.Remove:
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
				case NotifyCollectionChangedAction.Move:
					break;
				case NotifyCollectionChangedAction.Reset:
					break;
			}
		}
	}
}