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
                    dataGridNamestaj.ItemsSource = racun.Namestaj;
                    dataGridUsluge.ItemsSource = racun.DodatnaUsluga;
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
                    /*foreach (KeyValuePair<int, int> entry in racun.Namestaj)
                    {
                        Namestaj nam = Namestaj.GetById(entry.Key);
                        racun.UkupnaCena += nam.Cena * entry.Value;
                    }
                    */
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
                    /*foreach (KeyValuePair<int, int> entry in racun.Namestaj)
                    {
                        Namestaj nam = Namestaj.GetById(entry.Key);
                        racun.UkupnaCena += nam.Cena * entry.Value;
                    }
                    */
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
    }
}
