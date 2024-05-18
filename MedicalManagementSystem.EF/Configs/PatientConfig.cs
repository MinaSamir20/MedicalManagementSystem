using MedicalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalManagementSystem.Infrasturcture.Configs
{
    public class PatientConfig
    : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient>
            builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Patients");

            builder.OwnsOne(x => x.Address);

            builder.HasOne(p => p.Room)
                .WithMany(r => r.Patients)
                .HasForeignKey(r => r.RoomId);

            builder.HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            builder.HasMany(p => p.Bills)
                .WithOne(b => b.Patient)
                .HasForeignKey(a => a.PatientId);

            builder.HasMany(p => p.Treatments)
                .WithOne(t => t.Patient)
                .HasForeignKey(t => t.PatientId);

        }
    }
}
