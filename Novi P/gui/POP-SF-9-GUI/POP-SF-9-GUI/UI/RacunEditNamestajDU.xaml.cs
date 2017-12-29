using POP_SF_9_GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RacunEditNamestajDU.xaml
    /// </summary>
    public partial class RacunEditNamestajDU : Window
    {
        Racun racun;
        private Operacija operacija;
        public enum Operacija
        {
            Namestaj,
            DodatnaUsluga,

        };
        private ICollectionView view;
        
        public RacunEditNamestajDU(Operacija operacija, Racun racun)
        {   
            InitializeComponent();
            this.operacija = operacija;
            this.racun = racun;
            tbKolicina.DataContext = racun;
            switch (operacija)
            {
                case Operacija.Namestaj:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.namestaj);
                    view.Filter = namestajFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Operacija.DodatnaUsluga:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.DU);
                    view.Filter = dodatnaFilter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    
                    break;
            }
        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {   var listaracuna = Projekat.Instance.pn;
            int k = int.Parse(tbKolicina.Text);
            
            switch (operacija)
            {   
                case Operacija.Namestaj:
                    var selektovaniNamestaj = (Namestaj)dgPrikaz.SelectedItem;
                    StavkaProdajeNamestaj spn = new StavkaProdajeNamestaj();
                    spn.Kolicina = k;
                    spn.NamestajId = selektovaniNamestaj.Id;
                    spn.RacunId = racun.Id;
                    
                    StavkaProdajeNamestaj.Create(spn);
                    break;
                case Operacija.DodatnaUsluga:
                    var selektovan = (DodatnaUsluga)dgPrikaz.SelectedItem;
                    StavkaProdajeDU spdu = new StavkaProdajeDU();
                    spdu.RacunId = racun.Id;
                    spdu.DUId = selektovan.Id;
                    StavkaProdajeDU.Create(spdu);


                    break;
            }
            
            
            Racun.Update(racun);
           

        }

        private void btIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool namestajFilter(object obj)
        {
            if (((Namestaj)obj).Obrisan == false && ((Namestaj)obj).TipNamestaja.Obrisan == false)
            {
                return true;
            }
            return false;
        }
        private bool dodatnaFilter(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }
        private bool RacunFilter(object obj)
        {
            return true;
        }
        private void dgPrikaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (operacija)
            {
                case Operacija.Namestaj:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "ak" || (string)e.Column.Header == "TipN" || (string)e.Column.Header == "Cena" || (string)e.Column.Header == "TipNamestaja" || (string)e.Column.Header == "Akcija")
                    {
                        e.Cancel = true;
                    }

                    break;

                case Operacija.DodatnaUsluga:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Cena")
                    {
                        e.Cancel = true;
                    }
                    break;

            }
        }
    }
}
