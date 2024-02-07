using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Utilities;

namespace CleanArchitecture.API.Utilities;

public class DataInitializer
{
    internal static void Initialize(ApplicationDbContext context)
    {
        context.Database.Migrate();
        InitData(context);
    }

    private static void InitData(ApplicationDbContext context)
    {
        if (!context.Users.Any())
        {
            var adminRole = new Role { Title = "Admin" };
            var userRole = new Role { Title = "User" };
            context.Roles.AddRange(new List<Role>()
            {
                adminRole, userRole
            });

            context.Users.Add(new User()
            {
                FullName = "Farzam Yamini",
                UserName = "admin",
                PasswordHash = "123456".CleanString().GetSha256Hash(),
                SecurityStamp = Guid.NewGuid(),
                UserRoles = new List<UserRole>() { new UserRole() { Role = adminRole } }
            });

            context.SaveChanges();
        }
    }
}