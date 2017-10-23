using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_9
{
    public class Person
    {
        private string name = "";
        private string surname = "";


        public string Name { get; set; }
        public string SurName { get; set; }
        public Person(string name, string surname)
        {
            Name = name;
            SurName = surname;
        }
       

    }
}
