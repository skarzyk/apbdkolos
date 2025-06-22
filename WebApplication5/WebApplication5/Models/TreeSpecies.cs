using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models;

[Table("Tree_Species")]
public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    public string LatinName { get; set; } = null!;
    public int GrowthTimeInYears { get; set; }
    
    public List<SeedlingBatch> SeedlingBatches { get; set; } = null!;
}