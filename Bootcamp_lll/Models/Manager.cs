namespace Bootcamp_lll.Models
{
    internal class Manager : User
    {
        public int Id { get; set; } 
        public string? Name { get; set; }   
        public string? LastName { get; set; }
        public string? CI { get; set; } 
    }
}
