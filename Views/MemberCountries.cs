using TreesOfData.Models;

namespace TreesOfData.Views;

public class MemberCountries : IEquatable<MemberCountries>
{
    public int MemberId { get; init; }
    public Member Member { get; init; } = default!;
    public int TeamId { get; init; }
    public Team Team { get; init; } = default!;
    public int CountryId { get; init; }
    public Country Country { get; init; } = default!;
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as MemberCountries);
    }

    public bool Equals(MemberCountries? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return MemberId == other.MemberId && CountryId == other.CountryId && TeamId == other.TeamId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MemberId, CountryId, TeamId);
    }
}