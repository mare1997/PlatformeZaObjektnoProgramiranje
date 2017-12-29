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
    public class Racun : INotifyPropertyChanged
    {
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
        private DateTime datumProdaje;
        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set { datumProdaje = value; OnPropertyChanged("DatumProdaje"); }
        }

        private string kupac;
        public string Kupac
        {
            get { return kupac; }
            set { kupac = value; OnPropertyChanged("Kupac"); }
        }

        private List<StavkaProdajeDU> du;
        public List<StavkaProdajeDU> DodatnaUsluga { get; set; }
      
        //private Dictionary<int, int> namestaj;
        private List<StavkaProdajeNamestaj> namestaj;
        public List<StavkaProdajeNamestaj> Namestaj { get; set; }
       
        public const double PDV = 0.02 ;
        private double ukupnaCena;
        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set { ukupnaCena = value; OnPropertyChanged("UkupnaCena"); }
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
        public static ObservableCollection<Racun> GetAll()
        {
            var racun = new ObservableCollection<Racun>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Racun WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Racun"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Racun"].Rows)
                {
                    var r = new Racun();
                    r.Id = int.Parse(row["Id"].ToString());
                    r.datumProdaje = DateTime.Parse(row["Dp"].ToString());
                    r.Kupac = row["Kupac"].ToString();
                    r.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                    foreach (var n in Projekat.Instance.spn)
                    {
                        if (n.RacunId == r.Id)
                        {
                            r.Namestaj.Add(n);
                        }
                    }
                    foreach (var n in Projekat.Instance.spdu)
                    {
                        if (n.RacunId == r.Id)
                        {
                            r.DodatnaUsluga.Add(n);
                        }
                    }
                    
                    racun.Add(r);

                }
                return racun;
            }
        }
        public static Racun Create(Racun r)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into Racun (Dp,Kupac,UkupnaCena) Values(@Dp,@Kupac,@UkupnaCena);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("Dp",r.DatumProdaje);
                cmd.Parameters.AddWithValue("Kupac",r.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCena", r.UkupnaCena);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                r.Id = newId;


            }
            Projekat.Instance.pn.Add(r);//obrati paznju {azurira i stanje modela}
            return r;
        }
        public static void Update(Racun r)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update Racun set Dp=@Dp,Kupac=@Kupac,UkupnaCena=@UkupnaCena";
                cmd.Parameters.AddWithValue("Id", r.Id);
                cmd.Parameters.AddWithValue("Dp", r.DatumProdaje);
                cmd.Parameters.AddWithValue("Kupac", r.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCena", r.UkupnaCena);

                cmd.ExecuteNonQuery();

                foreach (var racun in Projekat.Instance.pn)
                {
                    if (racun.Id == r.Id)
                    {
                        racun.DatumProdaje = r.DatumProdaje;
                        racun.Kupac = r.Kupac;
                        racun.UkupnaCena = r.UkupnaCena;
                        break;
                    }
                }
            }


        }
        
        #endregion
    }
}
