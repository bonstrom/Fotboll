using System;
using ResourceAccessNameSpace;
using DataTransferObjects;
using System.Linq;

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

        public LeagueTable LoadLeagueTable(Guid season)
        {
            return resource.GetLeagueTable(season);
        }
    }
}
