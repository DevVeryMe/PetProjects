using Lab_7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab_7.Configurations
{
    public class NinjaEntityConfiguration : IEntityTypeConfiguration<NinjaEntity>
    {
        public void Configure(EntityTypeBuilder<NinjaEntity> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Rank).IsRequired().HasMaxLength(100);
        }
    }
}
