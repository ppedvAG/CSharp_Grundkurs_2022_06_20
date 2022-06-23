using Fahrzeugpark;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace M014_Loesung;

public partial class MainWindow : Window
{
	public List<Fahrzeug> Fahrzeuge = new();

	public MainWindow() => InitializeComponent();

	private void NeuesFahrzeugClicked(object sender, RoutedEventArgs e)
	{
		Fahrzeuge.Add(Fahrzeug.GeneriereFahrzeug());
		UpdateUI();
	}

	private void FahrzeugLoeschenClicked(object sender, RoutedEventArgs e)
	{
		if (FahrzeugLB.SelectedIndex != -1)
		{
			Fahrzeuge.RemoveAt(FahrzeugLB.SelectedIndex);
			UpdateUI();
		}
	}

	private void UpdateUI()
	{
		FahrzeugLB.Items.Clear();

		foreach (Fahrzeug f in Fahrzeuge)
			FahrzeugLB.Items.Add(f);
	}

	private void FahrzeugSelected(object sender, SelectionChangedEventArgs e)
	{
		ListBox lb = sender as ListBox;
		InfoTB.Text = Fahrzeuge[lb.SelectedIndex].Info();
	}
}
