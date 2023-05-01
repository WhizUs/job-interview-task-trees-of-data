using Microsoft.EntityFrameworkCore;
using TreesOfData.Models;
using TreesOfData.Views;

namespace TreesOfData.Database;

public interface IAppDbContext : IDisposable
{
    public DbSet<Team> Teams { get; }
    public DbSet<Member> Members { get; }
    public DbSet<Country> Countries { get; }
    public DbSet<MemberCountries> MemberCountries { get; }
}