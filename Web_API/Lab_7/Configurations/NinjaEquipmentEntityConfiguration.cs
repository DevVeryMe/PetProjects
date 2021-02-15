using Lab_7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab_7.Configurations
{
    public class NinjaEquipmentEntityConfiguration : IEntityTypeConfiguration<NinjaEquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<NinjaEquipmentEntity> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Title).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");

            builder.HasOne<NinjaEntity>(i => i.Owner)
                .WithMany(i => i.Items)
                .HasForeignKey(i => i.OwnerId);
        }
    }
}
