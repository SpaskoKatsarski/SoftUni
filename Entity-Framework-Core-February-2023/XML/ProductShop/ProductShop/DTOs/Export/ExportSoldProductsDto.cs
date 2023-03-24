namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportSoldProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ICollection<ExportSoldProduct2> Products { get; set; } = null!;
    }
}
