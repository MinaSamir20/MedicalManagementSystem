#nullable disable
namespace MedicalManagementSystem.Domain.Entities
{
    public class PrescriptionDetail
    {
        public int Id { get; set; }
        public string Dosage { get; set; }
        public int Frequency { get; set; }
        public int Duration { get; set; }
        public string DurationUnit { get; set; }

        /*-------- Relations --------*/

        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
