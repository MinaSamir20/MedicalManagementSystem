using MedicalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalManagementSystem.Infrasturcture.Configs
{
    internal class PrescriptionDetialConfig : IEntityTypeConfiguration<PrescriptionDetail>
    {
        public void Configure(EntityTypeBuilder<PrescriptionDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PrescriptionDetials");

            builder.HasOne(p => p.Prescription)
                .WithMany(p => p.PrescriptionDetails)
                .HasForeignKey(p => p.PrescriptionId);

            builder.HasOne(p => p.Medicine)
                .WithMany()
                .HasForeignKey(p => p.MedicineId);

        }
    }
}
