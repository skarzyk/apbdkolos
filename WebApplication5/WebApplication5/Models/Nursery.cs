using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models;

public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly EstablishedDate { get; set; }
    
    public List<SeedlingBatch> SeedlingBatches { get; set; } = null!;
   
}