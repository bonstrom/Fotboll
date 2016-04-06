using System;
using System.Windows.Forms;
using EngineNameSpace;
using DataTransferObjects;
using Identifiers;

namespace Soccer
{
    public partial class Form1 : Form
    {
        Engine engine = new Engine();
        public Form1()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            LoadTeamLists();
            LoadSeasonList();
        }

        private void LoadSeasonList()
        {
            ComboBoxItem[] items = new ComboBoxItem[] { new ComboBoxItem(Season.PremierLeague_2014_2015, "Premier League 2014-2015")
                                                       ,new ComboBoxItem(Season.PremierLeague_2013_2014, "Premier League 2013-2014")
                                                       ,new ComboBoxItem(Season.PremierLeague_2012_2013, "Premier League 2012-2013")
                                                       ,new ComboBoxItem(Season.Championship_2014_2015, "Championship 2014-2015")
                                                       ,new ComboBoxItem(Season.Championship_2013_2014, "Championship 2013-2014")
                                                       ,new ComboBoxItem(Season.Championship_2012_2013, "Championship 2012-2013")};
            foreach(var item in items)
                seasonList.Items.Add(item);
        }

        private void homeTeamList_SelectedIndexChanged(object sender, EventArgs e) { }
        private void awayTeamList_SelectedIndexChanged(object sender, EventArgs e) { }



        private void LoadTeamLists()
        {
            var teams = engine.GetPremierLeagueTeams();
            foreach (var team in teams)
            {
                homeTeamList.Items.Add(team.Name);
                awayTeamList.Items.Add(team.Name);
            }
        }

        private void seasonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var season = (ComboBoxItem)((ComboBox)sender).SelectedItem;
            engine.LoadLeagueTable(season.Guid);
        }
    }
}
