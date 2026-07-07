using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpsDesk.Domain.Constants;
using OpsDesk.Domain.Entities;
using OpsDesk.Infrastructure.Identity;

namespace OpsDesk.Infrastructure.SeedData;

public static class AppSeedData
{
    private static readonly DateTimeOffset SeededAt = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static void Apply(ModelBuilder builder)
    {
        SeedRoles(builder);
        SeedDepartments(builder);
        SeedLocations(builder);
        SeedUsers(builder);
    }

    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            CreateRole("role-admin", UserRoles.Admin),
            CreateRole("role-it-staff", UserRoles.ITStaff),
            CreateRole("role-manager", UserRoles.Manager),
            CreateRole("role-employee", UserRoles.Employee),
            CreateRole("role-auditor", UserRoles.Auditor));
    }

    private static void SeedDepartments(ModelBuilder builder)
    {
        builder.Entity<Department>().HasData(
            new Department
            {
                Id = 1,
                Name = "Information Technology",
                Code = "IT",
                CreatedAt = SeededAt,
                IsActive = true
            },
            new Department
            {
                Id = 2,
                Name = "Finance",
                Code = "FIN",
                CreatedAt = SeededAt,
                IsActive = true
            },
            new Department
            {
                Id = 3,
                Name = "Human Resources",
                Code = "HR",
                CreatedAt = SeededAt,
                IsActive = true
            });
    }

    private static void SeedLocations(ModelBuilder builder)
    {
        builder.Entity<Location>().HasData(
            new Location
            {
                Id = 1,
                Name = "Head Office",
                Building = "HQ",
                Floor = "3",
                Room = "300",
                City = "St. John's",
                Province = "NL",
                IsActive = true
            },
            new Location
            {
                Id = 2,
                Name = "Service Desk",
                Building = "HQ",
                Floor = "1",
                Room = "110",
                City = "St. John's",
                Province = "NL",
                IsActive = true
            });
    }

    private static void SeedUsers(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().HasData(
            CreateUser("user-admin", "Admin User", "admin@opsdesk.local", 1),
            CreateUser("user-it-staff", "IT Staff User", "it.staff@opsdesk.local", 1),
            CreateUser("user-manager", "Manager User", "manager@opsdesk.local", 1),
            CreateUser("user-employee", "Employee User", "employee@opsdesk.local", 2),
            CreateUser("user-auditor", "Auditor User", "auditor@opsdesk.local", null));

        builder.Entity<IdentityUserRole<string>>().HasData(
            CreateUserRole("user-admin", "role-admin"),
            CreateUserRole("user-it-staff", "role-it-staff"),
            CreateUserRole("user-manager", "role-manager"),
            CreateUserRole("user-employee", "role-employee"),
            CreateUserRole("user-auditor", "role-auditor"));
    }

    private static IdentityRole CreateRole(string id, string roleName)
    {
        return new IdentityRole
        {
            Id = id,
            Name = roleName,
            NormalizedName = roleName.ToUpperInvariant(),
            ConcurrencyStamp = $"{id}-stamp"
        };
    }

    private static ApplicationUser CreateUser(
        string id,
        string displayName,
        string email,
        int? departmentId)
    {
        return new ApplicationUser
        {
            Id = id,
            DisplayName = displayName,
            UserName = email,
            NormalizedUserName = email.ToUpperInvariant(),
            Email = email,
            NormalizedEmail = email.ToUpperInvariant(),
            EmailConfirmed = true,
            SecurityStamp = $"{id}-security-stamp",
            ConcurrencyStamp = $"{id}-concurrency-stamp",
            DepartmentId = departmentId,
            IsActive = true,
            CreatedAt = SeededAt
        };
    }

    private static IdentityUserRole<string> CreateUserRole(string userId, string roleId)
    {
        return new IdentityUserRole<string>
        {
            UserId = userId,
            RoleId = roleId
        };
    }
}
