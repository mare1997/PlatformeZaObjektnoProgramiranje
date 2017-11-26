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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        private TipNamestaja tipNamestaja;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public TipNamestajaWindow(Operacija operacija,TipNamestaja tipNamestaja)
        {
            InitializeComponent();
            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;
            tbNaziv.DataContext = tipNamestaja;
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var postojeciTNamestaj = Projekat.Instance.TN;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var Id = postojeciTNamestaj.Count + 1;
                    tipNamestaja.Id = Id;
                    postojeciTNamestaj.Add(tipNamestaja);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciTNamestaj)
                    {
                        if (n.Id == tipNamestaja.Id)
                        {
                            n.Naziv = tipNamestaja.Naziv;
                            
                            break;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("tipnamestaja.xml", postojeciTNamestaj);

            this.Close();

        }
        
    }
}
