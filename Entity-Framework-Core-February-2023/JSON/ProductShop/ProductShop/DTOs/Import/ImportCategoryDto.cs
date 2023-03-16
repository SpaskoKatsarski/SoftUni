namespace ProductShop.DTOs.Import
{
    using System.Text.Json.Serialization;

    public class ImportCategoryDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
    }
}
