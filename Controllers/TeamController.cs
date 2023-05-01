using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreesOfData.Database;
using TreesOfData.Models;

namespace TreesOfData.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly IAppDbContext _appDbContext;

    public TeamController(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    [HttpGet]
    [Route("/teams/")]
    public IEnumerable<Team> Index()
    {
        return _appDbContext.Teams
            .Include(team => team.Members)
            .Include(team => team.Countries)
            .Take(10)
            .ToList();
    }
    
    [HttpGet]
    [Route("/teams/{id}")]
    public Team? Details(int id)
    {
        return _appDbContext.Teams
            .Include(team => team.Members)
            .Include(team => team.Countries)
            .FirstOrDefault(team => team.Id == id) ?? null;
    }
}