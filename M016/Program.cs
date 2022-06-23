using System.Collections;
using System.Diagnostics;

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		if (w1 == w2) //Standardmäßig werden HashCodes (Speicheradressen) verglichen
		{

		}

		Zug z = new();
		z += w1;
		z++;

		foreach (Wagon w in z)
		{

		}

		Wagon wagon1 = z["Wagon1"];
		//z["Wagon1"] = new();
		z[3] = new();
		Console.WriteLine(z[40, "Rot"].Name);

		System.Timers.Timer t = new();
		t.Elapsed += (x, y) => { Console.WriteLine("1 Sekunde vergangen"); };
		t.Interval = 1000;
		t.Start();

		Console.ReadKey();

		Stopwatch sw = new Stopwatch();
		sw.Start();
		Thread.Sleep(1500);
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}

public class Zug : IEnumerable
{
	List<Wagon> Wagons = new();

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public Wagon this[string name] => Wagons.First(e => e.Name == name);

	public Wagon this[int index]
	{
		get => Wagons[index];
		set => Wagons[index] = value;
	}

	public Wagon this[int anzSitze, string farbe] => Wagons.First(e => e.Sitzplaetze == anzSitze && e.Farbe == farbe);

	public static Zug operator +(Zug z, Wagon w) 
	{
		z.Wagons.Add(w);
		return z;
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new());
		return z;
	}
}

public class Wagon
{
	public string Name;

	public int Sitzplaetze;

	public string Farbe;

	public static bool operator ==(Wagon w1, Wagon w2)
	{
		return w1.Sitzplaetze == w2.Sitzplaetze && w1.Farbe == w2.Farbe;
	}

	public static bool operator !=(Wagon w1, Wagon w2)
	{
		return !(w1 == w2);
	}
}