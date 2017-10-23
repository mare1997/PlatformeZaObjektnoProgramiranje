using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_9.Tests
{
    class Test1
    {
        public Test1()
        {
            Person p1 = new Person("John", "Doe");
            p1.Name = "new name JOhn";
            Console.WriteLine("Hello my name is:" + p1.Name);
            Console.ReadLine();
            List<string> i = new List<string>();
            List<string> p = new List<string>();
            List<Person> osoba = new List<Person>();
            i.Add("Marko");
            i.Add("Nikola");
            i.Add("Stefan");
            i.Add("Milos");
            i.Add("Boris");
            p.Add("Markovic");
            p.Add("Nikolic");
            p.Add("Milosevic");
            p.Add("Borisov");
            p.Add("Stefanovic");
            for (int k = 0; k < ; k++)
            {
                osoba[k].Name = i[k];
                osoba[k].SurName = i[k];

            }
        }
    }
}
