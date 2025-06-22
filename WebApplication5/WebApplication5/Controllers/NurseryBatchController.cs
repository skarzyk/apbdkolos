using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;
using WebApplication5.DTO;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NurseriesController : ControllerBase
{
    private readonly SystemDbContext _context;

    public NurseriesController(SystemDbContext context)
    {
        _context = context;
    }

    [HttpGet("{nurseryId}/batches")]
    public async Task<IActionResult> GetNurseryBatchesAsync(int nurseryId,
        CancellationToken cancellationToken)
    {
        var nursery = await _context.Nurseries
            .Include(n => n.SeedlingBatches)
            .ThenInclude(sb => sb.Responsibles)
            .ThenInclude(r => r.Employe)
            .Include(n => n.SeedlingBatches)
            .ThenInclude(sb => sb.TreeSpecies)
            .FirstOrDefaultAsync(n => n.NurseryId == nurseryId, cancellationToken);


        if (nursery == null)
        {
            return NotFound();
        }

        var dto = new NurseryBatchesDto
        {
            NurseryId = nursery.NurseryId,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
            Batches = nursery.SeedlingBatches.Select(sb => new BatchesDto
            {
                BatchId = sb.BatchId,
                Quantity = sb.Quantity,
                SowndDate = sb.SowndDate,
                ReadyDate = sb.ReadyDate,
                Species = new SpeciesDto
                {
                    LatinName = sb.TreeSpecies.LatinName,
                    GrowthTimeInYears = sb.TreeSpecies.GrowthTimeInYears
                },
                Responsible = sb.Responsibles.Select(r => new ResponsibleDto
                {
                    FirstName = r.Employe.FirstName,
                    LastName = r.Employe.LastName,
                    Role = r.Role
                }).ToList()
            }).ToList()
        };
        return Ok(dto);
    }
}