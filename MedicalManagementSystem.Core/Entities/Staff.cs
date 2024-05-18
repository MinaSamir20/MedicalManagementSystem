namespace MedicalManagementSystem.Domain.Entities
{
    public class Staff : UserEntity
    {

        public string? Designation { get; set; }
        public string? Qualification { get; set; }
        public bool Tranning { get; set; } = true;
        public float MonthSalary { get; set; }
        public int WorkExperience { get; set; } = 0;

        /*-------- Relations --------*/
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int ShiftId { get; set; }
        public Shift? Shift { get; set; }
    }
}