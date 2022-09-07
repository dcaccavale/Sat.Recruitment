using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Model.Entities;

namespace Sat.Recruitment.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.IdGuid).IsRequired().HasDefaultValueSql("NEWID()");
            entityBuilder.Property(u => u.Name).IsRequired();
            entityBuilder.Property(u => u.Email).IsRequired();
            entityBuilder.Property(u => u.Address).IsRequired();
            entityBuilder.Property(u => u.Phone).IsRequired();
            entityBuilder.Property(c => c.Money)
            .HasPrecision(18, 4);
        }
    }
}
