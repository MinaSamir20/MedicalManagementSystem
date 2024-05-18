using MedicalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalManagementSystem.Infrasturcture.Configs
{
    public class MedicalStaffConfig : IEntityTypeConfiguration<MedicalStaff>
    {
        public void Configure(EntityTypeBuilder<MedicalStaff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("MedicalStaffs");

            builder.HasOne(m => m.Department)
                .WithMany(d => d.Staffs)
                .HasForeignKey(m => m.DepartmentId);

            builder.HasOne(m => m.Shift)
                .WithMany(s => s.Staffs)
                .HasForeignKey(m => m.ShiftId);
        }
    }
}
