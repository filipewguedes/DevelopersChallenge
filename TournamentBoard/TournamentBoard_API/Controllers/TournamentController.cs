using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentBoard_Domain;

namespace TournamentBoard_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        static Tournament tournament = new Tournament("Testing API");

        public TournamentController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = new List<String>();

            foreach (var match in tournament.Matches)
            {
                result.Add(match.Team1 + " " + match.Score1 + " x " + match.Team2 + " " + match.Score2);
            }

            return result;
        }       

        [HttpGet("Winner")]
        public string GetWinner()
        {
            if (tournament.State == TournamentState.Ended)
                return tournament.Winner;
            else
                return "Tournament dont have a winner yet";
        }

        [HttpPost("Start")]
        public ActionResult StartTournament()
        {
            if(tournament.State == TournamentState.New)
            {
                tournament.Start();
                return Ok();
            }
            else if(tournament.State == TournamentState.Started)
            {
                return BadRequest("Tournament Already Started");
            }
            else
            {
                return BadRequest("Tournament Already Ended");

            }
        }

        [HttpPost]
        public bool Post([FromBody] MatchRequest match)
        {
            return tournament.Score(match.Match, match.Score1, match.Score2);
        }

        [HttpPost("Teams")]
        public ActionResult Post([FromBody] string team)
        {
            if (tournament.State == TournamentState.New)
            {
                tournament.AddTeam(team);
                return Ok();
            }
            else
            {
                return BadRequest("You can only add teams to a not started Tournament");
            }             
        }
    }

    public class MatchRequest
    {
        public int Match { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
    }
}
