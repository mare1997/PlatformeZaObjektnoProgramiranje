using POP_SF_9_GUI.Model;
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
            foreach (var spn in Projekat.Instance.spn)
            {
                if (racun.Id == spn.RacunId)
                    listaN.Add(spn);
            }
            foreach (var spdu in Projekat.Instance.spdu)
            {
                if (spdu.RacunId == racun.Id)
                    listaDU.Add(spdu);
            }
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    racun.Id = Projekat.Instance.pn.Count + 1;
                    viewN = CollectionViewSource.GetDefaultView(listaN);
                    viewN.Filter = namestajFilter;
                    dataGridNamestaj.ItemsSource = viewN;
                    dataGridNamestaj.IsSynchronizedWithCurrentItem = true;
                    dataGridNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    viewDU = CollectionViewSource.GetDefaultView(listaDU);
                    viewDU.Filter = duFilter;
                    dataGridUsluge.ItemsSource = viewDU;
                    dataGridUsluge.IsSynchronizedWithCurrentItem = true;
                    dataGridUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Operacija.IZMENA:
                    viewN = CollectionViewSource.GetDefaultView(listaN);
                    viewN.Filter = namestajFilter;
                    dataGridNamestaj.ItemsSource = viewN;
                    dataGridNamestaj.IsSynchronizedWithCurrentItem = true;
                    dataGridNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

                    viewDU = CollectionViewSource.GetDefaultView(listaDU);
                    viewDU.Filter = duFilter;
                    dataGridUsluge.ItemsSource = viewDU;
                    dataGridUsluge.IsSynchronizedWithCurrentItem = true;
                    dataGridUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
            }
        }

        private void btSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.pn;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    
                    racun.DatumProdaje = DateTime.Today;
                   

                    foreach (var n in Projekat.Instance.spn)
                    {
                        if (racun.Id == n.RacunId)
                        {
                            Namestaj nn = Namestaj.GetById(n.NamestajId);
                            for (int i = 1; i <= n.Kolicina; i++)
                            {
                                if (nn.Akcija == null)
                                {
                                    racun.UkupnaCena += nn.Cena;
                                }
                                else
                                {
                                    racun.UkupnaCena += nn.Cena - (nn.Cena * 100 / nn.Akcija.Popust);
                                }
                            }
                            
                            
                        }
                    }
                    foreach (var du in Projekat.Instance.spdu)
                    {
                        if (racun.Id == du.RacunId)
                        {
                            DodatnaUsluga duu = DodatnaUsluga.GetById(du.DUId);
                            racun.UkupnaCena += duu.Cena;
                        }
                    }
                    racun.UkupnaCena = racun.UkupnaCena * 0.98;
                    Racun.Create(racun);
                    break;
                case Operacija.IZMENA:

                    foreach (var n in Projekat.Instance.spn)
                    {
                        if (racun.Id == n.RacunId)
                        {
                            Namestaj nn = Namestaj.GetById(n.NamestajId);
                            for (int i = 1; i <= n.Kolicina; i++)
                            {
                                if (nn.Akcija == null)
                                {
                                    racun.UkupnaCena += nn.Cena;
                                }
                                else
                                {
                                    racun.UkupnaCena += nn.Cena - (nn.Cena * 100 / nn.Akcija.Popust);
                                }
                            }


                        }
                    }
                    foreach (var du in Projekat.Instance.spdu)
                    {
                        if (racun.Id == du.RacunId)
                        {
                            DodatnaUsluga duu = DodatnaUsluga.GetById(du.DUId);
                            racun.UkupnaCena += duu.Cena;
                        }
                    }
                    racun.UkupnaCena = racun.UkupnaCena * 0.98;
                    Racun.Update(racun);
                    break;
            }
            this.Close();
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
        {   foreach (var n in Projekat.Instance.spn)
            {
                if (n.RacunId == racun.Id)
                {
                    StavkaProdajeNamestaj.Delete(n);
                }
            }
            foreach (var du in Projekat.Instance.spdu)
            {
                if (du.RacunId == racun.Id)
                {
                    StavkaProdajeDU.Delete(du);
                }
            }
            this.Close();
        }

        private void brObrisi1_Click(object sender, RoutedEventArgs e)
        {
            var sn = (StavkaProdajeNamestaj)dataGridNamestaj.SelectedItem;
            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani namestaj: {sn.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in Projekat.Instance.spn)
                {
                    if (n == sn)
                    {
                        StavkaProdajeNamestaj.Delete(n);
                    }
                }
            }
            
        }
        private void brObrisi2_Click(object sender, RoutedEventArgs e)
        {
            var sn = (StavkaProdajeDU)dataGridUsluge.SelectedItem;
            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabranu uslugu: {sn.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in Projekat.Instance.spdu)
                {
                    if (n == sn)
                    {
                        StavkaProdajeDU.Delete(n);
                    }
                }
            }
        }

        private void btNamestaj_Click(object sender, RoutedEventArgs e)
        {
            RacunEditNamestajDU r = new RacunEditNamestajDU(RacunEditNamestajDU.Operacija.Namestaj, racun);
            r.ShowDialog();
            viewN.Refresh();
        }

        private void btDU_Click(object sender, RoutedEventArgs e)
        {
            RacunEditNamestajDU r = new RacunEditNamestajDU(RacunEditNamestajDU.Operacija.DodatnaUsluga, racun);
            r.ShowDialog();
            viewDU.Refresh();
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
