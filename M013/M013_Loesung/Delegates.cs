namespace M013_Loesung_2;

public class Program
{
	public delegate void Berechnungen(double z1, double z2);
	
	public static void Main(string[] args)
	{
		Berechnungen b = new Berechnungen(Addition);
		b += Subtraktion;
		b += Multiplikation;
		b += DivisionsCalculator.Division;
		
		Action<double, double> a = Addition;
		a += Subtraktion;
		a += Multiplikation;
		a += DivisionsCalculator.Division;
	}

	public static void Addition (double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
	}

	public static void Subtraktion(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} - {zahl2} = {zahl1 - zahl2}");
	}

	public static void Multiplikation(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} * {zahl2} = {zahl1 * zahl2}");
	}

}

public class DivisionsCalculator
{
	public static void Division(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} : {zahl2} = {zahl1 /  zahl2}");
	}
}