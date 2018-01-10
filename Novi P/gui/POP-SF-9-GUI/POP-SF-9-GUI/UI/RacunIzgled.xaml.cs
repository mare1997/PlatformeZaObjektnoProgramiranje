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
    /// Interaction logic for RacunIzgled.xaml
    /// </summary>
    public partial class RacunIzgled : Window
    {
        public RacunIzgled(Racun racun,Salon salon)
        {
            InitializeComponent();
            lbIme.Content = salon.Naziv;
            lbAdresa.Content = salon.Adresa;
            lbPIB.Content = salon.PIB;
            lbTelefon.Content = salon.Telefon;
            lbPdv.Content = racun.UkupnaCena * 0.02;
            lbOsnovica.Content =(racun.UkupnaCena + (racun.UkupnaCena * 0.02));
            lUkupnaCena.Content = racun.UkupnaCena;
            lbDate.Content = racun.DatumProdaje;
            foreach (var n in Projekat.Instance.spn)
            {
                if (n.RacunId == racun.Id)
                {
                    var nam = Namestaj.GetById(n.NamestajId);
                    listBox.Items.Add($"{nam.Naziv}");
                    listBox.Items.Add($"{n.Kolicina} x {nam.Cena}                                         {n.Kolicina*nam.Cena}");   
                                                                             
                }
            }
           

        }
    }
}
