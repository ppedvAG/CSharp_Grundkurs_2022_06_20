using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //@Trainer: Erweiterungen der PKW- und Fahrzeug-Klassen ist nicht Teil des Labs,
    //          sondern kann als erweitertes Beispiel oder Zusatzaufgabe verwendet werden

    interface IBeladbar { }

    public abstract class Fahrzeug
    {
        #region Lab 06-10
        //Lab11 ist Erweiterung von Lab10
        #endregion

        public static Fahrzeug GeneriereFahrzeug(string nameSuffix = "")
        {
            [...]
                case 1:
                    return PKW.ErzeugeZuf�lligenPKW(nameSuffix);
            [...]
        }
    }

    public class Schiff : Fahrzeug, IBeladbar { }

    public class PKW : Fahrzeug
    {

        #region Lab 06-10
        //Lab11 ist Erweiterung von Lab10
        #endregion

        //Statische Methode zur Erstellung eines zuf�lligen PKWs 
        public static PKW ErzeugeZuf�lligenPKW(string plusName)
        {
            string name;
            switch (generator.Next(1, 5))
            {
                case 1:
                    name = "BMW" + plusName;
                    break;
                case 2:
                    name = "Mercedes" + plusName;
                    break;
                case 3:
                    name = "Audi" + plusName;
                    break;
                default:
                    name = "VW" + plusName;
                    break;
            }
            return new PKW(name, generator.Next(15, 31) * 10, generator.Next(15, 30) * 1000, generator.Next(1, 3) == 1 ? 3 : 5);
        }
    }

    public class Flugzeug : Fahrzeug { }

    class Program
    {
        static void Main(string[] args)
        {
            //�ndern des durch Console verwendeten Zeichensatzes auf Unicode (damit das �-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Lab 06-10
            //Lab11 ist Erweiterung von Lab10
            #endregion

            #region Lab 11: generische Listen
            //Deklaration der ben�tigten Variablen und und Initialisierung mit Instanzen der ben�tigten Objekte
            Queue<Fahrzeug> fzQueue = new Queue<Fahrzeug>();
            Stack<Fahrzeug> fzStack = new Stack<Fahrzeug>();
            Dictionary<Fahrzeug, Fahrzeug> fzDict = new Dictionary<Fahrzeug, Fahrzeug>();
            Random random = new Random();
            //Deklaration und Initialisierung einer Variablen zur Bestimmung der Anzahl der Durchl�ufe 
            int anzahlFahrzeuge = 10;

            //Schleife zur zuf�lligen Bef�llung von Queue und Stack
            for (int i = 0; i < anzahlFahrzeuge; i++)
            {
                fzQueue.Enqueue(Fahrzeug.GeneriereFahrzeug($"_Q{i}"));
                fzStack.Push(Fahrzeug.GeneriereFahrzeug($"_S{i}"));
            }

            for (int i = 0; i < anzahlFahrzeuge; i++)
            {
                Fahrzeug f1 = fzQueue.Dequeue();
                Fahrzeug f2 = fzStack.Pop();
                //Pr�fung, ob das Interface vorhanden ist (mittels Peek(), da die Objekte noch ben�tigt werden)...
                if (f1 is IBeladbar)
                {
                    //...wenn ja, dann Cast in das Interface und Ausf�hrung der Belade()-Methode (mittels Peek())...
                    f1.Belade(f2);
                    //...sowie Hinzuf�gen zum Dictionary (mittels Pop()/Dequeue(), um beim n�chsten Durchlauf andere Objekte an den Spitzen zu haben)
                    fzDict.Add(f1, f2);
                }
            }

            //Programmpause
            Console.ReadKey();
            Console.WriteLine("\n----------LADELISTE----------");

            //Schleife zur Ausgabe des Dictionaries
            foreach (var item in fzDict)
            {
                Console.WriteLine($"'{item.Key.Name}' hat '{item.Value.Name}' geladen.");
            }

            #endregion
        }

        public static void BeladeFahrzeuge(Fahrzeug fz1, Fahrzeug fz2) { }
    }
}