namespace TaskingOutAppAPI.Models;

public class Checklist
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Checktask> CheckTasks { get; set; } = new();
    public User User { get; set; } = new();
}
