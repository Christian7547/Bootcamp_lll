using System.Collections.Generic;


namespace Bootcamp_lll.Models
{
    internal class Team
    {
        public string TeamName { get; set; }    
        public int SubjectId { get; set; }
        public int ManagerId { get; set; }
        public List<Contestant> Contestants { get; set; }

        public Team(string teamName, int subject, int manager, List<Contestant> contestants)
        {
            TeamName = teamName;
            SubjectId = subject;
            ManagerId = manager;    
            Contestants = contestants;
        }
    }
}
