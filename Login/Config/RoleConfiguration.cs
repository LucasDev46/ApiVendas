using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Loja.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<long>> 
    {
        public void Configure(EntityTypeBuilder<IdentityRole<long>> builder)
        {
            builder.HasData(

                new IdentityRole<long>
                {
                    Id = 1,
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole<long>
                {
                    Id = 2,
                    Name = "Client",
                    NormalizedName = "CLIENT"
                }
                );
        }
    }
}
