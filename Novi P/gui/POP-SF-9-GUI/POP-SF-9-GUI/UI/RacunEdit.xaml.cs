using POP_SF_9_GUI.Model;
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

namespace POP_SF_9_GUI.UI
{
    /// <summary>
    /// Interaction logic for RacunEdit.xaml
    /// </summary>
    public partial class RacunEdit : Window
    {
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        Racun racun;
        public RacunEdit(Operacija operacija, Racun racun)
        {
            InitializeComponent();
            this.racun = racun;
            this.operacija = operacija;
            tbKupac.DataContext = racun;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    DataGridDodavanje(RacunEditNamestajDU.Operacija.Namestaj);
                    DataGridDodavanje(RacunEditNamestajDU.Operacija.DodatnaUsluga);
                    break;
                case Operacija.IZMENA:break;
            }
        }

        private void btSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.pn;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    
                    racun.DatumProdaje = DateTime.Today;
                    racun.Id = lista.Count + 1;

                    foreach (int n in racun.Namestaj)
                    {
                        Namestaj nn = Namestaj.GetById(n);
                        racun.UkupnaCena += nn.Cena;
                    }
                    foreach (int du in racun.DodatnaUsluga)
                    {
                        DodatnaUsluga duu = DodatnaUsluga.GetById(du);
                        racun.UkupnaCena += duu.Cena;
                    }
                    racun.UkupnaCena = racun.UkupnaCena * 0.02;
                    lista.Add(racun);
                    break;
                case Operacija.IZMENA:
                    
                    racun.DatumProdaje = DateTime.Today;
                    foreach (int n in racun.Namestaj)
                    {
                        Namestaj nn = Namestaj.GetById(n);
                        racun.UkupnaCena += nn.Cena;
                    }
                    foreach (int du in racun.DodatnaUsluga)
                    {
                        DodatnaUsluga duu = DodatnaUsluga.GetById(du);
                        racun.UkupnaCena += duu.Cena;
                    }
                    racun.UkupnaCena = racun.UkupnaCena * 0.02;
                    break;
            }
            GenericSerializer.Serialize("prodajanamestaja.xml", lista);
        }

        private void btIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btNamestaj_Click(object sender, RoutedEventArgs e)
        {
            RacunEditNamestajDU r = new RacunEditNamestajDU(RacunEditNamestajDU.Operacija.Namestaj, racun);
            r.ShowDialog();
        }

        private void btDU_Click(object sender, RoutedEventArgs e)
        {
            RacunEditNamestajDU r = new RacunEditNamestajDU(RacunEditNamestajDU.Operacija.DodatnaUsluga, racun);
            r.ShowDialog();
        }
        private void DataGridDodavanje(RacunEditNamestajDU.Operacija operacija)
        {
            var listaracuna = Projekat.Instance.pn;
            foreach (var r in listaracuna)
            {
                if (r.Id == racun.Id)
                {
                    racun = r;
                }
            }
            List<Namestaj> listaN = new List<Namestaj>();
            List<DodatnaUsluga> listaDU = new List<DodatnaUsluga>();
            if (racun.Namestaj != null && racun.DodatnaUsluga != null)
            {
                foreach (var r in racun.Namestaj)
                {
                    listaN.Add(Namestaj.GetById(r));
                }
                foreach (var r in racun.DodatnaUsluga)
                {
                    listaDU.Add(DodatnaUsluga.GetById(r));
                }
            }
            


            switch (operacija)
            {
                case RacunEditNamestajDU.Operacija.Namestaj:
                    DataGrid dgn = new DataGrid();
                    DataGridTextColumn d1 = new DataGridTextColumn();
                    d1.Header = "Naziv";
                    d1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    d1.Binding = new Binding("Naziv");
                    DataGridTextColumn d3 = new DataGridTextColumn();
                    d3.Header = "Kolicina";
                    d3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    d3.Binding = new Binding("KolicinaPriProdaji");
                    dataGridNamestaj.Columns.Add(d1);
                    dataGridNamestaj.Columns.Add(d3);
                    dataGridNamestaj.ItemsSource = listaN ;
                    break;
                case RacunEditNamestajDU.Operacija.DodatnaUsluga:
                    DataGrid dgnn = new DataGrid();
                    DataGridTextColumn d11 = new DataGridTextColumn();
                    d11.Header = "Naziv";
                    d11.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    d11.Binding = new Binding("Naziv");
                    dataGridUsluge.Columns.Add(d11);
                    dataGridUsluge.ItemsSource = listaDU;
                    break;
            }



            
        }
    }
}
