namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; } = null!;

        [XmlArray()]
        public ImportTruckDto[] Trucks { get; set; } = null!;
    }
}
