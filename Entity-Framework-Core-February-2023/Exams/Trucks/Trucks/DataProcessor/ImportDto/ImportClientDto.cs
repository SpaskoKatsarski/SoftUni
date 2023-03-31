namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    public class ImportClientDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; } = null!;

        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; } = null!;

        [JsonProperty("Trucks")]
        public int[] TruckIds { get; set; } = null!;
    }
}
