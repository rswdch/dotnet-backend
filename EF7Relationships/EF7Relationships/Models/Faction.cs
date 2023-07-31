namespace EF7Relationships.Models;

public class Faction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Character> Characters { get; set; }
}