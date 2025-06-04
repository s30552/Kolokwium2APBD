namespace WebApplication1.Models;

public class WashingMachine
{
    public int Id { get; set; }
    public string SerialNumber { get; set; } = null!;
    public double MaxWeight { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
