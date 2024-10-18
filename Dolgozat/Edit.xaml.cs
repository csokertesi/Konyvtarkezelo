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
using System.Windows.Shapes;

namespace Dolgozat
{
	/// <summary>
	/// Interaction logic for Edit.xaml
	/// </summary>
	public partial class Edit : Window
	{
		List<string> mufajok = new List<string>() { "Regény", "Tudományos", "Fikció", "Sci-Fi", "Romantika", "Életrajz", "Kézikönyv", "Minden" };
		public Konyv selection;
		public Edit()
		{
			InitializeComponent();
			if (selection == null) return;
			konyvujcim.Text = selection.Cim;
			konyvujmufaj.SelectedIndex = mufajok.IndexOf(selection.Mufaj);
		}

		private void editbtn_Click(object sender, RoutedEventArgs e)
		{
			selection.Cim = konyvujcim.Text;
			selection.Mufaj = mufajok.ElementAt(konyvujmufaj.SelectedIndex);
			this.Close();
		}
	}
}
