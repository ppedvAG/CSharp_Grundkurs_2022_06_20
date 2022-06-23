using Microsoft.VisualBasic.FileIO;
using System.Text.Json;
using System.Xml.Serialization;

namespace M015;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Desktop: C:\Users\lk3\Desktop

		string folderPath = Path.Combine(desktop, "M015"); //C:\Users\lk3\Desktop\M015

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Ordner erstellen

		string filePath = Path.Combine(folderPath, "Test.txt"); //C:\Users\lk3\Desktop\M015\Test.txt

		//StreamWriterTest();

		//StreamReaderTest();

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Json
		string json = JsonSerializer.Serialize(fahrzeuge);
		File.WriteAllText(filePath, json);

		string jsonFile = File.ReadAllText(filePath);
		Fahrzeug[] fzg = JsonSerializer.Deserialize<Fahrzeug[]>(jsonFile);
		#endregion

		#region XML
		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		Stream str = new FileStream(filePath, FileMode.Create);
		xml.Serialize(str, fahrzeuge);

		Stream readStream = new FileStream(filePath, FileMode.Open);
		List<Fahrzeug> xmlFzg = xml.Deserialize(readStream) as List<Fahrzeug>;
		#endregion

		#region CSV
		TextFieldParser tfp = new TextFieldParser(filePath);
		tfp.SetDelimiters(";");

		string[] header = tfp.ReadFields(); //Header

		List<string[]> csvLine = new();
		while (!tfp.EndOfData)
		{
			csvLine.Add(tfp.ReadFields());
		}
		#endregion
	}

	public static void StreamWriterTest()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Desktop: C:\Users\lk3\Desktop

		string folderPath = Path.Combine(desktop, "M015"); //C:\Users\lk3\Desktop\M015

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Ordner erstellen

		string filePath = Path.Combine(folderPath, "Test.txt"); //C:\Users\lk3\Desktop\M015\Test.txt

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.Flush();
		sw.Close();

		using (StreamWriter sw2 = new StreamWriter(filePath) { AutoFlush = true }) //StreamWriter automatisch schließen am Ende des Blocks -> }
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
		}

		using StreamWriter sw3 = new StreamWriter(filePath) { AutoFlush = true }; //StreamWriter automatisch schließen am Ende der Methode
		sw3.WriteLine("Test1");
		sw3.WriteLine("Test2");
		sw3.WriteLine("Test3");
	}

	public static void StreamReaderTest()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Desktop: C:\Users\lk3\Desktop

		string folderPath = Path.Combine(desktop, "M015"); //C:\Users\lk3\Desktop\M015

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath); //Ordner erstellen

		string filePath = Path.Combine(folderPath, "Test.txt"); //C:\Users\lk3\Desktop\M015\Test.txt

		using StreamReader sr = new StreamReader(filePath);
		List<string> lines = sr.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList(); //ließt das gesamte File ein (nur bei kürzeren Files zu empfehlen)

		sr.BaseStream.Position = 0; //Stream auf Position 0 zurücksetzen nach einlesen

		//Bei großen Files
		List<string> whileLines = new();
		string currentLine;
		while (!sr.EndOfStream)
		{
			currentLine = sr.ReadLine();
			whileLines.Add(currentLine);
		}
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}

	public Fahrzeug() { }
}

public enum FahrzeugMarke
{
	BMW,
	Audi,
	VW
}