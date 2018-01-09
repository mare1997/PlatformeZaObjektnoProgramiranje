using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
       
     }
    
    public class Korisnik: INotifyPropertyChanged
    {
        public enum Prikaz
        {
            Ime,
            Prezime,
            KorisnickoIme,
            Lozinka,
            TipKorisnika,
        };
        public enum NacinSortiranja
        {
            asc,
            desc,
        };
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }

        }
        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }
        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }
        private string korisnickoIme;
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); }
        }
        private string lozinka;
        public string Lozinka
        {
            get { return lozinka; }
            set {lozinka = value; OnPropertyChanged("Lozinka"); }
        }
        
        
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        private TipKorisnika tip;
        public TipKorisnika TipKorisnika
        {
            get { return tip; }
            set { tip = value; OnPropertyChanged("TipKorisnika"); }
        }
        public object Clone()
        {
            return new Korisnik()
            {
                id = Id,
                obrisan = Obrisan,
                ime=Ime,
                prezime=Prezime,
                lozinka=Lozinka,
                korisnickoIme=KorisnickoIme,
                tip=TipKorisnika,
            };
        }
        public static Boolean KorisnikPostoji(String username)
        {
            foreach (var korisnik in Projekat.Instance.korisnik)
            {
                if (korisnik.KorisnickoIme.ToLower() == username.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        #region Database
        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnik = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var k = new Korisnik();
                    k.Id = int.Parse(row["Id"].ToString());
                    k.Ime = row["Ime"].ToString();
                    k.Prezime = row["Prezime"].ToString();
                    k.KorisnickoIme = row["KorisnickoIme"].ToString();
                    k.Lozinka = row["Lozinka"].ToString();
                    k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    bool b = bool.Parse(row["TipKorisnika"].ToString());
                    if (b == true)
                    {
                        
                        k.TipKorisnika = TipKorisnika.Prodavac;
                    }
                    else
                    {
                        k.TipKorisnika = TipKorisnika.Administrator;
                    }

                    korisnik.Add(k);

                }
                return korisnik;
            }
        }
        public static Korisnik Create(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into Korisnik (Obrisan,Ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika) Values(@Obrisan,@Ime,@Prezime,@KorisnickoIme,@Lozinka,@TipKorisnika);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                if (k.TipKorisnika == TipKorisnika.Administrator)
                {
                    cmd.Parameters.AddWithValue("TipKorisnika", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TipKorisnika", 0);
                }
                
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                k.Id = newId;


            }
            Projekat.Instance.korisnik.Add(k);//obrati paznju {azurira i stanje modela}
            return k;
        }
        public static void Update(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update Korisnik set Obrisan=@Obrisan,Ime=@Ime,Prezime=@Prezime,KorisnickoIme=@KorisnickoIme,Lozinka=@Lozinka,TipKorisnika=@TipKorisnika where Id=@Id";
                cmd.Parameters.AddWithValue("Id", k.Id);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                if (k.TipKorisnika == TipKorisnika.Administrator)
                {
                    cmd.Parameters.AddWithValue("TipKorisnika", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TipKorisnika", 0);
                }

                cmd.ExecuteNonQuery();

                foreach (var korisnik in Projekat.Instance.korisnik)
                {
                    if (korisnik.Id == k.Id)
                    {
                        korisnik.Obrisan = k.Obrisan;
                        korisnik.Ime = k.Ime;
                        korisnik.Prezime = k.Prezime;
                        korisnik.KorisnickoIme = k.KorisnickoIme;
                        korisnik.Lozinka = k.Lozinka;
                        korisnik.TipKorisnika = k.TipKorisnika;
                        break;
                    }
                }
            }


        }
        public static void Delete(Korisnik k)
        {
            k.Obrisan = true;
            Update(k);
        }
        public static ObservableCollection<Korisnik> Sort(Prikaz p, NacinSortiranja nn)
        {
            var korisnik = new ObservableCollection<Korisnik>();
            switch (p)
            {
                case Prikaz.Ime:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by Ime";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by Ime desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                        break;
                case Prikaz.Prezime:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by Prezime";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by Prezime desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
                case Prikaz.KorisnickoIme:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by KorisnickoIme";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by KorisnickoIme desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
                case Prikaz.Lozinka:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by Lozinka";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by Lozinka desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
                case Prikaz.TipKorisnika:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by TipKorisnika";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 Order by TipKorisnika desc";
                        }


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
            }
            return korisnik;
        }
        public static ObservableCollection<Korisnik> Search(Prikaz p,String s)
        {
            var korisnik = new ObservableCollection<Korisnik>();
            switch (p)
            {
                case Prikaz.Ime:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 and Ime like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
                case Prikaz.Prezime:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 and Prezime like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
                case Prikaz.KorisnickoIme:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 and KorisnickoIme like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
                case Prikaz.Lozinka:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0 and Lozinka like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "Korisnik"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                        {
                            var k = new Korisnik();
                            k.Id = int.Parse(row["Id"].ToString());
                            k.Ime = row["Ime"].ToString();
                            k.Prezime = row["Prezime"].ToString();
                            k.KorisnickoIme = row["KorisnickoIme"].ToString();
                            k.Lozinka = row["Lozinka"].ToString();
                            k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                            bool b = bool.Parse(row["TipKorisnika"].ToString());
                            if (b == true)
                            {

                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;
                            }

                            korisnik.Add(k);

                        }
                    }
                    break;
               
            }
            return korisnik;
        }
        #endregion
    }
}
