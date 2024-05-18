namespace MedicalManagementSystem.Core.SharedResources
{
    public static class SharedResourcesKeys
    {
        //
        public const string Required = "Required";
        public const string NotFound = "NotFound";
        public const string Deleted = "Deleted";
        public const string Added = "Added";
        public const string Updated = "Updated";
        public const string BadRequest = "BadRequest";
        public const string UnAuthorized = "UnAuthorized";
        public const string Success = "Success";
        public const string UnprocessableEntity = "UnprocessableEntity";

        //
        public const string NotEmpty = "NotEmpty";
        public const string NotNull = "NotNull";
        public const string MaxLength = "MaxLength";
        public const string IsExist = "IsExist";

        //Tables ==>

        // => Address
        public const string Streetname = "Streetname";
        public const string BuildingNumber = "BuildingNumber";
        public const string AreaName = "AreaName";
        // => Appointment
        public const string Approved = "Approved";
        public const string Progress = "Progress";
        // => Avilable Appointment
        public const string Date = "Date";
        public const string Time = "Time";
        public const string BillAmount = "BillAmount";
        // => Bill
        public const string BillDate = "BillDate";
        public const string Amount = "Amount";
        public const string Status = "Status";
        // => Category
        public const string CategoryName = "CategoryName";
        // => Clinic
        public const string ClinicName = "ClinicName";
        public const string FloorNumber = "FloorNumber";
        public const string WorkingStartTime = "WorkingStartTime";
        public const string WorkingEndTime = "WorkingEndTime";
        // => Department
        public const string DepartmentName = "DepartmentName";
        public const string DepartmentDescription = "DepartmentDescription";
        public const string NoOfDoctor = "NoOfDoctor";
        // => Doctor
        public const string ChargesPerVisit = "ChargesPerVisit";
        public const string ReputeIndex = "ReputeIndex";
        public const string Patients_Treated = "Patients_Treated";
        // => Staff
        public const string Designation = "Designation";
        public const string Qualification = "Qualification";
        public const string Tranning = "Tranning";
        public const string MonthSalary = "MonthSalary";
        public const string WorkExperience = "WorkExperience";
        // => Medicine
        public const string MedicineName = "MedicineName";
        public const string GenericName = "GenericName";
        public const string Price = "Price";
        public const string Quantity = "Quantity";
        public const string Manufacturer = "Manufacturer";
        public const string ProductionDate = "ProductionDate";
        public const string ExpiredOn = "ExpiredOn";
        // => Patient
        public const string InsuranceInfo = "InsuranceInfo";
        // => Prescription
        public const string DatePrescribed = "DatePrescribed";
        public const string AdditionalNotes = "AdditionalNotes";
        // => Prescription Details
        public const string Dosage = "Dosage";
        public const string Frequency = "Frequency";
        public const string Duration = "Duration";
        public const string DurationUnit = "DurationUnit";
        // => Room
        public const string RoomName = "RoomName";
        public const string RoomFloorNumber = "RoomFloorNumber";
        public const string NumberOfAllBeds = "NumberOfAllBeds";
        public const string NumberOfTakenBeds = "NumberOfTakenBeds";
        // => Shift
        public const string ShiftDate = "ShiftDate";
        public const string ShiftStart = "ShiftStart";
        public const string ShiftEnd = "ShiftEnd";
        // => Speciality
        public const string SpecialityName = "SpecialityName";
        // => Treatment
        public const string TreatmentName = "TreatmentName";
        public const string TreatmentDescription = "TreatmentDescription";
        // => User
        public const string UserName = "UserName";



    }
}
