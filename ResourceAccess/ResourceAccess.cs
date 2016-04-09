using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Identifiers;
using System.Net;
using Newtonsoft.Json;

namespace ResourceAccessNameSpace
{
    public class ResourceAccess
    {
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public void TestConnection()
        {        
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "SELECT * FROM dbo.championship1415";
                SqlCommand queryCommand = new SqlCommand(query, connection);
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(queryCommandReader);

                String columns = string.Empty;
                foreach (DataColumn column in dataTable.Columns)
                {
                    columns += column.ColumnName + " | ";
                }
                Console.WriteLine(columns);

                // Example 2 - Print the first 10 row of data
                int topRows = 10;
                for (int i = 0; i < topRows; i++)
                {
                    String rowText = string.Empty;
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        rowText += dataTable.Rows[i][column.ColumnName] + " | ";
                    }
                    Console.WriteLine(rowText);
                }

                // Close the connection
                connection.Close();
            }
        }

        public LeagueTable GetLeagueTable(Guid season)
        {
            LeagueTable leagueTable = new LeagueTable();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                
                if (season == Season.PremierLeague_2014_2015)
                {
                    connection.Open();
                    string query = "SELECT * FROM dbo.LeagueTable1415";
                    SqlCommand queryCommand = new SqlCommand(query, connection);
                    SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(queryCommandReader);
                    List<LeagueTable.LeagueTableRow> rows = new List<LeagueTable.LeagueTableRow>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        rows.Add(new LeagueTable.LeagueTableRow(row));
                    }

                    leagueTable = new LeagueTable(rows);
                    connection.Close();
                }
            }
            return leagueTable;
        }

        public Team[] GetPremierLeagueTeams()
        {
            List<Team> teamList = new List<Team>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "SELECT DISTINCT HomeTeam FROM dbo.premierLeague1415";
                SqlCommand queryCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teamList.Add(new Team(reader.GetString(0)));
                    }
                }
                connection.Close();
                return teamList.ToArray();
            }
        }

        public List<Match> GetMatches(Team team1, Team team2)
        {
            List<Match> matches = new List<Match>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = String.Format(@"SELECT [Date] ,[HomeTeam] ,[AwayTeam] ,[FTHG] ,[FTAG]
                              FROM [dbo].[premierLeague1415]
                              WHERE HomeTeam IN('{0}', '{1}')
                              AND AwayTeam IN('{0}', '{1}')", team1.Name, team2.Name);
                SqlCommand queryCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = DateTime.ParseExact(reader.GetString(0), "dd/MM/yy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                        matches.Add(
                            new Match(
                                date,
                                new Team(reader.GetString(1)),
                                new Team(reader.GetString(2)),
                                reader.GetInt16(3),
                                reader.GetInt16(4))
                        );
                    }
                }
                connection.Close();
                return matches;
            }
        }

        public StryktipsCoupon GetStryktipsCoupon()
        {
            Uri jsonUri = new Uri("http://aivu.se/hemsida/strykt/api/stryktipset");
            string jsonString = "";
            using (WebClient wc = new WebClient())
            {
                jsonString = wc.DownloadString(jsonUri);
            }
            StryktipsCoupon stryktipsCoupon = JsonConvert.DeserializeObject<StryktipsCoupon>(jsonString);

            return stryktipsCoupon;
        }
    }
}
