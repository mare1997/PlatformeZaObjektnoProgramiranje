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
    /// Interaction logic for NamstajWindowDodavanjeIzmena.xaml
    /// </summary>
    
    public partial class NamstajWindowDodavanjeIzmena : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,
            
        };
        public NamstajWindowDodavanjeIzmena(Namestaj noviNamestaj, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(noviNamestaj, operacija);
            foreach (var tn in Projekat.Instance.TipNamestaja)
            {
                cbTipNamestaja.Items.Add(tn);
                cbTipNamestaja.SelectedIndex = 0;
            }
        }
        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;
            if (operacija == Operacija.IZMENA)
            {
                tbNaziv.Text = namestaj.Naziv;
                tbKuM.Text = namestaj.Kolicina.ToString();
                tbCena.Text = namestaj.Cena.ToString();
                foreach (var tn in Projekat.Instance.TipNamestaja)
                {
                    
                    if (tn == TipNamestaja.GetById(namestaj.TipN))
                    {
                        cbTipNamestaja.SelectedItem = tn;
                    }
                }
            }
            
                    
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SacuvajNamestaj(object sender, RoutedEventArgs e)
        {
            List<Namestaj> postojeciNamestaj = Projekat.Instance.Namestaj;
            var tn = (TipNamestaja)cbTipNamestaja.SelectedItem;
            switch (operacija)
            {

                case Operacija.DODAVANJE:
                    
                    var noviNamestaj = new Namestaj()
                    {   Id = NoviIDzaNamestaj(),
                        Naziv = tbNaziv.Text,
                        Cena = int.Parse(tbCena.Text),
                        Kolicina= int.Parse(tbKuM.Text),
                        TipN= tn.Id,
                    };
                    postojeciNamestaj.Add(noviNamestaj);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciNamestaj)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            n.Kolicina = int.Parse(tbKuM.Text);
                            n.Cena = int.Parse(tbCena.Text);
                            n.TipN = tn.Id;
                            break;
                        }
                    }
                    break;
                


            }
            Projekat.Instance.Namestaj = postojeciNamestaj;
            this.Close();
        }
        private static int NoviIDzaNamestaj() {
            int j = 0;
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (j <= namestaj.Id)
                    j = namestaj.Id;

            } return j + 1;
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {   
            var akcija = new AkcijaWindow(Operacija.DODAVANJE,namestaj);
            akcija.ShowDialog();
        }
    }
}
