namespace EF7Relationships.Models;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }
}