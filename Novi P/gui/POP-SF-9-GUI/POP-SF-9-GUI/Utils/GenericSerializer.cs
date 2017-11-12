using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_9_GUI.Model
{
    class GenericSerializer
    {
        public static void Serialize<T>(string filename, List<T> objToSerialize) where T : class
        {
            try
            {
                var serializer =new XmlSerializer(typeof(List<T>));
                using (var sw= new StreamWriter($@"../../Data/{filename}"))
                {
                    serializer.Serialize(sw, objToSerialize);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<T> Deserialize<T>(string filename) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sw = new StreamReader($@"../../Data/{filename}"))
                {
                   return (List<T>)serializer.Deserialize(sw);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
