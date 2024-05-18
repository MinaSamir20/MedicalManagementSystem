using MedicalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalManagementSystem.Infrasturcture.Configs
{
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Prescriptions");

            builder.HasMany(p => p.PrescriptionDetails)
                .WithOne(p => p.Prescription)
                .HasForeignKey(p => p.PrescriptionId);

            builder.HasOne(a => a.Appointment)
                .WithOne(p => p.Prescription)
                .HasForeignKey<Appointment>(p => p.Id);

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(a => a.PatientId);

            builder.HasOne(a => a.Doctor)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(a => a.DoctorId);
        }
    }
}
