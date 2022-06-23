using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace M014;

public partial class MainWindow : Window
{
	private int Counter { get; set; }

	public MainWindow()
	{
		InitializeComponent();
		CB.ItemsSource = new int[] { 1, 2, 3, 4 }; //Inhalt setzen über ItemsSource
		LB.ItemsSource = new string[] { "Item1", "Item2", "Item3" }; //Inhalt setzen über ItemsSource
	}

	private void EinButtonClicked(object sender, RoutedEventArgs e) //sender: Button selbst
	{
		//TB.Text = (++Counter).ToString();
		//e.Handled = true;
		Test t = new Test();
		bool? b = t.ShowDialog();
	}

	private void Eingabe(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
			Close();
	}

	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		ComboBox box = sender as ComboBox;
		TB.Text = box.SelectedValue.ToString();
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		MessageBoxResult res = MessageBox.Show("Die Checkbox wurde markiert", "Checkbox markiert", MessageBoxButton.OK, MessageBoxImage.Information);
		if (res == MessageBoxResult.OK)
		{
			Close();
		}
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{

	}
}
