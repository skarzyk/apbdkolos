using WebApplication5.Models;

namespace WebApplication5.DTO;

public class NurseryBatchesDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly EstablishedDate { get; set; }
    public IEnumerable<BatchesDto> Batches { get; set; } = null!;
}

public class BatchesDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateOnly SowndDate { get; set; }
    public DateOnly? ReadyDate { get; set; }
    public SpeciesDto Species { get; set; } = null!;
    public IEnumerable<ResponsibleDto> Responsible { get; set; } = null!;
}

public class SpeciesDto
{
    public string LatinName { get; set; } = null!;
    public int GrowthTimeInYears { get; set; }
}

public class ResponsibleDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Role { get; set; } = null!;
}