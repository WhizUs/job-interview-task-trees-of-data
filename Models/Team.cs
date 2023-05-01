namespace TreesOfData.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public Team? Parent { get; set; }
    public List<Team> Children { get; set; } = new();
    public List<Country> Countries { get; set; } = new();
    public List<Member> Members { get; set; } = new();
}