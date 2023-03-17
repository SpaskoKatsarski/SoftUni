﻿namespace CarDealer.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class PartCar
    {
        [ForeignKey(nameof(Part))]
        public int PartId { get; set; }

        public virtual Part Part { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public virtual Car Car { get; set; } = null!; 
    }
}
