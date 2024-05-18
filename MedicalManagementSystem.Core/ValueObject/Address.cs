namespace MedicalManagementSystem.Domain.ValueObject
{
    public class Address
    {
        public string Streetname { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public Address() { }
    }
}
