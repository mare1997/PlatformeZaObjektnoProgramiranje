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
            this.namestaj = noviNamestaj;
            this.operacija = operacija;
            cbTipNamestaja.ItemsSource = Projekat.Instance.TN;
            
            tbNaziv.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKuM.DataContext = namestaj;
            
            cbTipNamestaja.DataContext = namestaj;
            cbTipNamestaja.SelectedIndex = 0;
            if (namestaj.Akcija != null)
            {   
                lbAkcija.Content = namestaj.Akcija.ToString();
            }
             
        }
        
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SacuvajNamestaj(object sender, RoutedEventArgs e)
        {
            var postojeciNamestaj = Projekat.Instance.namestaj;
            
            switch (operacija)
            {
                
                case Operacija.DODAVANJE:
                    Namestaj.Create(namestaj);    
                    
                    
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciNamestaj)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.Kolicina = namestaj.Kolicina;
                            n.Cena = namestaj.Cena;
                            n.TipN = namestaj.TipN;
                            Namestaj.Update(namestaj);
                            break;
                        }
                    }
                    break;
                


            }
            GenericSerializer.Serialize("namestaj.xml",postojeciNamestaj);
            
            this.Close();
        }
        
        private void DodajAkciju(object sender, RoutedEventArgs e)
        {   
            var akcija = new AkcijaWindow(operacija, namestaj);
            akcija.ShowDialog();
        }
    }
}
