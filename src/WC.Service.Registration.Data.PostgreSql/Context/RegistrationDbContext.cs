using Microsoft.EntityFrameworkCore;
using WC.Service.Registration.Data.Models;

namespace WC.Service.Registration.Data.PostgreSql.Context;

public sealed class RegistrationDbContext : DbContext
{
    public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options)
    {
        // Database.Migrate();
    }

    public DbSet<UserRegistrationEntity> UsersCredentials { get; init; } = null!;
}