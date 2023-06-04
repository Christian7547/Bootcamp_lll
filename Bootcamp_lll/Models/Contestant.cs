namespace Bootcamp_lll.Models
{
    internal class Contestant : User
    {
        public int Id { get; set; }
        public string? Name { get;set; }
        public string? LastName { get;set; }
        public string? Grade { get; set; }
    }
}
