using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly AppDbContext _context;

    public WashingMachinesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddWashingMachine(AddWashingMachineRequest request)
    {
        if (request.WashingMachine.MaxWeight < 8)
            return BadRequest("MaxWeight must be at least 8");

        if (await _context.WashingMachines.AnyAsync(w => w.SerialNumber == request.WashingMachine.SerialNumber))
            return Conflict("Washing machine with this serial number already exists");

        foreach (var prog in request.AvailablePrograms)
        {
            if (prog.Price > 25)
                return BadRequest($"Program '{prog.ProgramName}' has price > 25");

            if (!await _context.Programs.AnyAsync(p => p.Name == prog.ProgramName))
                return NotFound($"Program '{prog.ProgramName}' not found");
        }

        var machine = new WashingMachine
        {
            MaxWeight = request.WashingMachine.MaxWeight,
            SerialNumber = request.WashingMachine.SerialNumber
        };

        _context.WashingMachines.Add(machine);
        await _context.SaveChangesAsync();

        return Created("", null);
    }
}
