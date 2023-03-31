namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [MaxLength(40)]
        public string Nationality { get; set; } = null!;

        public string Type { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
