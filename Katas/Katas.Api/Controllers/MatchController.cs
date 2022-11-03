using Katas.MatchAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Katas.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpPatch]
    public void UpdateGoalRecord(int id, SoccerEvent soccerEvent)
    {
        _matchService.UpdateGoalRecord(id, soccerEvent);
    }
}