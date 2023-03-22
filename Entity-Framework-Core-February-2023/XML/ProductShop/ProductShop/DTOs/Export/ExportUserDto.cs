namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlElement("firstName")]
        public string? FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [XmlElement("soldProducts")]
        public ICollection<ExportSoldProductDto> SoldProducts { get; set; } = null!;
    }
}
