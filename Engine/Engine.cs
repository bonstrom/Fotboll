using System;
using ResourceAccessNameSpace;
using DataTransferObjects;
using System.Linq;
using System.Collections.Generic;
using Identifiers;

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

        public Team[] GetLeagueTeams(KeyValuePair<Guid, string> league)
        {
            if(league.Key == SeasonMatches.PremierLeague_2014_2015.Key)
                return resource.GetLeagueTeams(LeaguesTables.PremierLeague_2014_2015);

            if (league.Key == SeasonMatches.PremierLeague_2013_2014.Key)
                return resource.GetLeagueTeams(LeaguesTables.PremierLeague_2013_2014);

            if (league.Key == SeasonMatches.PremierLeague_2012_2013.Key)
                return resource.GetLeagueTeams(LeaguesTables.PremierLeague_2012_2013);

            if (league.Key == SeasonMatches.Championship_2014_2015.Key)
                return resource.GetLeagueTeams(LeaguesTables.Championship_2014_2015);

            if (league.Key == SeasonMatches.Championship_2013_2014.Key)
                return resource.GetLeagueTeams(LeaguesTables.Championship_2013_2014);

            if (league.Key == SeasonMatches.Championship_2012_2013.Key)
                return resource.GetLeagueTeams(LeaguesTables.Championship_2012_2013);
     
            else
                return resource.GetLeagueTeams(league);
        }

        public List<Match> GetMatches(Team team1, Team team2, KeyValuePair<Guid, string> season)
        {
            return resource.GetMatches(team1, team2, season);
        }

        public LeagueTable LoadLeagueTable(KeyValuePair<Guid, string> season)
        {
            return resource.GetLeagueTable(season);
        }
    }
}
