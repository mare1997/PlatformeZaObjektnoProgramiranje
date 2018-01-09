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

namespace POP_SF_9_GUI.Model
{
    [Serializable]
    public class TipNamestaja: INotifyPropertyChanged
    {
        public enum Prikaz
        {
            Naziv,
            
        };
        public enum NacinSortiranja
        {
            asc,
            desc,
        };
        private int id;
        public int Id
        { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }
        public object Clone()
        {
            return new TipNamestaja()
            {
                id = Id,
                naziv = Naziv,
                obrisan = Obrisan,
                
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Projekat.Instance.TN)
            {
                if (tipNamestaja.Id == id)
                {
                    return tipNamestaja;
                }

            }
            return null;

        }
        public override string ToString()
        {
            return Naziv;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        #region Database
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "TipNamestaja"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    tipoviNamestaja.Add(tn);

                }
                return tipoviNamestaja;
            }
        }
        public static TipNamestaja Create(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into TipNamestaja (Naziv,Obrisan) Values(@Naziv,@Obrisan);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                tn.Id = newId;
                

            }
            Projekat.Instance.TN.Add(tn);//obrati paznju {azurira i stanje modela}
            return tn;
        }
        public static void Update(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update TipNamestaja set Naziv=@Naziv,Obrisan=@Obrisan where Id=@Id";
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var tipNamestaj in Projekat.Instance.TN)
                {
                    if (tipNamestaj.Id == tn.Id)
                    {
                        tipNamestaj.Naziv = tn.Naziv;
                        tipNamestaj.Obrisan = tn.Obrisan;
                        break;
                    }
                }
            }

            
        }
        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }
        public static ObservableCollection<TipNamestaja> Sort(Prikaz p, NacinSortiranja nn)
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
            switch (p)
            {
                case Prikaz.Naziv:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {

                            cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0 Order by Naziv ";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0 Order by Naziv desc";
                        }

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "TipNamestaja"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                        {
                            var tn = new TipNamestaja();
                            tn.Id = int.Parse(row["Id"].ToString());
                            tn.Naziv = row["Naziv"].ToString();
                            tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                            tipoviNamestaja.Add(tn);

                        }
                        

                    }
                    break;
            }
            return tipoviNamestaja;
            }
        public static ObservableCollection<TipNamestaja> Search(Prikaz p, String s)
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
            switch (p)
            {
                case Prikaz.Naziv:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0 and Naziv like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = cmd;
                        da.Fill(ds, "TipNamestaja"); // Query se izvrsava
                        foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                        {
                            var tn = new TipNamestaja();
                            tn.Id = int.Parse(row["Id"].ToString());
                            tn.Naziv = row["Naziv"].ToString();
                            tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                            tipoviNamestaja.Add(tn);

                        }


                    }
                    break;
            }
            return tipoviNamestaja;
        }
        #endregion
    }
}
