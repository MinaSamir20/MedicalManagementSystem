namespace MedicalManagementSystem.Application.DTOs
{
    public class AppointmentDto
    {
        public bool Approved { get; set; }
        public bool BillStatus { get; set; }
        public float BillAmount { get; set; }
        public string? Progress { get; set; }
    }
}
