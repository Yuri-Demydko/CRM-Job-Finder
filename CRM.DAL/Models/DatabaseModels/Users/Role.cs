using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.DAL.Models.DatabaseModels.Users
{
    public class Role : IdentityRole<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }


    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> item)
        {
            item.HasMany(i => i.UserRoles).WithOne(i => i.Role).HasForeignKey(r => r.RoleId);

            item.HasData(new[]
            {
                new Role()
                {
                    Name = "user",
                    NormalizedName = "USER"
                },
                new Role()
                {
                    Name = "kontragent",
                    NormalizedName = "KONTRAGENT"
                },
            });
        }
    }
}