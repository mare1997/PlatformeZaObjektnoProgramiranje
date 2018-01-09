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
        public enum Prikaz
        {
            Naziv,
            Cena,
            
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
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }
        private double cena;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Cena
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
        public object Clone()
        {
            return new DodatnaUsluga()
            {
                id = Id,
                naziv = Naziv,
                cena = Cena,
                obrisan = Obrisan,
               
            };
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
                    d.Cena = double.Parse(row["Cena"].ToString());
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
                cmd.CommandText = "Update DodatnaUsluga set Naziv=@Naziv,Obrisan=@Obrisan,Cena=@Cena where Id=@Id";
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
        public static ObservableCollection<DodatnaUsluga> Sort(Prikaz p, NacinSortiranja nn)
        {
            var du = new ObservableCollection<DodatnaUsluga>();
            switch (p)
            {
                case Prikaz.Naziv:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0 Order by Naziv"; 
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0 Order by Naziv desc";
                        }
                        

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
                            d.Cena = double.Parse(row["Cena"].ToString());
                            du.Add(d);

                        }
                       
                    }
                    break;
                case Prikaz.Cena:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        if (nn == NacinSortiranja.asc)
                        {
                            cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0 Order by Cena";
                        }
                        else
                        {
                            cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0 Order by Cena desc";
                        }


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
                            d.Cena = double.Parse(row["Cena"].ToString());
                            du.Add(d);

                        }

                    }
                    break;
            }
            return du;
        }
        public static ObservableCollection<DodatnaUsluga> Search(Prikaz p, String s)
        {
            var du = new ObservableCollection<DodatnaUsluga>();
            switch (p)
            {
                case Prikaz.Naziv:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0 and Naziv like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


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
                            d.Cena = double.Parse(row["Cena"].ToString());
                            du.Add(d);

                        }

                    }
                    break;
                case Prikaz.Cena:
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0 and Cena like '%'+@s+'%'";
                        cmd.Parameters.AddWithValue("s", s);


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
                            d.Cena = double.Parse(row["Cena"].ToString());
                            du.Add(d);

                        }

                    }
                    break;
            }
            return du;
        }

        #endregion
    }
}
