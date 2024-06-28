using System.ComponentModel.DataAnnotations.Schema;
namespace FlatManagerLog.Models
{
    public class Tenants
    {
        public int Id { get; set; }
        public string TenantName { get; set; }
        public string TenantPhone { get; set; }
        public string TenantResidence { get; set; }
        public string Tc { get; set; }
        public string RentPayed { get; set; } = "Not Payed"; // Ensure default value is set

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool IsRentPaidForCurrentMonth { get; set; }

        public ICollection<Payments> Payments { get; set; } = new List<Payments>();
    }
}
