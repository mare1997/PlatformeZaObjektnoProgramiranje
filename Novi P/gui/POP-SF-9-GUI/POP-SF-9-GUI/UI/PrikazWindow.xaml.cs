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
    public partial class PrikazWindow : Window
    {
        public enum Prikaz
        {
            Namestaj,
            TipNamestaja,
            Korisnik,
            ProdajaNamestaja,


        };
        Prikaz prikaz;
        public SizeToContent SizeToContent { get; set; }
        public PrikazWindow(Prikaz prikaz)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.prikaz =  prikaz;
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    DataGridNamestaj();
                    break;
                case Prikaz.TipNamestaja:
                    DataGridTipNamestaja();
                    break;
                case Prikaz.Korisnik:
                    DataGridKorisnik();
                    break;
                case Prikaz.ProdajaNamestaja:
                    dgPrikaz.ItemsSource = Projekat.Instance.pn;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true; break;
                    btObrisi.Visibility = Visibility.Hidden;

                

            }

        }


        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Dodaj(object sender, RoutedEventArgs e)
        {
            
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    DodajNamestaj();
                    break;
                case Prikaz.TipNamestaja:
                    DodajTipNamestaja();
                    break;
                case Prikaz.Korisnik:
                    DodajKorisnika();
                    break;
                case Prikaz.ProdajaNamestaja: break;


            }
            
            
        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    IzmeniNamestaj();
                    break;
                case Prikaz.TipNamestaja:
                    IzmeniTipNamestaja();
                    break;
                case Prikaz.Korisnik:
                    IzmeniKorisnik();
                    break;
                case Prikaz.ProdajaNamestaja: break;


            }

        }
        private void Obrisi(object sender, RoutedEventArgs e)
        {
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    ObrisiNamestaj();
                    break;
                case Prikaz.TipNamestaja:
                    ObrisiTipNamestaj();
                    break;
                case Prikaz.Korisnik:
                    ObrisiKorisnika();
                    break;
                


            }
        }
        private void DodajNamestaj()
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamstajWindowDodavanjeIzmena(noviNamestaj, Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
        }
        private void DodajTipNamestaja()
        {
            var tn = new TipNamestaja()
            {
                Naziv = ""
            };
            var namestajProzor = new TipNamestajaWindow(TipNamestajaWindow.Operacija.DODAVANJE, tn);
            namestajProzor.ShowDialog();
        }
        private void DodajKorisnika()
        {
            var k = new Korisnik();
            var korisnikProzor = new KorisnikWindowEdit(KorisnikWindowEdit.Operacija.DODAVANJE, k);
            korisnikProzor.ShowDialog();
        }
        private void IzmeniNamestaj()
        {
            var selektovaniNamestaj = (Namestaj)dgPrikaz.SelectedItem;
            var namestajProzor = new NamstajWindowDodavanjeIzmena(selektovaniNamestaj, Operacija.IZMENA);
            namestajProzor.ShowDialog();
        }
        private void IzmeniTipNamestaja()
        {
            var selektovaniTNamestaja = (TipNamestaja)dgPrikaz.SelectedItem;
            var namestajProzor = new TipNamestajaWindow(TipNamestajaWindow.Operacija.IZMENA, selektovaniTNamestaja);
            namestajProzor.ShowDialog();
        }
        private void IzmeniKorisnik()
        {
            var selektovaniKorisnki = (Korisnik)dgPrikaz.SelectedItem;
            var prozor = new KorisnikWindowEdit(KorisnikWindowEdit.Operacija.IZMENA, selektovaniKorisnki);
            prozor.ShowDialog();
        }
        private void ObrisiNamestaj()
        {
            var staraListaN = Projekat.Instance.namestaj;
            var nam = (Namestaj)dgPrikaz.SelectedItem;

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
        private void ObrisiTipNamestaj()
        {
            var staraListaN = Projekat.Instance.TN;
            var tn = (TipNamestaja)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani tip namestaj: {tn.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in staraListaN)
                {
                    if (n.Id == tn.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }

                }
            }
            GenericSerializer.Serialize("tipnamestaja.xml", Projekat.Instance.TN);
        }
        private void ObrisiKorisnika()
        {
            var staraListaN = Projekat.Instance.korisnik;
            var korisnik = (Korisnik)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabranog korisnika: {korisnik.Ime} {korisnik.Prezime}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in staraListaN)
                {
                    if (n.Id == korisnik.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }

                }
            }
            GenericSerializer.Serialize("korisnik.xml", Projekat.Instance.korisnik);
        }
        private void DataGridNamestaj()
        {
            DataGrid dgn = new DataGrid();
            DataGridTextColumn d1 = new DataGridTextColumn();
            d1.Header = "Naziv";
            d1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d1.Binding = new Binding("Naziv");
            DataGridTextColumn d2 = new DataGridTextColumn();
            d2.Header = "Cena";
            d2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d2.Binding = new Binding("Cena");
            DataGridTextColumn d3 = new DataGridTextColumn();
            d3.Header = "Kolicina";
            d3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d3.Binding = new Binding("Kolicina");
            DataGridTextColumn d4 = new DataGridTextColumn();
            d4.Header = "Tip Namestaja";
            d4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d4.Binding = new Binding("TipNamestaja");
            DataGridTextColumn d5 = new DataGridTextColumn();
            d5.Header = "Akcija";
            d5.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d5.Binding = new Binding("Akcija");
            dgPrikaz.Columns.Add(d1);
            dgPrikaz.Columns.Add(d2);
            dgPrikaz.Columns.Add(d3);
            dgPrikaz.Columns.Add(d4);
            dgPrikaz.Columns.Add(d5);
            dgPrikaz.ItemsSource = Projekat.Instance.namestaj;
        }
        private void DataGridTipNamestaja()
        {
            DataGrid dgn = new DataGrid();
            DataGridTextColumn d1 = new DataGridTextColumn();
            d1.Header = "Naziv";
            d1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d1.Binding = new Binding("Naziv");
            dgPrikaz.Columns.Add(d1);
            dgPrikaz.ItemsSource = Projekat.Instance.TN;
           
        }
        private void DataGridKorisnik()
        {
            DataGrid dgn = new DataGrid();
            DataGridTextColumn d1 = new DataGridTextColumn();
            d1.Header = "Ime";
            d1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d1.Binding = new Binding("Ime");
            DataGridTextColumn d2 = new DataGridTextColumn();
            d2.Header = "Prezime";
            d2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d2.Binding = new Binding("Prezime");
            DataGridTextColumn d3 = new DataGridTextColumn();
            d3.Header = "Korisnicko Ime";
            d3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d3.Binding = new Binding("KorisnickoIme");
            DataGridTextColumn d4 = new DataGridTextColumn();
            d4.Header = "Tip korisnika";
            d4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            d4.Binding = new Binding("TipKorisnika");
            dgPrikaz.Columns.Add(d1);
            dgPrikaz.Columns.Add(d2);
            dgPrikaz.Columns.Add(d3);
            dgPrikaz.Columns.Add(d4);
            //Za tip korisnika uvek vraca Admin zasto????

            dgPrikaz.ItemsSource = Projekat.Instance.korisnik;
        }
        private void DataGridProdaja()
        {

        }
    }
}
