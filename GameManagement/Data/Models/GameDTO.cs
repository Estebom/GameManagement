namespace GameManagement.Data.Models
{
    public class GameDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
