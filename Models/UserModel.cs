﻿namespace TaskingOutAppAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string Role { get; set; } = string.Empty;
    public string Membership { get; set; } = string.Empty;

    public List<Checklist> Checklists { get; set; } = new();
}
