﻿namespace M011_Linq;

public class M_011_Linq_LabLoesung
{
	//1. Gib alle Autos mit 6 Sitzplätzen aus.
	//2. Gib die Summe aller Sitzplätze aus.
	//3. Sortiere alle Fahrzeuge nach Automarke, danach nach Höchstgeschwindigkeit.
	//4. Gib alle Autos mit mindestens einem besetzten Sitzplatz aus.
	//5. Gib alle Autos aus die schneller fahren können als der Durchschnitt aller Autos.
	//6. Gib alle Autos aus bei denen mehr als die Hälfte aller Sitzplätze belegt sind.
	//7. Gib pro Automarke das schnellste Auto aus.
	//8. Gib die Höchstgeschwindigkeit pro Anzahl Sitzplätze aus und sortiere nach Sitzanzahl (schnellster 4-, 5- und 6-Sitzer).
	//9. Mische die Liste. Erstelle danach eine Erweiterungsmethode dafür. 
	static void Main(string[] args)
	{
		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//1
		fahrzeuge.Where(e => e.Sitze.Count == 6);

		//2
		fahrzeuge.Sum(e => e.Sitze.Count);

		//3
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxGeschwindigkeit);

		//4
		fahrzeuge.Where(e => e.Sitze.Any(x => x.IstBesetzt)); //.Count(x => x.IstBesetzt) > 0

		//5
		fahrzeuge.Where(e => e.MaxGeschwindigkeit > fahrzeuge.Average(x => x.MaxGeschwindigkeit));

		//6
		fahrzeuge.Where(e => e.Sitze.Count(x => x.IstBesetzt) > e.Sitze.Count / 2);

		//7
		fahrzeuge.GroupBy(e => e.Marke).ToDictionary(e => e.Key, e => e.MaxBy(x => x.MaxGeschwindigkeit));

		//8
		fahrzeuge.GroupBy(e => e.Sitze.Count).ToDictionary(e => e.Key, e => e.MaxBy(x => x.MaxGeschwindigkeit)).OrderBy(e => e.Key);

		//9
		fahrzeuge.PrintList();
	}
}
public class Fahrzeug
{
	public int ID;
	public int MaxGeschwindigkeit;
	public FahrzeugMarke Marke;
	public List<Sitzplatz> Sitze;

	public Fahrzeug(int id, int v, FahrzeugMarke fm)
	{
		ID = id;
		MaxGeschwindigkeit = v;
		Marke = fm;
		Sitze = new();

		//Anzahl Sitzplätze anhand der Geschwindigkeit (6: max 150km/h, 5 bis 250km/h, 4 ab 250km/h)
		int sitze = v <= 150 ? 6 : v <= 250 ? 5 : 4;

		//Sitzplätze erstellen
		for (int i = 0; i < sitze; i++)
			Sitze.Add(new Sitzplatz());

		//Sitzplätze semi-zufällig belegen damit die Übung zwischen Teilnehmern gleiche Ergebnisse liefert
		//Geschwindigkeit modulo Anzahl Sitzplätze besetzen
		for (int i = 0; i < v % (sitze + 1); i++)
			Sitze[i].IstBesetzt = true;
	}
}

public record Sitzplatz(bool IstBesetzt);

public enum FahrzeugMarke
{
	Audi, BMW, VW
}