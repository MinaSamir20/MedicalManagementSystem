using MedicalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalManagementSystem.Infrasturcture.Configs
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Doctors");

            builder.HasOne(d => d.Clinic)
                .WithOne(c => c.Doctor)
                .HasForeignKey<Clinic>(c => c.Id);

            builder.HasOne(d => d.Speciality)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialityId);

            builder.HasOne(d => d.Department)
                .WithMany(d => d.Doctors)
                .HasForeignKey(d => d.DepartmentId);

            builder.HasOne(d => d.Shift)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.ShiftId);

            builder.HasOne(d => d.Department)
                .WithMany(d => d.Doctors)
                .HasForeignKey(d => d.DepartmentId);

            builder.HasMany(d => d.AvilableAppointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(p => p.DoctorId);

            builder.HasMany(d => d.Prescriptions)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorId);

        }
    }
}
