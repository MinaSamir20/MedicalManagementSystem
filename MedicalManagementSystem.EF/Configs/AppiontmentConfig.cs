using MedicalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalManagementSystem.Infrasturcture.Configs
{
    internal class AppiontmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Appointments");

            builder.HasOne(a => a.Bill)
                .WithOne(b => b.Appointment)
                .HasForeignKey<Bill>(b => b.AppointmentId);

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            builder.HasOne(a => a.AvilableAppointment)
                .WithOne(a => a.Appointment)
                .HasForeignKey<AvilableAppointment>(a => a.AppointmentId);

            builder.HasOne(a => a.Prescription)
                .WithOne(a => a.Appointment)
                .HasForeignKey<Prescription>(a => a.AppointmentId);
        }
    }
}
