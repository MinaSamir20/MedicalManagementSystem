#nullable disable
using MedicalManagementSystem;

namespace MedicalManagementSystem.Application.Features.Patients.Responses
{
    public class GetPatientPaginatedResponse(int id, string name, string insuranceInfo, string address, string roomName)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string InsuranceInfo { get; set; } = insuranceInfo;
        public string Address { get; set; } = address;
        public string RoomName { get; set; } = roomName;
    }
}
