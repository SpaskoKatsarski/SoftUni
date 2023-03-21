using ProductShop.DTOs.Import;
using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootElement)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootElement);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using (StringReader reader = new StringReader(inputXml))
            {
                T deserializedDtos = (T)xmlSerializer.Deserialize(reader);

                return deserializedDtos;
            }
        }
    }
}
