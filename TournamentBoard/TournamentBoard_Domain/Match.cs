using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentBoard_Domain
{
    public class Match
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public MatchState State { get; set; }

        public Match(string team1, string team2, MatchState state)
        {
            this.Team1 = team1;
            this.Team2 = team2;
            this.State = state;
        }
                
    }


    public enum MatchState
    {
        Open,
        Closed,
        Ended
    }
}
