namespace WebApplication1.Models;

public class Programs
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Duration { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
