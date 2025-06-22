using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models;

[PrimaryKey(nameof(EmployeeId), nameof(BatchId))]
public class Responsible
{
    [ForeignKey(nameof(SeedlingBatch))]
    public int BatchId { get; set; }
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    public string Role { get; set; } = null!;
    
    public Employee Employe { get; set; } = null!;
    public SeedlingBatch SeedlingBatch { get; set; } = null!;
}