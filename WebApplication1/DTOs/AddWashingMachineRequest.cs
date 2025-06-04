namespace WebApplication1.DTOs;

public class AddWashingMachineRequest
{
    public WashingMachineDto WashingMachine { get; set; } = null!;
    public List<ProgramDto> AvailablePrograms { get; set; } = new();
}

public class WashingMachineDto
{
    public double MaxWeight { get; set; }
    public string SerialNumber { get; set; } = null!;
}

public class ProgramDto
{
    public string ProgramName { get; set; } = null!;
    public double Price { get; set; }
}
