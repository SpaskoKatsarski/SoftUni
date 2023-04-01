namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
		[XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Required]
        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}
