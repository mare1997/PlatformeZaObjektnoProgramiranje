using POP_SF_9_GUI.Model;
using POP_SF_9_GUI.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Akcija,
            DodatneUsluge
        };
        private ICollectionView view;
        Prikaz prikaz;
        
        public PrikazWindow(Prikaz prikaz)
        {
            InitializeComponent();
            
            this.prikaz =  prikaz;
            
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.namestaj);
                    view.Filter = namestajFilter;
                    dgPrikaz.ItemsSource =view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    cbSP.Items.Add(Namestaj.Prikaz.Naziv);
                    cbSP.Items.Add(Namestaj.Prikaz.Cena);
                    cbSP.Items.Add(Namestaj.Prikaz.Kolicina);
                    cbSP.Items.Add(Namestaj.Prikaz.TipNamestaja);
                    cbSP.Items.Add(Namestaj.Prikaz.Akcija);
                    cbSP.SelectedIndex = 0;
                    cbR.Items.Add(Namestaj.NacinSortiranja.asc);
                    cbR.Items.Add(Namestaj.NacinSortiranja.desc);
                    cbR.SelectedIndex = 0;
                    cbP.Items.Add(Namestaj.Prikaz.Naziv);
                    cbP.Items.Add(Namestaj.Prikaz.Cena);
                    cbP.Items.Add(Namestaj.Prikaz.Kolicina);
                    cbP.Items.Add(Namestaj.Prikaz.TipNamestaja);
                    cbP.Items.Add(Namestaj.Prikaz.Akcija);
                    cbP.SelectedIndex = 0;
                    btRacun.Visibility = System.Windows.Visibility.Hidden;
                    break;
                case Prikaz.TipNamestaja:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.TN);
                    view.Filter = tipnamestajFilter;
                    btRacun.Visibility = System.Windows.Visibility.Hidden;
                    dgPrikaz.ItemsSource =  view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    cbSP.Items.Add(TipNamestaja.Prikaz.Naziv);
                    cbSP.SelectedIndex = 0;
                    cbR.Items.Add(TipNamestaja.NacinSortiranja.asc);
                    cbR.Items.Add(TipNamestaja.NacinSortiranja.desc);
                    cbR.SelectedIndex = 0;
                    cbP.Items.Add(TipNamestaja.Prikaz.Naziv);
                    cbP.SelectedIndex = 0;
                    break;
                case Prikaz.Korisnik:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.korisnik);
                    view.Filter = korisnikFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    cbSP.Items.Add(Korisnik.Prikaz.Ime);
                    cbSP.Items.Add(Korisnik.Prikaz.Prezime);
                    cbSP.Items.Add(Korisnik.Prikaz.KorisnickoIme);
                    cbSP.Items.Add(Korisnik.Prikaz.Lozinka);
                    cbSP.Items.Add(Korisnik.Prikaz.TipKorisnika);
                    cbSP.SelectedIndex = 0;
                    cbR.Items.Add(Korisnik.NacinSortiranja.asc);
                    cbR.Items.Add(Korisnik.NacinSortiranja.desc);
                    cbR.SelectedIndex = 0;
                    cbP.Items.Add(Korisnik.Prikaz.Ime);
                    cbP.Items.Add(Korisnik.Prikaz.Prezime);
                    cbP.Items.Add(Korisnik.Prikaz.KorisnickoIme);
                    cbP.Items.Add(Korisnik.Prikaz.Lozinka);
                    btRacun.Visibility = System.Windows.Visibility.Hidden;
                    cbP.SelectedIndex = 0;
                    break;
              case Prikaz.ProdajaNamestaja:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.pn);
                    view.Filter = RacunFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    btObrisi.Visibility = System.Windows.Visibility.Hidden;
                    cbSP.Items.Add(Racun.Prikaz.DatumProdaje);
                    cbSP.Items.Add(Racun.Prikaz.Kupac);
                    cbSP.Items.Add(Racun.Prikaz.Cena);
                    cbSP.SelectedIndex = 0;
                    cbR.Items.Add(Racun.NacinSortiranja.asc);
                    cbR.Items.Add(Racun.NacinSortiranja.desc);
                    cbR.SelectedIndex = 0;
                    cbP.Items.Add(Racun.Prikaz.DatumProdaje);
                    cbP.Items.Add(Racun.Prikaz.Kupac);
                    cbP.Items.Add(Racun.Prikaz.Cena);
                    cbP.SelectedIndex = 0;
                    break;
                case Prikaz.Akcija:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.akcija);
                    view.Filter = akcijaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    btObrisi.Visibility = System.Windows.Visibility.Hidden;
                    btDodaj.Visibility = System.Windows.Visibility.Hidden;
                    btIzmeni.Visibility = System.Windows.Visibility.Hidden;
                    cbSP.Items.Add(AkcijskaProdaja.Prikaz.DatumPocetka);
                    cbSP.Items.Add(AkcijskaProdaja.Prikaz.DatumKraja);
                    cbSP.Items.Add(AkcijskaProdaja.Prikaz.Popust);
                    cbSP.SelectedIndex = 0;
                    cbR.Items.Add(AkcijskaProdaja.NacinSortiranja.asc);
                    cbR.Items.Add(AkcijskaProdaja.NacinSortiranja.desc);
                    cbR.SelectedIndex = 0;
                    cbP.Items.Add(AkcijskaProdaja.Prikaz.DatumPocetka);
                    cbP.Items.Add(AkcijskaProdaja.Prikaz.DatumKraja);
                    cbP.Items.Add(AkcijskaProdaja.Prikaz.Popust);
                    cbP.SelectedIndex = 0;
                    btRacun.Visibility = System.Windows.Visibility.Hidden;
                    break;
                case Prikaz.DodatneUsluge:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.DU);
                    view.Filter = dodatnaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    cbSP.Items.Add(DodatnaUsluga.Prikaz.Naziv);
                    cbSP.Items.Add(DodatnaUsluga.Prikaz.Cena);
                    cbSP.SelectedIndex = 0;
                    cbR.Items.Add(AkcijskaProdaja.NacinSortiranja.asc);
                    cbR.Items.Add(AkcijskaProdaja.NacinSortiranja.desc);
                    cbR.SelectedIndex = 0;
                    cbP.Items.Add(DodatnaUsluga.Prikaz.Naziv);
                    cbP.Items.Add(DodatnaUsluga.Prikaz.Cena);
                    cbP.SelectedIndex = 0;
                    btRacun.Visibility = System.Windows.Visibility.Hidden;
                    break;
            }


        }

        private bool namestajFilter(object obj)
        {   if (((Namestaj)obj).Obrisan == false && ((Namestaj)obj).TipNamestaja.Obrisan == false)
            {
                return true;
            }
            return false;
        }
        private bool tipnamestajFilter(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }
        private bool korisnikFilter(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
        }
        private bool akcijaFilter(object obj)
        {   if (((AkcijskaProdaja)obj).Obrisan == false)
                return true;

            return false;
        }
        private bool dodatnaFilter(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }
        private bool RacunFilter(object obj)
        {
            return true;
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
                case Prikaz.ProdajaNamestaja:
                    DodajRacun();
                    break;
                case Prikaz.DodatneUsluge:
                    DodajDodatnuUslugu();
                    break;

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
                case Prikaz.ProdajaNamestaja:
                    IzmeniRacun();
                    break;
                case Prikaz.DodatneUsluge:
                    IzmeniDodatnaUsluga();
                    break;


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
                case Prikaz.DodatneUsluge:
                    ObrisiDodatnaUsluga();
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
            view.Refresh();
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
        private void DodajDodatnuUslugu()
        {
            var du = new DodatnaUsluga();
            var dProzor = new DodatnaUslugaWindowEdit(DodatnaUslugaWindowEdit.Operacija.DODAVANJE, du);
            dProzor.ShowDialog();
        }
        private void DodajRacun()
        {
            var racun = new Racun();
            var dProzor = new RacunEdit(RacunEdit.Operacija.DODAVANJE, racun);
            dProzor.Show();
        }
        private void IzmeniNamestaj()
        {
            var selektovaniNamestaj = (Namestaj)dgPrikaz.SelectedItem;
            var namestajProzor = new NamstajWindowDodavanjeIzmena((Namestaj)selektovaniNamestaj.Clone(), Operacija.IZMENA);
            namestajProzor.ShowDialog();
            view.Refresh();
        }
        private void IzmeniTipNamestaja()
        {
            var selektovaniTNamestaja = (TipNamestaja)dgPrikaz.SelectedItem;
            var namestajProzor = new TipNamestajaWindow(TipNamestajaWindow.Operacija.IZMENA, (TipNamestaja)selektovaniTNamestaja.Clone());
            namestajProzor.ShowDialog();
        }
        private void IzmeniKorisnik()
        {
            var selektovaniKorisnki = (Korisnik)dgPrikaz.SelectedItem;
            var prozor = new KorisnikWindowEdit(KorisnikWindowEdit.Operacija.IZMENA, (Korisnik)selektovaniKorisnki.Clone());
            prozor.ShowDialog();
        }
        private void IzmeniDodatnaUsluga()
        {
            var selektovaniDU = (DodatnaUsluga)dgPrikaz.SelectedItem;
            var prozor = new DodatnaUslugaWindowEdit(DodatnaUslugaWindowEdit.Operacija.IZMENA, (DodatnaUsluga)selektovaniDU.Clone());
            prozor.ShowDialog();
        }
        private void IzmeniRacun()
        {
            var racun = (Racun)dgPrikaz.SelectedItem;
            var dProzor = new RacunEdit(RacunEdit.Operacija.IZMENA, (Racun)racun.Clone());
            dProzor.ShowDialog();
        }
        private void ObrisiNamestaj()
        {
           
            var nam = (Namestaj)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani namestaj: {nam.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Namestaj.Delete(nam);
                view.Refresh();
           }
           
        }
        private void ObrisiTipNamestaj()
        {
            
            var tn = (TipNamestaja)dgPrikaz.SelectedItem;
            
            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani tip namestaj: {tn.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                TipNamestaja.Delete(tn);
                view.Refresh();
            }
            
        }
        private void ObrisiKorisnika()
        {
            
            var korisnik = (Korisnik)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabranog korisnika: {korisnik.Ime} {korisnik.Prezime}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Korisnik.Delete(korisnik);
                view.Refresh();
            }
           
        }
        private void ObrisiDodatnaUsluga()
        {
            
            var du = (DodatnaUsluga)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete dodatnu uslugu: {du.Naziv} ?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DodatnaUsluga.Delete(du);
                view.Refresh();
            }
           
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
                case Prikaz.Akcija:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
                    {
                        e.Cancel = true;
                    }
                    break;
                case Prikaz.DodatneUsluge:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
                    {
                        e.Cancel = true;
                    }
                    break;
                case Prikaz.ProdajaNamestaja:
                    if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "DodatnaUsluga" || (string)e.Column.Header == "Namestaj") 
                    {
                        e.Cancel = true;
                    }
                    break;
            }
            
        }
        

        private void Sortiraj_Click(object sender, RoutedEventArgs e)
        {
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    SortirajNamestaj();
                    break;
                case Prikaz.TipNamestaja:
                    SortirajTipNamestaja();
                    break;
                case Prikaz.Korisnik:
                    SortirajKorisnika();
                    break;
                case Prikaz.ProdajaNamestaja:
                    SortirajRacun();
                    break;
                case Prikaz.Akcija:
                    SortirajAkcije();
                    break;
                case Prikaz.DodatneUsluge:
                    SortirajDU();
                    break;
            }

        }
        private void Pretrazi_Click(object sender, RoutedEventArgs e)
        {
            switch (prikaz)
            {
                case Prikaz.Namestaj:
                    PretraziNamestaj();
                    break;
                case Prikaz.TipNamestaja:
                    PretraziTipNamestaja();
                    break;
                case Prikaz.Korisnik:
                    PretraziKorisnika();
                    break;
                case Prikaz.ProdajaNamestaja:
                    PretraziRacun();
                    break;
                case Prikaz.Akcija:
                    PretraziAkcije();
                    break;
                case Prikaz.DodatneUsluge:
                    PretraziDU();
                    break;
            }
        }
        public void SortirajNamestaj()
        {
            var sp = cbSP.Text;
            var ns = cbR.Text;
            var namestaj = new ObservableCollection<Namestaj>();
            switch (sp)
            {
                case "Naziv":
                    if (ns == Namestaj.NacinSortiranja.asc.ToString())
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Naziv, Namestaj.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    }
                    else
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Naziv, Namestaj.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }

                    break;
                case "Cena":
                    if (ns == Namestaj.NacinSortiranja.asc.ToString())
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Cena, Namestaj.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    }
                    else
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Cena, Namestaj.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }

                    break;
                case "Kolicina":
                    if (ns == Namestaj.NacinSortiranja.asc.ToString())
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Kolicina, Namestaj.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    }
                    else
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Kolicina, Namestaj.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }

                    break;
                case "TipNamestaja":
                    if (ns == Namestaj.NacinSortiranja.asc.ToString())
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.TipNamestaja, Namestaj.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    }
                    else
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.TipNamestaja, Namestaj.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }

                    break;
                case "Akcija":
                    if (ns == Namestaj.NacinSortiranja.asc.ToString())
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Akcija, Namestaj.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    }
                    else
                    {
                        namestaj = Namestaj.Sort(Namestaj.Prikaz.Akcija, Namestaj.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }

                    break;
            }
        }
        public void SortirajTipNamestaja()
        {
            var sp = cbSP.Text;
            var ns = cbR.Text;
            var topnamestaja = new ObservableCollection<TipNamestaja>();
            switch (sp)
            {
                case "Naziv":
                    if (ns == Namestaj.NacinSortiranja.asc.ToString())
                    {
                        topnamestaja = TipNamestaja.Sort(TipNamestaja.Prikaz.Naziv, TipNamestaja.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(topnamestaja);
                        view.Filter = tipnamestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    }
                    else
                    {
                        topnamestaja = TipNamestaja.Sort(TipNamestaja.Prikaz.Naziv, TipNamestaja.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(topnamestaja);
                        view.Filter = tipnamestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }

                    break;
            }

            }
        public void SortirajKorisnika()
        {
            var sp = cbSP.Text;
            var ns = cbR.Text;
            var korisnik = new ObservableCollection<Korisnik>();
            switch (sp)
            {
                case "Ime":
                    if (ns == Korisnik.NacinSortiranja.asc.ToString())
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.Ime, Korisnik.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.Ime, Korisnik.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "Prezime":
                    if (ns == Korisnik.NacinSortiranja.asc.ToString())
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.Prezime, Korisnik.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.Prezime, Korisnik.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "KorisnickoIme":
                    if (ns == Korisnik.NacinSortiranja.asc.ToString())
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.KorisnickoIme, Korisnik.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.KorisnickoIme, Korisnik.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "Lozinka":
                    if (ns == Korisnik.NacinSortiranja.asc.ToString())
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.Lozinka, Korisnik.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.Lozinka, Korisnik.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "TipKorisnika":
                    if (ns == Korisnik.NacinSortiranja.asc.ToString())
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.TipKorisnika, Korisnik.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        korisnik = Korisnik.Sort(Korisnik.Prikaz.TipKorisnika, Korisnik.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(korisnik);
                        view.Filter = korisnikFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;

            }
        }
        public void SortirajDU()
        {
            var sp = cbSP.Text;
            var ns = cbR.Text;
            var du = new ObservableCollection<DodatnaUsluga>();
            switch (sp)
            {
                case "Naziv":
                    if (ns == DodatnaUsluga.NacinSortiranja.asc.ToString())
                    {
                        du = DodatnaUsluga.Sort(DodatnaUsluga.Prikaz.Naziv, DodatnaUsluga.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(du);
                        view.Filter = dodatnaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        du = DodatnaUsluga.Sort(DodatnaUsluga.Prikaz.Naziv, DodatnaUsluga.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(du);
                        view.Filter = dodatnaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "Cena":
                    if (ns == DodatnaUsluga.NacinSortiranja.asc.ToString())
                    {
                        du = DodatnaUsluga.Sort(DodatnaUsluga.Prikaz.Cena, DodatnaUsluga.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(du);
                        view.Filter = dodatnaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        du = DodatnaUsluga.Sort(DodatnaUsluga.Prikaz.Cena, DodatnaUsluga.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(du);
                        view.Filter = dodatnaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                
            }
        }
        public void SortirajAkcije()
        {
            var sp = cbSP.Text;
            var ns = cbR.Text;
            var akcija = new ObservableCollection<AkcijskaProdaja>();
            switch (sp)
            {
                case "DatumPocetka":
                    if (ns == AkcijskaProdaja.NacinSortiranja.asc.ToString())
                    {
                        akcija = AkcijskaProdaja.Sort(AkcijskaProdaja.Prikaz.DatumPocetka, AkcijskaProdaja.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(akcija);
                        view.Filter = akcijaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        akcija = AkcijskaProdaja.Sort(AkcijskaProdaja.Prikaz.DatumPocetka, AkcijskaProdaja.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(akcija);
                        view.Filter = akcijaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    
                    break;
                case "DatumKraja":
                    if (ns == AkcijskaProdaja.NacinSortiranja.asc.ToString())
                    {
                        akcija = AkcijskaProdaja.Sort(AkcijskaProdaja.Prikaz.DatumKraja, AkcijskaProdaja.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(akcija);
                        view.Filter = akcijaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        akcija = AkcijskaProdaja.Sort(AkcijskaProdaja.Prikaz.DatumKraja, AkcijskaProdaja.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(akcija);
                        view.Filter = akcijaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "Popust":
                    if (ns == AkcijskaProdaja.NacinSortiranja.asc.ToString())
                    {
                        akcija = AkcijskaProdaja.Sort(AkcijskaProdaja.Prikaz.Popust, AkcijskaProdaja.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(akcija);
                        view.Filter = akcijaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        akcija = AkcijskaProdaja.Sort(AkcijskaProdaja.Prikaz.Popust, AkcijskaProdaja.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(akcija);
                        view.Filter = akcijaFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;

            }
        }
        public void SortirajRacun()
        {
            var sp = cbSP.Text;
            var ns = cbR.Text;
            var racun = new ObservableCollection<Racun>();
            switch (sp)
            {
                case "DatumProdaje":
                    if (ns == Racun.NacinSortiranja.asc.ToString())
                    {
                        racun = Racun.Sort(Racun.Prikaz.DatumProdaje, Racun.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(racun);
                        view.Filter = RacunFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        racun = Racun.Sort(Racun.Prikaz.DatumProdaje, Racun.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(racun);
                        view.Filter = RacunFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "Cena":
                    if (ns == Racun.NacinSortiranja.asc.ToString())
                    {
                        racun = Racun.Sort(Racun.Prikaz.Cena, Racun.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(racun);
                        view.Filter = RacunFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        racun = Racun.Sort(Racun.Prikaz.Cena, Racun.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(racun);
                        view.Filter = RacunFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;
                case "Kupac":
                    if (ns == Racun.NacinSortiranja.asc.ToString())
                    {
                        racun = Racun.Sort(Racun.Prikaz.Kupac, Racun.NacinSortiranja.asc);
                        view = CollectionViewSource.GetDefaultView(racun);
                        view.Filter = RacunFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    else
                    {
                        racun = Racun.Sort(Racun.Prikaz.Kupac, Racun.NacinSortiranja.desc);
                        view = CollectionViewSource.GetDefaultView(racun);
                        view.Filter = RacunFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    }
                    break;

            }
        }
        public void PretraziNamestaj()
        {
            var sp = cbP.Text;
            var tb = tbP.Text;
            var namestaj = new ObservableCollection<Namestaj>();
            switch (sp)
            {
                case "Naziv":
                        namestaj = Namestaj.Search(Namestaj.Prikaz.Naziv,tb);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                   

                    break;
                    case "Cena":
                        namestaj = Namestaj.Search(Namestaj.Prikaz.Cena,tb);
                            view = CollectionViewSource.GetDefaultView(namestaj);
                            view.Filter = namestajFilter;
                            dgPrikaz.ItemsSource = view;
                            dgPrikaz.IsSynchronizedWithCurrentItem = true;
                            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                        break;
                    case "Kolicina":
                        namestaj = Namestaj.Search(Namestaj.Prikaz.Kolicina,tb);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                        break;
                    case "TipNamestaja":
                        namestaj = Namestaj.Search(Namestaj.Prikaz.TipNamestaja,tb);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                        break;
                    case "Akcija":
                        namestaj = Namestaj.Search(Namestaj.Prikaz.Akcija,tb);
                        view = CollectionViewSource.GetDefaultView(namestaj);
                        view.Filter = namestajFilter;
                        dgPrikaz.ItemsSource = view;
                        dgPrikaz.IsSynchronizedWithCurrentItem = true;
                        dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                        break;
            }
        }
        public void PretraziTipNamestaja()
        {
            var sp = cbP.Text;
            var tb = tbP.Text;
            var topnamestaja = new ObservableCollection<TipNamestaja>();
            switch (sp)
            {
                case "Naziv":
                    topnamestaja = TipNamestaja.Search(TipNamestaja.Prikaz.Naziv, tb);
                    view = CollectionViewSource.GetDefaultView(topnamestaja);
                    view.Filter = tipnamestajFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    break;
            }

        }
        public void PretraziKorisnika()
        {
            var sp = cbP.Text;
            var tb = tbP.Text;
            var korisnik = new ObservableCollection<Korisnik>();
            switch (sp)
            {
                case "Ime":
                    korisnik = Korisnik.Search(Korisnik.Prikaz.Ime, tb);
                    view = CollectionViewSource.GetDefaultView(korisnik);
                    view.Filter = korisnikFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case "Prezime":
                    korisnik = Korisnik.Search(Korisnik.Prikaz.Prezime, tb);
                    view = CollectionViewSource.GetDefaultView(korisnik);
                    view.Filter = korisnikFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case "KorisnickoIme":
                    korisnik = Korisnik.Search(Korisnik.Prikaz.KorisnickoIme, tb);
                    view = CollectionViewSource.GetDefaultView(korisnik);
                    view.Filter = korisnikFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case "Lozinka":
                    korisnik = Korisnik.Search(Korisnik.Prikaz.Lozinka, tb);
                    view = CollectionViewSource.GetDefaultView(korisnik);
                    view.Filter = korisnikFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
               

            }
        }
        public void PretraziDU()
        {
            var sp = cbP.Text;
            var tb = tbP.Text;
            var du = new ObservableCollection<DodatnaUsluga>();
            switch (sp)
            {
                case "Naziv":
                    du = DodatnaUsluga.Search(DodatnaUsluga.Prikaz.Naziv, tb);
                    view = CollectionViewSource.GetDefaultView(du);
                    view.Filter = dodatnaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case "Cena":
                    du = DodatnaUsluga.Search(DodatnaUsluga.Prikaz.Cena, tb);
                    view = CollectionViewSource.GetDefaultView(du);
                    view.Filter = dodatnaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;

            }
        }
        public void PretraziAkcije()
        {
            var sp = cbP.Text;
            var tb = tbP.Text;
            var akcija = new ObservableCollection<AkcijskaProdaja>();
            switch (sp)
            {
                case "DatumPocetka":
                    akcija = AkcijskaProdaja.Search(AkcijskaProdaja.Prikaz.DatumPocetka, tb);
                    view = CollectionViewSource.GetDefaultView(akcija);
                    view.Filter = akcijaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    break;
                case "DatumKraja":
                    akcija = AkcijskaProdaja.Search(AkcijskaProdaja.Prikaz.DatumKraja, tb);
                    view = CollectionViewSource.GetDefaultView(akcija);
                    view.Filter = akcijaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case "Popust":
                    akcija = AkcijskaProdaja.Search(AkcijskaProdaja.Prikaz.Popust, tb);
                    view = CollectionViewSource.GetDefaultView(akcija);
                    view.Filter = akcijaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;

            }
        }
        public void PretraziRacun()
        {
            var sp = cbP.Text;
            var tb = tbP.Text;
            var racun = new ObservableCollection<Racun>();
            switch (sp)
            {
                case "DatumProdaje":
                    racun = Racun.Search(Racun.Prikaz.DatumProdaje, tb);
                    view = CollectionViewSource.GetDefaultView(racun);
                    view.Filter = RacunFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case "Cena":
                    racun = Racun.Search(Racun.Prikaz.Cena, tb);
                    view = CollectionViewSource.GetDefaultView(racun);
                    view.Filter = RacunFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case "Kupac":
                    racun = Racun.Search(Racun.Prikaz.Kupac, tb);
                    view = CollectionViewSource.GetDefaultView(racun);
                    view.Filter = RacunFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;

            }
        }

        private void btRacun_Click(object sender, RoutedEventArgs e)
        {
            Salon sa = new Salon()
            {
                Id = 0001,
                PIB = 1111,
                Naziv = "FormaIdeale",
                Adresa = "Bulevar Oslobodjenja 45",
                Telefon = "068/58746952",
                Email = "forma@gmail.com",
                AdresaSajta = "formaideale.rs",
                MaticniBroj = 124141,
                BrojZiroRacuna = "415152626",
            };
            var racun = (Racun)dgPrikaz.SelectedItem;
            var r = new RacunIzgled(racun, sa);
            r.Show();
        }
    }
}
