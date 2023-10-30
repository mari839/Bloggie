
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.data
{
    public class AuthDbContext : IdentityDbContext
    {
        //we have three roles: user, admin and superadmin, we create super admin user by defaut
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //1.seed Roles (user, admin, superadmin)
            var adminRoleId = "0bf1c82c-f0d3-4f6f-8761-ccf710b38fca";
            var superAdminRoleId = "b9012cb4-70a7-4a73-b60b-3625cfa06131";
            var userRoleId = "1d419e6d-6171-4687-b2ae-7cee96409f28";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name ="SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            //we have to insert that roles into the builder object, so when we run entityframeworkcore migrations, these roles will be taken as seed and will be inserted in the database
            builder.Entity<IdentityRole>().HasData(roles); 

            //2.seed superadmin
            var superAdminId = "3cf59c85-eb7d-40f0-acf1-d18c87419fea";
            var superAdminUser = new IdentityUser //create superadmin user
            {
                UserName = "SuperAdmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Superadmin@123"); //give password to superadmin
            builder.Entity<IdentityUser>().HasData(superAdminUser); //seed superadmin user

            //3.add all roles to superadmin
            var superAdminRoles = new List<IdentityUserRole<string>> //mapping between identity user and the role
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string> {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };
            
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
