namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			int[] zahlen = new int[10]; //Array mit Länge 10 (0-9)
			zahlen[1] = 8;
			Console.WriteLine(zahlen[1]); //8

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung, Länge automatisch
			
			int[] zahlenDirektKuerzer = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise
			
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Noch kürzer

			Console.WriteLine(zahlen.Length); //10

			Console.WriteLine(zahlenDirekt.Length); //5

			zahlen.Sum(); //8

			bool b = zahlen.Contains(8);

			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3)
			zweiDArray[1, 1] = 3;
			Console.WriteLine(zweiDArray.Length); //9
			Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen (2)
			Console.WriteLine(zweiDArray.GetLength(0)); //Erste Dimension Länge (3)

			int[,] zweiDDirekt =
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			}; //3x2 automatisch

			int[,,] dreiDArray = new int[3, 3, 3]; //3x3x3 Array
			int test = dreiDArray[1, 1, 1]; //Drei Indizes
			#endregion

			#region Bedingungen
			int zahl1 = 8;
			int zahl2 = 5;

			bool kleiner = zahl1 < zahl2;
			if (kleiner)
			{
				//...
			}

			bool sehrLangerBooleanName = true;
			sehrLangerBooleanName = !sehrLangerBooleanName;
			//XOR: true wenn die Inputs unterschiedlich sind (true, false oder false, true)
			sehrLangerBooleanName ^= true; //Boolean invertieren mit XOR

			if (zahl1 < zahl2)
			{

			}
			else if (zahl1 == zahl2)
			{
				//...
			}
			else
				Console.WriteLine("Else");

			//if (zahl1 < zahl2)
			//{

			//}
			//else
			//{
			//	if (zahl1 == zahl2)
			//	{
			//		//...
			//	}
			//}
				
			if (zahl1 == zahl2)
				Console.WriteLine("Gleich");
			else
				Console.WriteLine("Ungleich");

			//Fragezeichen Operator (?, :) ? ist if, : ist else
			//Braucht immer ein else (:)
			Console.WriteLine(zahl1 == zahl2 ? "Gleich" : "Ungleich");
			#endregion
		}
	}
}