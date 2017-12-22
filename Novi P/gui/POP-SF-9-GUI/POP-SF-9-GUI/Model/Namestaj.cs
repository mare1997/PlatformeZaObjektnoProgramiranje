﻿
using POP_SF_9_GUI.Model;
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
using System.Windows;
using System.Xml.Serialization;

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class Namestaj: INotifyPropertyChanged

    {
        private int id;
        public int Id
        {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged("Id");
            }

        }
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }
        private int cena;
        public int Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }
        private int kolicina;
        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value;  OnPropertyChanged("Kolicina"); }
        }
        private int kolicinapp;
        public int KolicinaPriProdaji
        {
            get { return kolicinapp; }
            set { kolicinapp = value; OnPropertyChanged("KolicinaPriProdaji"); }
        }
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        private TipNamestaja tipNamestaja;
        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {   if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(tipN);

                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                tipN = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }
        private int tipN;
        public int TipN
        {
            get { return tipN; }
            set { tipN = value; OnPropertyChanged("TipN"); }
        }

        private int a;
        public int ak
        {
            get { return a; }
            set { a = value; OnPropertyChanged("ak"); }
        }
        private AkcijskaProdaja akcija;
        [XmlIgnore]
        public AkcijskaProdaja Akcija
        {
            get
            {
                if (akcija == null)
                {
                    akcija = AkcijskaProdaja.GetById(ak);

                }
                return akcija;
            }
            set
            {
                akcija = value;
                a = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }

        public override string ToString()
        {


            return $"Naziv: {Naziv},{Cena},{TipNamestaja.GetById(TipN).Naziv}";
        }
        public static Namestaj GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instance.namestaj)
            {
                if (Namestaja.Id == id)
                {
                    return Namestaja;
                }

            }
            return null;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        //bilo gde ako koristis bazu koristi try catch
        #region Database
        public static ObservableCollection<Namestaj> GetAll()
        {
            var Namestaj = new ObservableCollection<Namestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var tn = new Namestaj();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    tn.Cena = int.Parse(row["Cena"].ToString());
                    tn.Kolicina = int.Parse(row["Kolicina"].ToString());
                    tn.Akcija = AkcijskaProdaja.GetById(int.Parse(row["Akcija"].ToString()));
                    tn.TipNamestaja =TipNamestaja.GetById(int.Parse(row["TipNamestajaId"].ToString()));
                    Namestaj.Add(tn);

                }
                return Namestaj;
            }
        }
        public static Namestaj Create(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into Namestaj (Naziv,Obrisan,Cena,Kolicina,Akcija,TipNamestajaId) Values(@Naziv,@Obrisan,@Cena,@Kolicina,@akcija,@tipnamestaja);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                n.Id = newId;


            }
            Projekat.Instance.namestaj.Add(n);//obrati paznju {azurira i stanje modela}
            return n;
        }
        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update Namestaj set Naziv=@Naziv,Obrisan=@Obrisan,Cena=@Cena,Kolicina=@Kolicina,Akcija=@Akcija,TipNamestaja=@TipNamestaja where id=@id";
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.Parameters.AddWithValue("Cena", n.Cena);
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);
                cmd.Parameters.AddWithValue("Akcija", n.akcija);
                cmd.Parameters.AddWithValue("TipNamestaja", n.tipN);
                cmd.ExecuteNonQuery();

                foreach (var Namestaj in Projekat.Instance.namestaj)
                {
                    if (Namestaj.Id == n.Id)
                    {
                        Namestaj.Naziv = n.Naziv;
                        Namestaj.Obrisan = n.Obrisan;
                        break;
                    }
                }
            }


        }
        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
    
}
