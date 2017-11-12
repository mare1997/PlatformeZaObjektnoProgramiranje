using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_9.Util
{
    class GenericSeriallzer
    {
        public static void Serialize<T>(string filename, List<T> objToSerialize) where T: class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sw = new System.IO.StreamWriter($@"../../Data/{ filename }"))
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
                using (var sw = new System.IO.StreamReader($@"../../Data/{ filename }"))
                {
                    return (List<T>) serializer.Deserialize(sw);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
