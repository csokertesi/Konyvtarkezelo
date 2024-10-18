using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dolgozat
{
	public class Konyv
	{
		public string Cim;
		public string Mufaj;
		public Konyv(string cim, string mufaj)
		{ 
			this.Cim = cim;
			this.Mufaj = mufaj;
		}
	}

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<Konyv> konyveklista = new List<Konyv>();
		public List<string> szoveglista = new List<string>();
		public List<string> mufajok = new List<string>() { "Regény", "Tudományos", "Fikció", "Sci-Fi", "Romantika", "Életrajz", "Kézikönyv", "Minden" };
		public string filter = "Minden";

		public void UpdateList()
		{
			szoveglista = new List<string>();
			foreach (Konyv k in konyveklista)
			{
				if (filter == "Minden" || k.Mufaj == filter)
				{
					szoveglista.Add($"\"{k.Cim}\" ({k.Mufaj})");
				}
			}
			konyvek.ItemsSource = szoveglista;
		}

		public MainWindow()
		{
			InitializeComponent();
			szuro.SelectedIndex = 7;
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (editmode.IsChecked == false)
			{
				if (konyvek.SelectedItem == null) return;
				string select = konyvek.SelectedItem.ToString();
				MessageBoxResult res = MessageBox.Show($"{select}", "Biztosan törli?", MessageBoxButton.OKCancel);
				if (res.ToString() == "Cancel") return;
				foreach (Konyv k in konyveklista)
				{
					if ($"\"{k.Cim}\" ({k.Mufaj})" == select)
					{
						konyveklista.Remove(k);
						UpdateList();
						return;
					}
				}
			} else
			{
				if (konyvek.SelectedItem == null) return; 
				Edit win = new Edit();
				Konyv konyv = new Konyv("","");
				foreach (Konyv k in konyveklista)
				{
					if (konyvek.SelectedItem == null) continue;
					if ($"\"{k.Cim}\" ({k.Mufaj})" == konyvek.SelectedItem.ToString())
					{
						konyv = k;
						break;
					}
				}
				win.selection = konyv;
				win.ShowDialog();
				UpdateList();
			}
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			if (konyvmufaj.SelectedIndex == -1)
			{
				MessageBox.Show("Műfaj kiválasztása kötelező!");
				return;
			}
			if (konyvcim.Text == "") 
			{
				MessageBox.Show("Cím megadása kötelező!");
				return;
			}
			konyveklista.Add(new Konyv(konyvcim.Text, mufajok.ElementAt(konyvmufaj.SelectedIndex)));
			UpdateList();
		}

		private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			filter = mufajok.ElementAt(szuro.SelectedIndex);
			UpdateList();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Mindent mutat
			string complete = "";
			foreach (string title in szoveglista)
			{
				complete += title + "\n";
			}
			MessageBox.Show(complete);
		}
	}
}
