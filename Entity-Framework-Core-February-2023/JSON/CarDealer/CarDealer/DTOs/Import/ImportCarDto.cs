﻿namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportCarDto
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        [JsonProperty("traveledDistance")]
        public long TraveledDistance { get; set; }

        public int[] PartsId { get; set; }
    }
}
