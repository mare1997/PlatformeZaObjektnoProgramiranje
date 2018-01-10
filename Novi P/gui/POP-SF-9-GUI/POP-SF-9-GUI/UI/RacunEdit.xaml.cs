using POP_SF_9_GUI.Model;
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

namespace POP_SF_9_GUI.UI
{
    /// <summary>
    /// Interaction logic for RacunEdit.xaml
    /// </summary>
    public partial class RacunEdit : Window
    {
        private ICollectionView viewN;
        private ICollectionView viewDU;
        private Operacija operacija;
        private List<StavkaProdajeNamestaj> listaN = new List<StavkaProdajeNamestaj>();
        private List<StavkaProdajeDU> listaDU = new List<StavkaProdajeDU>();
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        private Racun racun;
        public RacunEdit(Operacija operacija, Racun racun)
        {
            InitializeComponent();
            this.racun = racun;
            this.operacija = operacija;
            tbKupac.DataContext = racun;
            label4.DataContext = racun;
            
            
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    
                    
                    racun.Id = Projekat.Instance.pn.Count + 1;
                    racun.DatumProdaje = DateTime.Today;
                    viewN = CollectionViewSource.GetDefaultView(n());
                    viewN.Filter = namestajFilter;
                    dataGridNamestaj.ItemsSource = viewN;
                    dataGridNamestaj.IsSynchronizedWithCurrentItem = true;
                    dataGridNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    viewDU = CollectionViewSource.GetDefaultView(d());
                    viewDU.Filter = duFilter;
                    dataGridUsluge.ItemsSource = viewDU;
                    dataGridUsluge.IsSynchronizedWithCurrentItem = true;
                    dataGridUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Operacija.IZMENA:
                    viewN = CollectionViewSource.GetDefaultView(n());
                    viewN.Filter = namestajFilter;
                    dataGridNamestaj.ItemsSource = viewN;
                    dataGridNamestaj.IsSynchronizedWithCurrentItem = true;
                    dataGridNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    viewDU = CollectionViewSource.GetDefaultView(d());
                    viewDU.Filter = duFilter;
                    dataGridUsluge.ItemsSource = viewDU;
                    dataGridUsluge.IsSynchronizedWithCurrentItem = true;
                    dataGridUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
            }
        }
        private List<StavkaProdajeNamestaj> n()
        {
            listaN.Clear();
            foreach (var spn in Projekat.Instance.spn)
            {
                if (spn.RacunId == racun.Id)
                    listaN.Add(spn);
            }
            return listaN;
        }
        private List<StavkaProdajeDU> d()
        {
            listaDU.Clear();
            foreach (var spdu in Projekat.Instance.spdu)
            {
                if (spdu.RacunId == racun.Id)
                    listaDU.Add(spdu);
            }
            return listaDU;
        }
        private void btSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            
            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    racun.DatumProdaje = DateTime.Today;
                  
                    racun.UkupnaCena= IZracunajCenuRacuna();
                    Racun.Create(racun);
                    break;
                case Operacija.IZMENA:
                    
