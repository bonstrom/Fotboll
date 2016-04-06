using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Identifiers;

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
            LeagueTable leagueTable = null;
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
    }
}
