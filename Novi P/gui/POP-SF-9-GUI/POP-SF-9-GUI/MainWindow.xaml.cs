using POP_SF_9_GUI.Model;
using POP_SF_9_GUI.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_9_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            



            cbTipKorisnika.Items.Add(TipKorisnika.Administrator);
            cbTipKorisnika.Items.Add(TipKorisnika.Prodavac);
            cbTipKorisnika.SelectedIndex = 0;
            

        }
        private void Potvrdi(object sender, RoutedEventArgs e)
        {

            
                if (Logovanje(tbKI.Text, tbPass.Text, cbTipKorisnika.SelectedItem.ToString()) == true)
                {
                    var gp = new GlavniProzor((TipKorisnika)cbTipKorisnika.SelectedItem);
                    gp.Show();
                }
            
            else { MessageBox.Show("Prijava nije uspela! Pokusajte ponovo", "Pogresno logovanje", MessageBoxButton.OK, MessageBoxImage.Error); OsveziProkaz(); }

        }

        private void OsveziProkaz()
        {
            tbKI.Clear();
            tbPass.Clear();
        }

        private static bool Logovanje(String id, String pass, String tip)
        {
            
            foreach (var k in Projekat.Instance.korisnik)
            {
                
                if (id == k.KorisnickoIme && pass == k.Lozinka && k.TipKorisnika.ToString() == tip)
                    return true;
                
            }
            return false;
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
