namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    using Models;

    [XmlType("User")]
    public class ExportUserWithProductsDto
    {
        [XmlElement("firstName")]
        public string? FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportSoldProductsDto SoldProducts { get; set; } = null!;
    }
}
