using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product.Infrastructure.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Domain.Entity.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Product> builder)
        {
            builder.ToTable($"t_{nameof(Product.Domain.Entity.Product).ToLower()}");
            builder.HasQueryFilter(p => !p.Deleted);
            builder.HasMany(x => x.Variants).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            

        }
    }
}
