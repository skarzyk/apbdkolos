using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly HireDate { get; set; }
    
    public List<Responsible> Responsibles { get; set; }
    
}