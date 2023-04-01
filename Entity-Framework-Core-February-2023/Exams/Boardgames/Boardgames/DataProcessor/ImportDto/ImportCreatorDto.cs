namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Creator")]
    public class ImportCreatorDto
    {
		[Required]
		[MinLength(2)]
        [MaxLength(7)]
		[XmlElement("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        [XmlElement("LastName")]
        public string LastName { get; set; } = null!;

		[XmlArray("Boardgames")]
		public ImportBoardgameDto[] Boardgames { get; set; } = null!;
	}
}
