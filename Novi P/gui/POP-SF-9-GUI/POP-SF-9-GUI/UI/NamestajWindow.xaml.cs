using POP_SF_9_GUI.Model;
using POP_SF_9_GUI.UI;
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
using static POP_SF_9_GUI.UI.NamstajWindowDodavanjeIzmena;

namespace POP_SF_9_GUI.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {   //Stavi umesto listbox datagrid
        public NamestajWindow()
        {
            InitializeComponent();

            dgNamestaj.ItemsSource = Projekat.Instance.namestaj;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            
        }
        

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamstajWindowDodavanjeIzmena(noviNamestaj, Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
            
        }
        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            var selektovaniNamestaj = (Namestaj)dgNamestaj.SelectedItem;
            var namestajProzor = new NamstajWindowDodavanjeIzmena(selektovaniNamestaj, Operacija.IZMENA);
            namestajProzor.ShowDialog();
            
        }
        private void ObrisiNamestaj(object sender, RoutedEventArgs e)
        {
            var staraListaN = Projekat.Instance.namestaj;
            var nam =(Namestaj)dgNamestaj.SelectedItem;
            
            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani namestaj: {nam.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in staraListaN)
                {
                    if (n.Id == nam.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                   
                }
            }
            GenericSerializer.Serialize("namestaj.xml", Projekat.Instance.namestaj);
        }
    }
}
