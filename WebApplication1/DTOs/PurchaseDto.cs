namespace WebApplication1.DTOs;

public class PurchaseDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public IEnumerable<object> Purchases { get; set; } = new List<object>();
}
