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
    /// Interaction logic for DodatnaUslugaWindowEdit.xaml
    /// </summary>
    public partial class DodatnaUslugaWindowEdit : Window
    {
        private DodatnaUsluga dodatnaUsluga;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public DodatnaUslugaWindowEdit(Operacija operacija,DodatnaUsluga dodatnaUsluga)
        {
            InitializeComponent();
            this.operacija = operacija;
            this.dodatnaUsluga = dodatnaUsluga;

            tbCena.DataContext = dodatnaUsluga;
            tbNaziv.DataContext = dodatnaUsluga;
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var postojeciDU = Projekat.Instance.DU;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    DodatnaUsluga.Create(dodatnaUsluga);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciDU)
                    {
                        if (n.Id == dodatnaUsluga.Id)
                        {
                            n.Naziv = dodatnaUsluga.Naziv;
                            n.Cena = dodatnaUsluga.Cena;
                            DodatnaUsluga.Update(n);
                            break;
                        }
                    }
                    break;
            }
            

            this.Close();

        }
    }
}
