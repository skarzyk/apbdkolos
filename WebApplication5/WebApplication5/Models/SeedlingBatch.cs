using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models;
[Table("Seedling_Batch")]
public class SeedlingBatch
{
    [Key]
    public int BatchId { get; set; }
    [ForeignKey(nameof(Nursery))]
    public int NurseryId { get; set; }
    [ForeignKey(nameof(TreeSpecies))]
    public int SpeciesId { get; set; }
    public int Quantity { get; set; }
    public DateOnly SowndDate { get; set; }
    public DateOnly? ReadyDate { get; set; } 
    
    public TreeSpecies TreeSpecies { get; set; } = null!;
    public Nursery Nursery { get; set; } = null!;
    public List<Responsible> Responsibles { get; set; } = null!;
}