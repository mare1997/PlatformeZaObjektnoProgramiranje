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
using static POP_SF_9_GUI.UI.NamstajWindowDodavanjeIzmena;

namespace POP_SF_9_GUI.UI
{
    /// <summary>
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        Namestaj namestaj;
        Operacija operacija;
        AkcijskaProdaja akcija = new AkcijskaProdaja() ;
        public AkcijaWindow(Operacija operacija, Namestaj noviNamestaj)
        {
            InitializeComponent();
            
            this.namestaj = noviNamestaj;
            this.operacija = operacija;
            
            tbPopust.DataContext = akcija;
            dpP.DataContext= akcija;
            dpK.DataContext = akcija;
            

        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var postojeceAkcije = Projekat.Instance.akcija;
            DateTime date1 = dpP.SelectedDate.Value.Date;
            DateTime date2 = dpK.SelectedDate.Value.Date;
            int result = DateTime.Compare(date1, date2);
            var n = Projekat.Instance.namestaj;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    
                    
                    if (result < 0)
                    {
                        var Id = postojeceAkcije.Count + 1;
                        akcija.Id = Id;
                        namestaj.ak = Id;

                        postojeceAkcije.Add(akcija);
                    }
                    else
                    {
                        MessageBox.Show("Datum kraja akcije ne moze da bude ranije od pocetka", "Pogresno vreme", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case Operacija.IZMENA:

                    
                    if (result < 0)
                    {   foreach(var nn in n)
                        {
                            if (nn.ak == namestaj.ak)
                            {
                                var Idd = postojeceAkcije.Count + 1;
                                akcija.Id = Idd;
                                nn.ak = Idd;
                            }
                        }
                        

                        postojeceAkcije.Add(akcija);
                    }
                    else
                    {
                        MessageBox.Show("Datum kraja akcije ne moze da bude ranije od pocetka", "Pogresno vreme", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                   
            }
            
            
            GenericSerializer.Serialize("akcija.xml", postojeceAkcije);
            GenericSerializer.Serialize("namestaj.xml", n);

            this.Close();

        }
    }
}
