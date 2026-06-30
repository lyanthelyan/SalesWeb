using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesWeb.Domain.Entities.Seller;

namespace SalesWeb.Infrastructure.Persistence.Configurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.HasKey(seller => seller.Id);


        builder.Property(seller => seller.Name)
            .IsRequired()
            .HasMaxLength(100);


        builder.Property(seller => seller.Email)
            .IsRequired()
            .HasMaxLength(150);


        builder.Property(seller => seller.BaseSalary)
            .HasColumnType("decimal(10,2)");


        builder.HasOne(seller => seller.Department)
            .WithMany(department => department.Sellers)
            .HasForeignKey(seller => seller.DepartmentId);
            
    }
}
