namespace TaskingOutAppAPI.Models;

public class Checktasks
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public bool IsChecked { get; set; } = false;
    public bool IsHidden { get; set; } = false;
}
