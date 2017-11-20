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
        public AkcijaWindow(Operacija operacija, Namestaj noviNamestaj)
        {
            this.namestaj = noviNamestaj;
            this.operacija = operacija;
            InitializeComponent();
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
           /* if (operacija == Operacija.DODAVANJE)
           {    
                //namestaj.Akcija.Id=
                namestaj.Akcija.Popust = int.Parse(tbPopust.Text);
                if(dpK > dpP)
            }
            else
            {

            }*/
        }
    }
}
