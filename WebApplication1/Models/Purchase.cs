namespace WebApplication1.Models;

public class Purchase
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public double Price { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; } = null!;

    public int ProgramId { get; set; }
    public Programs Program { get; set; } = null!;
}
