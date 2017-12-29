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
    public class DodatnaUsluga : INotifyPropertyChanged
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
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }
        private int cena;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }

        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        public static DodatnaUsluga GetById(int id)
        {
            foreach (var du in Projekat.Instance.DU)
            {
                if (du.Id == id)
                {
                    return du;
                }

            }
            return null;

        }
        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        #region Database
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var du = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var d = new DodatnaUsluga();
                    d.Id = int.Parse(row["Id"].ToString());
                    d.Naziv = row["Naziv"].ToString();
                    d.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    d.Cena = int.Parse(row["Cena"].ToString());
                    du.Add(d);

                }
                return du;
            }
        }
        public static DodatnaUsluga Create(DodatnaUsluga d)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Insert into DodatnaUsluga (Naziv,Obrisan,Cena) Values(@Naziv,@Obrisan,@Cena);";//razmisli o ne unosenju obrisan pri dodavanju vec to u bazi 
                cmd.CommandText += "Select scope_identity();";
                cmd.Parameters.AddWithValue("Naziv", d.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", d.Obrisan);
                cmd.Parameters.AddWithValue("Cena", d.Cena);
                int newId = int.Parse(cmd.ExecuteScalar().ToString()); //es izvrsava query
                d.Id = newId;


            }
            Projekat.Instance.DU.Add(d);//obrati paznju {azurira i stanje modela}
            return d;
        }
        public static void Update(DodatnaUsluga d)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update DodatnaUsluga set Naziv=@Naziv,Obrisan=@Obrisan,Cena=@Cena where id=@id";
                cmd.Parameters.AddWithValue("Id", d.Id);
                cmd.Parameters.AddWithValue("Naziv", d.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", d.Obrisan);
                cmd.Parameters.AddWithValue("Cena", d.Cena);

                cmd.ExecuteNonQuery();

                foreach (var du in Projekat.Instance.DU)
                {
                    if (du.Id == d.Id)
                    {
                        du.Naziv = d.Naziv;
                        du.Obrisan = d.Obrisan;
                        du.Cena = d.Cena;
                        break;
                    }
                }
            }


        }
        public static void Delete(DodatnaUsluga d)
        {
            d.Obrisan = true;
            Update(d);
        }
        #endregion
    }
}
