using Microsoft.EntityFrameworkCore;
using WC.Service.Registration.Data.Models;

namespace WC.Service.Registration.Data.PostgreSql.Context;

public sealed class UserCredentialDbContext : DbContext
{
    public UserCredentialDbContext(DbContextOptions<UserCredentialDbContext> options) : base(options)
    {
        // Database.Migrate();
    }

    public DbSet<UserCredentialEntity> UsersCredentials { get; init; } = null!;
}