                    racun.UkupnaCena = IZracunajCenuRacuna();
                    Racun.Update(racun);
                    break;
            }
            this.Close();
        }
        public  double IZracunajCenuRacuna()
        {
            double cena = 0;
            foreach (var n in Projekat.Instance.spn)
            {
                
                if (racun.Id == n.RacunId)
                {
                    Namestaj nn = Namestaj.GetById(n.NamestajId);
                    for (int i = 1; i <= n.Kolicina; i++)
                    {
                        if (nn.Akcija == null)
                        {
                            cena += nn.Cena;
                        }
                        else
                        {
                            cena += nn.Cena - (nn.Cena * nn.Akcija.Popust/ 100);
                        }
                    }


                }
            }
            foreach (var du in Projekat.Instance.spdu)
            {
                if (racun.Id == du.RacunId)
                {
                    DodatnaUsluga duu = DodatnaUsluga.GetById(du.DUId);
                    cena += duu.Cena;
                }
            }
           cena = cena * 0.98;
            return cena;

        }
        private bool namestajFilter(object obj)
        {
            return true;
        }
        private bool duFilter(object obj)
        {
            return true;
        }
        private void btIzlaz_Click(object sender, RoutedEventArgs e)
        {
            /*var lista = new ObservableCollection<StavkaProdajeNamestaj>();

            foreach (var n in lista)
            {
                if (n.RacunId == racun.Id)
                {
                    StavkaProdajeNamestaj.Delete(n);
                }
            }
            var listaa = new ObservableCollection<StavkaProdajeDU>();
            listaa = Projekat.Instance.spdu;
            foreach (var du in listaa)
            {
                if (du.RacunId == racun.Id)
                {
                    StavkaProdajeDU.Delete(du);
                }
            }*/
            this.Close();
        }

        private void brObrisi1_Click(object sender, RoutedEventArgs e)
        {
            var sn = (StavkaProdajeNamestaj)dataGridNamestaj.SelectedItem;
            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani namestaj: {sn.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var lista = new ObservableCollection<StavkaProdajeNamestaj>();
                foreach (var n in Projekat.Instance.spn)
                {
                    if (n == sn)
                    {
                        lista.Add(n);
                    }
                }
                foreach (var nn in lista)
                {
                    foreach (var nam in Projekat.Instance.namestaj)
                    {
                        if (nn.NamestajId == nam.Id)
                        {
                            Namestaj.PromeniKolicinu(nam.Id, nn.Kolicina, true);
                        }
                    }
                    StavkaProdajeNamestaj.Delete(nn);
                    viewN = CollectionViewSource.GetDefaultView(n());
                    viewN.Filter = namestajFilter;
                    dataGridNamestaj.ItemsSource = viewN;
                    dataGridNamestaj.IsSynchronizedWithCurrentItem = true;
                    dataGridNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                }
            }
            
        }
        private void brObrisi2_Click(object sender, RoutedEventArgs e)
        {
            var sn = (StavkaProdajeDU)dataGridUsluge.SelectedItem;
            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabranu uslugu: {sn.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var lista =new ObservableCollection<StavkaProdajeDU>();
               
                foreach (var n in Projekat.Instance.spdu)
                {
                    if (n == sn)
                    {
                        lista.Add(n);
                    }
                }
                foreach (var n in lista)
                {
                    
                        StavkaProdajeDU.Delete(n);
                    viewDU = CollectionViewSource.GetDefaultView(d());
                    viewDU.Filter = duFilter;
                    dataGridUsluge.ItemsSource = viewDU;
                    dataGridUsluge.IsSynchronizedWithCurrentItem = true;
                    dataGridUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                }
            }
        }

        private void btNamestaj_Click(object sender, RoutedEventArgs e)
        {
            
            RacunEditNamestajDU r = new RacunEditNamestajDU(RacunEditNamestajDU.Operacija.Namestaj, racun);
            r.ShowDialog();
            racun.UkupnaCena = IZracunajCenuRacuna();
            Racun.Update(racun);
            viewN = CollectionViewSource.GetDefaultView(n());
            viewN.Filter = namestajFilter;
            dataGridNamestaj.ItemsSource = viewN;
            dataGridNamestaj.IsSynchronizedWithCurrentItem = true;
            dataGridNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            viewDU = CollectionViewSource.GetDefaultView(d());
            viewDU.Filter = duFilter;
            dataGridUsluge.ItemsSource = viewDU;
            dataGridUsluge.IsSynchronizedWithCurrentItem = true;
            dataGridUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btDU_Click(object sender, RoutedEventArgs e)
        {
            
            RacunEditNamestajDU r = new RacunEditNamestajDU(RacunEditNamestajDU.Operacija.DodatnaUsluga, racun);
            r.ShowDialog();
            racun.UkupnaCena = IZracunajCenuRacuna();
            Racun.Update(racun);
            
            viewN = CollectionViewSource.GetDefaultView(n());
            viewN.Filter = namestajFilter;
            dataGridNamestaj.ItemsSource = viewN;
            dataGridNamestaj.IsSynchronizedWithCurrentItem = true;
            dataGridNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            viewDU = CollectionViewSource.GetDefaultView(d());
            viewDU.Filter = duFilter;
            dataGridUsluge.ItemsSource = viewDU;
            dataGridUsluge.IsSynchronizedWithCurrentItem = true;
            dataGridUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        

        private void dataGridNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "RacunId" || (string)e.Column.Header == "NamestajId")
            {
                e.Cancel = true;
            }
        }

        private void dataGridUsluge_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "RacunId" || (string)e.Column.Header == "DUId")
            {
                e.Cancel = true;
            }
        }
    }
}
