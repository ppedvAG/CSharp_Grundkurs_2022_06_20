public class Program
{
	static void Main(string[] args)
	{
		//Eigenen Code hier schreiben
	}

	public void Addition(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
	}

	public void Subtraktion(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} - {zahl2} = {zahl1 - zahl2}");
	}

	public void Multiplikation(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} * {zahl2} = {zahl1 * zahl2}");
	}
}

public class DivisionsCalculator
{
	public void Division(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} : {zahl2} = {zahl1 /  zahl2}");
	}
}

public class PrimeComponent
{
	public void StartProcess()
	{
		//Thread.Sleep(200);
	}

	public bool CheckPrime(int num)
	{
		for (int i = num - 1; i >= 2; i--)
		{
			if (num % i == 0)
			{
				return false;
			}
		}
		return true;
	}
}