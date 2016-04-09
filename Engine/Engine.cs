using System;
using ResourceAccessNameSpace;
using DataTransferObjects;
using System.Linq;
using System.Collections.Generic;

namespace EngineNameSpace
{
    public class Engine
    {
        ResourceAccess resource = new ResourceAccess();
        public Engine()
        {
            Initialize();
        }

        private void Initialize()
        {
            // CalculateOdds(new Team(), new Team());
        }

        public int CalculateOdds(Team homeTeam, Team awayTeam)
        {
            return 5 + 4 * 3;
        }

        public Team[] GetPremierLeagueTeams()
        {
            return resource.GetPremierLeagueTeams();
        }

        public Team[] GetChampionshipTeams()
        {
            return resource.GetPremierLeagueTeams();
        }

        public List<Match> GetMatches(Team team1, Team team2)
        {
            return resource.GetMatches(team1, team2);
        }

        public LeagueTable LoadLeagueTable(Guid season)
        {
            return resource.GetLeagueTable(season);
        }
    }
}
