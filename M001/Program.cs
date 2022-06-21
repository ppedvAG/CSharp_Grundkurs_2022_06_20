using M008;

public class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!");
		AccessModifier am;
	}
}

public class Test : AccessModifier
{
	public Test()
	{
		Console.WriteLine(Lieblingsfarbe); //Protected
	}
}