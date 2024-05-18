namespace MedicalManagementSystem.Application.DTOs
{
    public class BillDto
    {
        public DateTime? BillDate { get; set; }
        public float Amount { get; set; }
        public bool Status { get; set; }
    }
}
