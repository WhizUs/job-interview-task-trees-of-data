using TreesOfData.Views;

namespace TreesOfData.Models;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Team> Teams { get; set; } = new();
    public List<MemberCountries> MemberCountries { get; } = new();
}