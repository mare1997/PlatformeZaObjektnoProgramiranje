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
        AkcijskaProdaja akcija;
        public AkcijaWindow(Operacija operacija, Namestaj noviNamestaj,AkcijskaProdaja akcija)
        {
            InitializeComponent();
            
            this.namestaj = noviNamestaj;
            this.operacija = operacija;
            this.akcija = akcija;
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
            Console.WriteLine(akcija.Popust);
            if (akcija.Popust > 0 || akcija.Popust < 91)
            {
                switch (operacija)
                {
                    case Operacija.DODAVANJE:


                        if (result < 0)
                        {
                            AkcijskaProdaja.Create(akcija);
                            namestaj.ak = akcija.Id;
                            Namestaj.Update(namestaj);
                        }
                        else
                        {
                            MessageBox.Show("Datum kraja akcije ne moze da bude ranije od pocetka", "Pogresno vreme", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case Operacija.IZMENA:


                        if (result < 0)
                        {
                            foreach (var nn in n)
                            {
                                if (nn.ak == namestaj.ak)
                                {
                                    AkcijskaProdaja.Update(akcija);
                                    nn.ak = akcija.Id;
                                    Namestaj.Update(namestaj);
                                }
                                else
                                {
                                    AkcijskaProdaja.Create(akcija);
                                    namestaj.ak = akcija.Id;
                                    Namestaj.Update(namestaj);
                                }
                            }



                        }
                        else
                        {
                            MessageBox.Show("Datum kraja akcije ne moze da bude ranije od pocetka", "Pogresno vreme", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                }
            }
            else
            {
                MessageBox.Show("Akcija ne moze biti manja od 0 ili veca od 90%", "Akcija", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
           

            this.Close();

        }
    }
}
