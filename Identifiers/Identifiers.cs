using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiers
{
    public static class SeasonMatches
    {
        public static KeyValuePair<Guid, string> PremierLeague_2014_2015 = new KeyValuePair<Guid, string>(new Guid("2BAB6261-30E5-4158-A11D-841D7D075664"), "[dbo].[premierLeague1415]");
        public static KeyValuePair<Guid, string> PremierLeague_2013_2014 = new KeyValuePair<Guid, string>(new Guid("5618CB3C-81AD-489F-BB0F-37F008A118F4"), "");
        public static KeyValuePair<Guid, string> PremierLeague_2012_2013 = new KeyValuePair<Guid, string>(new Guid("0F8F4386-DEA8-4BF5-9F29-9E9926091B4C"), "");

        public static KeyValuePair<Guid, string> Championship_2014_2015 = new KeyValuePair<Guid, string>(new Guid("C7FDD84C-5E37-4B9C-A8ED-BE80E614151C"), "[dbo].[championship1415]");
        public static KeyValuePair<Guid, string> Championship_2013_2014 = new KeyValuePair<Guid, string>(new Guid("688853FA-6622-463C-8A6C-DAE686477213"), "");
        public static KeyValuePair<Guid, string> Championship_2012_2013 = new KeyValuePair<Guid, string>(new Guid("2E744C2B-08AE-49DE-8E41-10B4604760BE"), "");
    }

    public static class LeaguesTables
    {
        public static KeyValuePair<Guid, string> PremierLeague_2014_2015 = new KeyValuePair<Guid, string>(new Guid("2848960C-6821-4300-8DF7-D57C8756F20A"), "[dbo].[PremierLeagueTable1415]");
        public static KeyValuePair<Guid, string> PremierLeague_2013_2014 = new KeyValuePair<Guid, string>(new Guid("CF77FB8F-B06E-4E51-8FBC-5FC9616CC6AC"), "");
        public static KeyValuePair<Guid, string> PremierLeague_2012_2013 = new KeyValuePair<Guid, string>(new Guid("66AEBEFC-EA6E-45FA-A10A-DE400B1E107F"), "");

        public static KeyValuePair<Guid, string> Championship_2014_2015 = new KeyValuePair<Guid, string>(new Guid("5684138B-F6D7-4E66-893E-4874D990904C"), "[dbo].[ChampionshipTable1415]");
        public static KeyValuePair<Guid, string> Championship_2013_2014 = new KeyValuePair<Guid, string>(new Guid("BD1BFD26-D147-4D60-8EC5-9D43CE006287"), "");
        public static KeyValuePair<Guid, string> Championship_2012_2013 = new KeyValuePair<Guid, string>(new Guid("F35D538D-DA45-486C-B5AE-5E1EC19352D2"), "");
    }


    public static class Teams
    {
        public static Guid Arsenal = new Guid();
        public static Guid Liverpool = new Guid();
        public static Guid ManUnited = new Guid();
    }
}
