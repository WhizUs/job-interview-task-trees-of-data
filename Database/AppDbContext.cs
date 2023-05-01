using Microsoft.EntityFrameworkCore;
using TreesOfData.Models;
using TreesOfData.Views;

namespace TreesOfData.Database;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<MemberCountries> MemberCountries => Set<MemberCountries>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Team>()
            .HasOne(team => team.Parent)
            .WithMany(team => team.Children)
            .HasForeignKey(team => team.ParentId)
            .IsRequired(false);

        modelBuilder.Entity<MemberCountries>()
            .ToView(nameof(MemberCountries))
            .HasKey(nameof(TreesOfData.Views.MemberCountries.MemberId), nameof(TreesOfData.Views.MemberCountries.TeamId),
                nameof(TreesOfData.Views.MemberCountries.CountryId));
    }
}