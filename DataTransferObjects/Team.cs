namespace DataTransferObjects
{
    public class Team
    {
        public Team(string teamName)
        {
            Name = teamName;          
        }

        public int Position { get; set; }
        public string Name { get; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; }
        public int GoalsAgainst { get; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
    }
}