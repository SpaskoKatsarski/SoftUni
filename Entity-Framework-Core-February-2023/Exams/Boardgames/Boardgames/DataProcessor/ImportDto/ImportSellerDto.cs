namespace Boardgames.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportSellerDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [JsonProperty("Address")]
        public string Address { get; set; } = null!;

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(@"^www\.[A-Za-z0-9\-]+\.com$")]
        [JsonProperty("Website")]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public int[] BoardgameIds { get; set; } = null!;
    }
}
