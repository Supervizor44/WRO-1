using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WRO.Web.Data.Entities;
using WRO.Web.Data.Entities.IdentityAggregate;
using WRO.Web.Data.Entities.ImageAggregate;
using WRO.Web.Data.Entities.NewsAggregate;
using WRO.Web.Data.Entities.RegistrantAggregate;


namespace WRO.Web.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public DbSet<Admin> Admins { get; set; } = null!;

    public DbSet<News> News { get; set; } = null!;
    public DbSet<NewsContext> NewsContexts { get; set; } = null!;

    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<GalleryImage> GalleryImages { get; set; } = null!;
    public DbSet<IdentityCardImage> IdentityCardImages { get; set; } = null!;

    public DbSet<Judge> Judges { get; set; } = null!;
    public DbSet<Volunteer> Volunteers { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<TeamCoach> TeamCoaches { get; set; } = null!;
    public DbSet<TeamMember> TeamMembers { get; set; } = null!;

    public DbSet<ContestCategory> ContestCategories { get; set; } = null!;

    public DbSet<ContactUs> ContactUs { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Admin Seed Data

        Admin admin = new("admin@wro.az", "adminpass")
        {
            Id = new("939e6e06-b9bf-4eee-926b-dc00c908762c"),
            SecurityStamp = new("fe4dd35e-69a2-4a30-953d-40d4522fb77c"),
            ConcurrencyStamp = new("d2d4b0fd-1887-4c80-b292-0d7b88ee095f"),
            PasswordHash = "AQAAAAEAACcQAAAAEGGBBBnibETEbCkw/QivohTJLpFlHXbeUSAJ955v0Hh2cjKxtU6dtbHU2Lccy+nozg==" // adminpass
        };
        modelBuilder.Entity<Admin>().HasData(admin);
        #endregion

        #region ContestCategory Seed Data

        modelBuilder.Entity<ContestCategory>()
            .HasData(new ContestCategory[]
        {
            new("Robomission - Elementary(8 - 12)") { Id = new("23583547-56a0-4176-9603-133dec1a402f") },
            new("Robomission - Junior(11 - 15)") { Id = new("74896a87-1e98-4dd7-814a-f85362676f52") },
            new("Robomission - Senior(14 - 19)") { Id = new("fc048f37-45b3-4c6b-baa8-b5b0c5b9b6ce") },
            new("Future Innovators - Elementary(8 - 12)") { Id = new("8320e149-0971-4630-ace4-08e471d18064") },
            new("Future Innovators - Junior(11 - 15)") { Id = new("d8f0f079-7401-45ba-b918-6d1b566e527f") },
            new("Future Innovators - Senior(14 - 19)") { Id = new("14659459-7a79-4b15-9532-968a9512fcf3") },
            new("Robosports(11 - 19)") { Id = new("c0a4af27-0ab0-4212-8a94-188f6a6dac6a") },
            new("Future Engineers(14 - 19)") { Id = new("f51485e9-e9c1-491c-a03e-20194d89f7a3") }
        });
        #endregion

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.Created = DateTime.Now;

            else if (entry.State == EntityState.Modified)
                entry.Entity.LastModified = DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
