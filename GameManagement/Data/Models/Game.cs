namespace GameManagement.Data.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
