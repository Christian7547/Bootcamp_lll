using System.Collections.Generic;


namespace Bootcamp_lll.Models
{
    public class Team
    {
        public int Id { get; set; } 
        public string? TeamName { get; set; }    
        public int SubjectId { get; set; }
        public int ManagerId { get; set; }
        public int GradeId { get; set; }
        public List<Contestant> Contestants { get; set; }
    }
}
