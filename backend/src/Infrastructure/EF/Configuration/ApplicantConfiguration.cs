using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configuration
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasOne(a => a.Company)
                .WithMany(c => c.Applicants)
                .HasForeignKey(a => a.CompanyId)
                .HasConstraintName("applicant_company_FK")
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Property(a => a.CompanyId)
            //    .HasColumnType("uniqueidentifier");
        }
    }
}