using POP_SF_9_GUI.Model;
using POP_SF_9_GUI.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ICollectionView view;
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
                    //DataGridNamestaj();
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.namestaj);
                    view.Filter = namestajFileter;
                    dgPrikaz.ItemsSource =view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Prikaz.TipNamestaja:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.TN);
                    view.Filter = tipnamestajFileter;
                
                    dgPrikaz.ItemsSource =  view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Prikaz.Korisnik:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.korisnik);
                    view.Filter = korisnikFileter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Prikaz.ProdajaNamestaja:
                    dgPrikaz.ItemsSource = Projekat.Instance.pn;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true; 
                    btObrisi.Visibility = System.Windows.Visibility.Hidden;
                    break;



            }

        }

        private bool namestajFileter(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        }
        private bool tipnamestajFileter(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }
        private bool korisnikFileter(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
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
                        view.Refresh();
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
                        view.Refresh();
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
                        view.Refresh();
                        break;
                    }

                }
            }
            GenericSerializer.Serialize("korisnik.xml", Projekat.Instance.korisnik);
        }
        

        private void dgPrikaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "ak" || (string)e.Column.Header == "TipN")
                    {
                        e.Cancel = true;
                    }
                    
                    break;
                case Prikaz.TipNamestaja:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" )
                    {
                        e.Cancel = true;
                    }
                    break;
                case Prikaz.Korisnik:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
                    {
                        e.Cancel = true;
                    }
                    break;
            }
            
        }
    }
}
