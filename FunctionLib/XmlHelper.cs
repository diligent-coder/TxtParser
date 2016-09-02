using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace FunctionLib
{
    class XmlHelper
    {
        public static T XmlToObject<T>(string xmlPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader=new StreamReader(xmlPath))
            {
                T resultingMessage = (T)serializer.Deserialize(reader);

                return resultingMessage;
            }

        }
       
    }
}
