using System;
using TournamentBoard_Domain;
using Xunit;

namespace TournamentBoard_Test
{
    public class TournamentTest
    {
        //Most Simple Scenario
        [Fact]
        public void AddTwoTeamsAndMakeOneWinner()
        {
            var tournament = new Tournament("TestTournament");
             tournament.AddTeam("Red");
            tournament.AddTeam("Blue");

            tournament.Start();
            tournament.Score(0,1, 2);

            Assert.Equal("Red", tournament.Matches[0].Team1);
            Assert.Equal("Blue", tournament.Matches[0].Team2);
            Assert.Equal("Blue", tournament.Winner);
        }

        //Just one more round of matches
        [Fact]
        public void AddFourTeamsAndMakeOneWinner()
        {
            var tournament = new Tournament("TestTournament");
            tournament.AddTeam("Red");
            tournament.AddTeam("Blue");

            tournament.AddTeam("Green");
            tournament.AddTeam("Yellow");

            tournament.Start();
            tournament.Score(0, 1, 2);
            tournament.Score(1, 3, 2);
            tournament.Score(2, 0, 1);
            

            Assert.Equal("Red", tournament.Matches[0].Team1);
            Assert.Equal("Blue", tournament.Matches[0].Team2);
            Assert.Equal("Green", tournament.Matches[1].Team1);
            Assert.Equal("Yellow", tournament.Matches[1].Team2);
            Assert.Equal("Blue", tournament.Matches[2].Team1);
            Assert.Equal("Green", tournament.Matches[2].Team2);

            Assert.Equal("Green", tournament.Winner);
        }

        //First round has a pair number, the second has a odd number of teams
        [Fact]
        public void AddSixTeamsAndMakeOneWinner()
        {
            var tournament = new Tournament("TestTournament");
            tournament.AddTeam("Red");
            tournament.AddTeam("Blue");

            tournament.AddTeam("Green");
            tournament.AddTeam("Yellow");

            tournament.AddTeam("Purple");
            tournament.AddTeam("White");

            tournament.Start();
            tournament.Score(0, 1, 2);
            tournament.Score(1, 3, 2);
            tournament.Score(2, 0, 1);
            tournament.Score(3, 0, 4);
            tournament.Score(4, 1, 2);
                       
            Assert.Equal("Green", tournament.Winner);
        }

        //Just to test odd number of teams
        [Fact]
        public void AddFiveTeamsAndMakeOneWinner()
        {
            var tournament = new Tournament("TestTournament");
            tournament.AddTeam("Red");
            tournament.AddTeam("Blue");

            tournament.AddTeam("Green");
            tournament.AddTeam("Yellow");

            tournament.AddTeam("Purple");

            tournament.Start();
            tournament.Score(0, 1, 2);
            tournament.Score(1, 3, 2);
            tournament.Score(2, 0, 1);
            tournament.Score(3, 0, 4);

            Assert.Equal("Blue", tournament.Winner);
        }

        //This cannot happens, because will cause inconsistence
        [Fact]
        public void TryAddTeamsAfterTournamentStartShouldNotWork()
        {
            var tournament = new Tournament("TestTournament");
            bool result;

            result = tournament.AddTeam("Red");
            Assert.True(result);

            result = tournament.AddTeam("Blue");
            Assert.True(result);

            tournament.Start();

            result = tournament.AddTeam("Green");

            Assert.False(result);
            Assert.Equal(2, tournament.Teams.Count);
        }

        //If that was posible, is necessary to recalculate all the matches after this matches
        //I don`t want this now =)
        [Fact]
        public void TryChangeMatchScoreShouldNotWork()
        {
            var tournament = new Tournament("TestTournament");
            tournament.AddTeam("Red");
            tournament.AddTeam("Blue");

            bool result;

            tournament.Start();

            result = tournament.Score(0, 1, 2);
            Assert.True(result);

            result = tournament.Score(0, 3, 2);
            Assert.False(result);

        }

        //Considering it is a eliminatory match, dont make sense a draw
        [Fact]
        public void TryDrawMatchShouldNotWork()
        {
            var tournament = new Tournament("TestTournament");
            tournament.AddTeam("Red");
            tournament.AddTeam("Blue");

            bool result;

            tournament.Start();
            
            result = tournament.Score(0, 1, 1);
            Assert.False(result);
        }
    }  
}
