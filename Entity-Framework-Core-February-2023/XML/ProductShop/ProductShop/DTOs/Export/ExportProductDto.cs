namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductDto
    {
        //    <name>TRAMADOL HYDROCHLORIDE</name>
        //<price>516.48</price>

        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string? Buyer { get; set; }
    }
}
