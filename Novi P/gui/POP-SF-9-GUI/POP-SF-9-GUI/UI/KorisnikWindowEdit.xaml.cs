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
    /// Interaction logic for KorisnikWindowEdit.xaml
    /// </summary>

    public partial class KorisnikWindowEdit : Window
    {
        private Korisnik korisnik;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public KorisnikWindowEdit(Operacija operacija, Korisnik korisnik)
        {
            InitializeComponent();
            this.operacija = operacija;
            this.korisnik = korisnik;
            tbIme.DataContext = korisnik;
            tbKI.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            cbTipNamestaja.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();
           
            cbTipNamestaja.DataContext = korisnik;
            cbTipNamestaja.SelectedIndex = 0;
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Sacuvaj_Korisnik(object sender, RoutedEventArgs e)
        {
            try
            {
                var korisnici = Projekat.Instance.korisnik;
                switch (operacija)
                {
                    case Operacija.DODAVANJE:
                        foreach (var k in Projekat.Instance.korisnik)
                        {
                            if (k.KorisnickoIme.ToLower().Equals(korisnik.KorisnickoIme.ToLower()))
                            {
                                
                                MessageBox.Show("Postoji korisnik sa tim korisnickim imenom izaberite drugo", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                Korisnik.Create(korisnik);
                            }
                        }
                        
                        break;
                    case Operacija.IZMENA:
                        foreach (var k in korisnici)
                        {
                            if (k.Id == korisnik.Id)
                            {
                                if (Korisnik.KorisnikPostoji(korisnik.KorisnickoIme) == true)
                                {
                                    k.Ime = korisnik.Ime;
                                    k.Prezime = korisnik.Prezime;
                                    k.KorisnickoIme = korisnik.KorisnickoIme;
                                    k.Lozinka = korisnik.Lozinka;
                                    k.TipKorisnika = korisnik.TipKorisnika;
                                    Korisnik.Update(k);
                                }
                                else
                                {
                                    MessageBox.Show("Postoji korisnik sa tim korisnickim imenom izaberite drugo", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                break;
                            }
                        }
                        break;
                }

                
            }
            catch { }
            this.Close();
        }
    }
}
