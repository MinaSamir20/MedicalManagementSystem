using AutoMapper;
using MedicalManagementSystem.Application.DTOs;
using MedicalManagementSystem.Application.DTOs.Authentication;
using MedicalManagementSystem.Application.Features.Doctors.Models;
using MedicalManagementSystem.Application.Features.Doctors.Responses;
using MedicalManagementSystem.Application.Features.Patients.Models;
using MedicalManagementSystem.Application.Features.Patients.Responses;
using MedicalManagementSystem.Application.Features.Specialities.Models;
using MedicalManagementSystem.Application.Features.Specialities.Responces;
using MedicalManagementSystem.Domain.Entities;
using MedicalManagementSystem.Domain.Entities.Identity;

namespace MedicalManagementSystem.Application.Profiles
{
    public partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Doctor
            CreateMap<Doctor, CreateDoctor>().ReverseMap();
            CreateMap<UpdateDoctor, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Doctor, DeleteDoctor>().ReverseMap();
            CreateMap<Doctor, GetDoctorResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameEn, src.NameAr)));

            //Patient
            CreateMap<Patient, CreatePatient>().ReverseMap();
            CreateMap<UpdatePatient, Patient>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Patient, DeletePatient>().ReverseMap();
            CreateMap<Patient, GetPatientResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameEn, src.NameAr)));

            //Speciality
            CreateMap<Speciality, CreateSpeciality>()
                .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.SNameEn))
                .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.SNameAr))
                .ReverseMap();
            CreateMap<UpdateSpeciality, Speciality>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Speciality, DeleteSpeciality>().ReverseMap();
            CreateMap<Speciality, GetSpecialityResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.SNameEn, src.SNameAr)))
                .ReverseMap();
            CreateMap<Speciality, SpecialityDto>().ReverseMap();

            //Treatment
            CreateMap<Treatment, TreatmentDto>().ReverseMap();

            //User
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
