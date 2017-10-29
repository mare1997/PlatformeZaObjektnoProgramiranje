using POP_9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_9
{   
    class Program
    {
        public static List<Namestaj> Namestaj1 { get; set; } = new List<Namestaj>();
        public static List<TipNamestaja> TN { get; set; } = new List<TipNamestaja>();
        public static List<Akcija> akcija { get; set; } = new List<Akcija>();
        static void Main(string[] args)
        {
            Salon s1 = new Salon()
            {
                Id = 1,
                Naziv = "FormaIdeale",
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "564864221-451-15415656",
                Email = "form@gmail.com",
                PIB = 3414135,
                MaticniBroj = 1234,
                Telefon = "021-528-951",
                Websajt = "http://www.ftn.uns.ac.rs"


            };
            akcija.Add(new Akcija
            {
                Id = idzaA(),
                popust = 40 ,



            });
            TN.Add( new TipNamestaja()
            {
                Id = 1,
                Naziv = "Sofa"
            });
            Namestaj1.Add(new Namestaj()
            { Id = 1,
                Naziv = "Crna kozna",
                JedinicnaCena = 2314,
                KolicinivaUMagacinu = 16,
                TipNamestaja = TN[0],

            });
            Console.WriteLine($"Dobrodosli u salon namestaja {s1.Naziv}.");
            IspisiGlavniMeni();
            Console.ReadLine();
         }
        private static void IspisiGlavniMeni()
        {   int izbor =0;
            do
            {
                Console.WriteLine("-------Glavni Meni--------");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("3. Rad sa prodajom namestaja");
                Console.WriteLine("4. Rad sa akcijama");

                
                Console.WriteLine("0. izlaz iz app");
                
                
            } while(izbor < 0 || izbor >2);

            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:

                    IspisiMeniTipNamestaja();
                    break;
                case 3:
                    IspisiProdajaNamestaja();
                    break;
                case 4:
                    IspisiAkcije();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:

                    break;

            }
        }

        private static void IspisiAkcije()
        {
            throw new NotImplementedException();
        }

        private static void IspisiProdajaNamestaja()
        {
            throw new NotImplementedException();
        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;
            do {
                Console.WriteLine("-------Namestaj-------");
                Console.WriteLine("1. Listing namestaja");
                Console.WriteLine("2.Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci");
                Console.WriteLine("4.obrisi postojeci");
                Console.WriteLine("0. Izadji");

            } while (izbor <0 || izbor >4);

            izbor = int.Parse(Console.ReadLine());
            switch (izbor)
            {
                case 1:IzlistajTipNamestaja();
                    break;
                case 2:
                    DodajNamestaj();
                    break;
                case 3:
                    IzmeniTipNamestaja();
                    break;
                case 4:
                    ObrisiNamestaj();
                    break;
                case 0:
                    IspisiGlavniMeni();
                    break;
                default:
                    break;

            }
        }

        private static void ObrisiNamestaj()
        {

            Console.WriteLine("Unesite id namestaja kog zelite da izbrisete:");
            int id = int.Parse(Console.ReadLine());
            nadjiNamestajpoID(id).Obrisan = true;
            IspisiMeniNamestaja();
        }
        private static void ObrisiTipNamestaja()
        {

            Console.WriteLine("Unesite id tip namestaja kog zelite da izbrisete:");
            int id = int.Parse(Console.ReadLine());
            nadjiTNpoID(id).Obrisan = true;
            IspisiMeniTipNamestaja();

        }
        private static void IzmeniTipNamestaja()
        {
            Console.WriteLine("Unesite id namestaja kog zelite da izmenite:");
            int id = int.Parse(Console.ReadLine());
            Namestaj n = nadjiNamestajpoID(id);
            IspisiMeniTipNamestaja();
        }

        private static void DodajNamestaj()
        {
            int id = 0;
            int od;
            
            
            Console.WriteLine("Naziv:");
            String naziv=Console.ReadLine();
            Console.WriteLine("Cena:");
            String cena =Console.ReadLine();
            Console.WriteLine("Kolicina u magacinu:");
            String koliUmagacinu = Console.ReadLine();
            Console.WriteLine("Unesite id Tip namestaja:");
            String odg = Console.ReadLine();
            TipNamestaja tn = nadjiTNpoID(int.Parse(odg));
            if (tn != null)
            {
                
                Console.WriteLine("Da li namestaj ima akciju (y/n):");
                String odgovor = Console.ReadLine();

                if (odgovor == "y" || odgovor == "Y")
                {
                    Console.WriteLine("Unesite id akcije:");
                    Akcija a = nadjiAkcijupoID(int.Parse(Console.ReadLine()));
                    Namestaj1.Add(new Namestaj()
                    {
                        Id = idzaN(),
                        Naziv = naziv,
                        JedinicnaCena = double.Parse(cena),
                        KolicinivaUMagacinu = int.Parse(koliUmagacinu),
                        TipNamestaja = tn,
                        Akcija = a,

                    });
                    IspisiGlavniMeni();

                }
                else if (odgovor == "n" || odgovor == "N")
                {
                    Namestaj1.Add(new Namestaj()
                    {
                        Id = idzaN(),
                        Naziv = naziv,
                        JedinicnaCena = double.Parse(cena),
                        KolicinivaUMagacinu = int.Parse(koliUmagacinu),
                        TipNamestaja = tn,
                        Akcija = null,

                    });
                    IspisiGlavniMeni();
                }
                else
                {
                    Console.WriteLine("Uneli ste pogresnu vrednost");
                    DodajNamestaj();
                }
                
            }
            
            else
            {
                Console.WriteLine("Uneli ste pogresnu vrednost");
                DodajNamestaj();
           }
            
            


        }

        private static Akcija nadjiAkcijupoID(int id)
        {
            foreach (var n in akcija)
            {
                if (n.Id == id)
                    return n;
            }
            return null;

        }

        private static void IspisiMeniTipNamestaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("-------Tip Namestaja-------");
                Console.WriteLine("1. Listing tipa namestaja");
                Console.WriteLine("2.Dodaj novi tip namestaj");
                Console.WriteLine("3. Izmeni postojeci");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Izadji");

            } while (izbor < 0 || izbor > 4);

            izbor = int.Parse(Console.ReadLine());
            switch (izbor)
            {
                case 1:
                    IzlistajTNamestaja();
                    break;
                case 2:
                    DodajTipNamestaja();
                    break;
                case 3:
                    IzmeniTipNamestaja();
                    break;
                case 4:
                    ObrisiTipNamestaja();
                    break;
                case 0:
                    IspisiGlavniMeni();
                    break;
                default:
                    break;

            }
        }

        private static void DodajTipNamestaja()
        {
            Console.WriteLine("UNesite naziv za tip namestaja:");
            String naziv=Console.ReadLine();
            TN.Add(new TipNamestaja
            {
                Id=idzaTN(),
                Naziv=naziv,
            });
            IspisiMeniTipNamestaja();



        }

        private static void IzlistajTipNamestaja()
        {
        int index = 0;
        Console.WriteLine("------------Listing namestaja--------------");
        foreach (var namestaj in Namestaj1)
            {
                if(namestaj.Obrisan != true)
                    Console.WriteLine($"{ ++index}.{namestaj.Naziv}, cena: {namestaj.JedinicnaCena}, tip namestaja: {namestaj.TipNamestaja.Naziv}, kolicina u magacinu: {namestaj.KolicinivaUMagacinu}, akcija: {namestaj.Akcija} \n\n");

            }
            IspisiMeniNamestaja();
        }
        private static void IzlistajTNamestaja()
        {
            int index = 0;
            Console.WriteLine("------------Listing namestaja--------------");
            foreach (var namestaj in TN)
            {
                if (namestaj.Obrisan != true)
                    Console.WriteLine($"{ ++index}.{namestaj.Naziv},\n\n");
            }
            IspisiMeniTipNamestaja();
        }
        private static TipNamestaja nadjiTNpoID(int id)
        {   foreach (var tn in TN)
            {
                if (tn.Id == id)
                    return tn;
            }
            return null;  
        }
        private static Namestaj nadjiNamestajpoID(int id)
        {
            foreach (var n in Namestaj1)
            {
                if (n.Id == id)
                    return n;
            }
            return null;
        }
        private static int idzaN()
        {
            int j=0;
            foreach(var namestaj in Namestaj1)
            { if (j <= namestaj.Id)
                    j = namestaj.Id;

            }
            return j + 1;
        }
        private static int idzaTN()
        {
            int j = 0;
            foreach (var tnamestaj in TN)
            {
                if (j <= tnamestaj.Id)
                    j = tnamestaj.Id;

            }
            return j + 1;
        }
        private static int idzaA()
        {
            int j = 0;
            foreach (var a in akcija)
            {
                if (j <= a.Id)
                    j = a.Id;

            }
            return j + 1;
        }
    }
}
