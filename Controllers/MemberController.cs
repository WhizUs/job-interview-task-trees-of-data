using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreesOfData.Database;
using TreesOfData.Models;
using TreesOfData.Views;

namespace TreesOfData.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly IAppDbContext _appDbContext;

    public MemberController(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    [HttpGet("/members/")]
    public IEnumerable<Member> Index()
    {
        return _appDbContext.Members
            .AsNoTracking()
            .Include(member => member.Teams)
            .Include(member => member.MemberCountries)
            .ThenInclude(memberCountries => memberCountries.Country)
            .Take(10).ToList();
    }
    
    [HttpGet("/members/{id}")]
    public Member? Details(int id)
    {
        return _appDbContext.Members
            .AsNoTracking()
            .Include(member => member.Teams)
            .Include(member => member.MemberCountries)
                .ThenInclude(memberCountries => memberCountries.Country)
            .Take(10)
            .FirstOrDefault(team => team.Id == id) ?? null;
    }
    
    [HttpGet("/members/{id}/countries/{countryId}/teams")]
    public IEnumerable<Team>? TeamsByCountry(int id, int countryId)
    {
        return _appDbContext.MemberCountries
            .Where(memberCountries => memberCountries.MemberId == id)
            .Where(memberCountries => memberCountries.CountryId == countryId)
            .Include(memberCountries => memberCountries.Team)
            .Select(memberCountries => memberCountries.Team)
            .Take(10)
            .ToList();
    }
}