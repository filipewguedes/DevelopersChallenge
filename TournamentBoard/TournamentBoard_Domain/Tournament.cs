using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentBoard_Domain
{
    public class Tournament
    {
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
        public string Winner { get; set; }
        public List<string> Teams { get; set; }

        private TournamentState state;

        public TournamentState State
        {
            get { return state; }
        }

       
        public Tournament(string name)
        {
            Teams = new List<string>();
            Matches = new List<Match>();
            state = TournamentState.New;

            this.Name = name;
                        
        }

        public bool AddTeam(string teamName)
        {
            if (state == TournamentState.New)
            {
                Teams.Add(teamName);
                return true;
            }
            {
                return false;

            }
        }

        public void Start()
        {
            state = TournamentState.Started;

            for (int i = 0; i <= Teams.Count-1; i = i+2)
            {
                if(i == Teams.Count - 1)
                    Matches.Add(new Match(Teams[i], String.Empty, MatchState.Open)); //In case of odd team number
                else
                    Matches.Add(new Match(Teams[i], Teams[i + 1], MatchState.Closed));
            }
        }

        public bool Score(int selectedMatch, int score1, int score2)
        {
            var match = Matches[selectedMatch];

            if (match.State == MatchState.Ended)
                return false;

            if (score1 == score2)
                return false;

            string matchWinner;

            if (score1 > score2)
                matchWinner = match.Team1;
            else
                matchWinner = match.Team2;

            match.Score1 = score1;
            match.Score2 = score2;
            match.State = MatchState.Ended;
                 
            //Select a match that only have one team(is considered a Open Match)
            //If dont exist, create a new one
            var nextMatch = Matches.Where(m => m.State == MatchState.Open).FirstOrDefault();

            if (nextMatch == null)
            {
                nextMatch = new Match(matchWinner, String.Empty, MatchState.Open);
                Matches.Add(nextMatch);
            }
            else
            {
                nextMatch.Team2 = matchWinner;
                nextMatch.State = MatchState.Closed;
            }

            //If the collection dont have any Closed Match avaiable,
            //that means all the matches are ended and this winner is the Tournament Winner
            if (!Matches.Any(m => m.State == MatchState.Closed))
            {
                Winner = matchWinner;
                state = TournamentState.Ended;
                return true;
            }

            return true;
        }
    }

    public enum TournamentState
    {
        New,
        Started,
        Ended
    }
}
