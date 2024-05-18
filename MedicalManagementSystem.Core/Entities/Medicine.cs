#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class Medicine : BaseEntity
    {
        public string MedicalName { get; set; }
        public string GenericName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpiredOn { get; set; }
    }
}
