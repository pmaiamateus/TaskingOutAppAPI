namespace TaskingOutAppAPI.Models;

public class Checktask
{
    public int Id { get; set; }
    public int Index { get; set; }
    public string Description { get; set; } = "";
    public bool IsChecked { get; set; } = false;
    public bool IsHidden { get; set; } = false;
    public Checklist Checklist { get; set; } = new();
}
