namespace FlatManagerLog.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public Tenants Tenant { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
    }
}
