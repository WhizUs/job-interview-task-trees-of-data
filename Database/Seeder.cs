using System.Diagnostics.CodeAnalysis;
using Bogus;
using TreesOfData.Models;

namespace TreesOfData.Database;

internal class Seeder
{
    [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
    internal static async Task Run(AppDbContext appDbContext)
    {
        var countries = new List<Country>()
        {
            new() { Name = "Austria" },
            new() { Name = "Belgium" },
            new() { Name = "Bulgaria" },
            new() { Name = "Croatia" },
            new() { Name = "Republic of Cyprus" },
            new() { Name = "Czech Republic" },
            new() { Name = "Denmark" },
            new() { Name = "Estonia" },
            new() { Name = "Finland" },
            new() { Name = "France" },
            new() { Name = "Germany" },
            new() { Name = "Greece" },
            new() { Name = "Hungary" },
            new() { Name = "Ireland" },
            new() { Name = "Italy" },
            new() { Name = "Latvia" },
            new() { Name = "Lithuania" },
            new() { Name = "Luxembourg" },
            new() { Name = "Malta" },
            new() { Name = "Netherlands" },
            new() { Name = "Poland" },
            new() { Name = "Portugal" },
            new() { Name = "Romania" },
            new() { Name = "Slovakia" },
            new() { Name = "Slovenia" },
            new() { Name = "Spain" },
            new() { Name = "Sweden" },
        };

        await appDbContext.Countries.AddRangeAsync(countries);
        await appDbContext.SaveChangesAsync();

        var members = new List<Member>();

        for (int i = 0; i < 42; i++)
        {
            members.Add(new Faker<Member>()
                .RuleFor(m => m.Name, f => f.Name.FirstName()).Generate());
        }
        
        await appDbContext.Members.AddRangeAsync(members);
        await appDbContext.SaveChangesAsync();

        for (int i = 0; i < 42; i++)
        {
            Random rnd = new Random();
            var team = new Faker<Team>()
                .RuleFor(t => t.Name, f => f.Company.CompanyName())
                .RuleFor(t => t.Countries, countries.OrderBy(r => rnd.Next()).Take(2).ToList())
                .RuleFor(t => t.Members, members.OrderBy(r => rnd.Next()).Take(2).ToList())
                .Generate();

            await appDbContext.Teams.AddAsync(team);
            await appDbContext.SaveChangesAsync();
            
            for (int j = 0; j < rnd.Next(0, 5); j++)
            {
                await AddChildren(appDbContext, team, countries, members, rnd.Next(0, 5));
            }
        }
    }

    private static async Task AddChildren(AppDbContext context, Team parent, List<Country> countries, List<Member> members, int maxDepth)
    {
        Random rnd = new Random();
        for (int i = 0; i < rnd.Next(0, 5); i++)
        {
            var team = new Faker<Team>()
                .RuleFor(t => t.Name, f => f.Company.CompanyName())
                .RuleFor(t => t.Parent, parent)
                .RuleFor(t => t.Countries, countries.OrderBy(r => rnd.Next()).Take(2).ToList())
                .RuleFor(t => t.Members, members.OrderBy(r => rnd.Next()).Take(2).ToList())
                .Generate();
            
            await context.Teams.AddAsync(team);
            await context.SaveChangesAsync();

            if (maxDepth > 0)
            {
                for (int j = 0; j < rnd.Next(0, 5); j++)
                {
                    await AddChildren(context, team, countries, members, maxDepth--);
                }
            }
        }
    }
}