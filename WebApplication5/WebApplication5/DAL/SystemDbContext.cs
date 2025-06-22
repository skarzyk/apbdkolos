using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.DAL;

public class SystemDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<SeedlingBatch> SeedlingBatches { get; set; }
    public DbSet<TreeSpecies> TreeSpecies { get; set; }

    protected SystemDbContext()
    {
        
    }
    
    public SystemDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                HireDate = new DateOnly(2020, 1, 15)
            },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Jokky",
                LastName = "Doe",
                HireDate = new DateOnly(2020, 2, 15)
            }
            );

        modelBuilder.Entity<Nursery>().HasData(
            new Nursery
            {
                NurseryId = 1,
                Name = "Green Haven",
                EstablishedDate = new DateOnly(2015, 3, 10)
            },
            new Nursery
            {
                NurseryId = 2,
                Name = "Haven",
                EstablishedDate = new DateOnly(2015, 8, 10)

            });

        modelBuilder.Entity<Responsible>().HasData(
            new Responsible
            {
                BatchId = 1,
                EmployeeId = 1,
                Role = "Manager"
            },
            new Responsible
            {
                BatchId = 2,
                EmployeeId = 2,
                Role = "Supervisor"
            });

        modelBuilder.Entity<SeedlingBatch>().HasData(
            new SeedlingBatch
            {
                BatchId = 1,
                NurseryId = 1,
                SpeciesId = 1,
                Quantity = 1000,
                SowndDate = new DateOnly(2023, 1, 1),
                ReadyDate = new DateOnly(2023, 6, 1)
            },
            new SeedlingBatch
            {
                BatchId = 2,
                NurseryId = 2,
                SpeciesId = 2,
                Quantity = 700,
                SowndDate = new DateOnly(2023, 5, 1),
                ReadyDate = new DateOnly(2023, 9, 1)

            });

        modelBuilder.Entity<TreeSpecies>().HasData(
            new TreeSpecies
            {
                SpeciesId = 1,
                LatinName = "Oak",
                GrowthTimeInYears = 1
            },
            new TreeSpecies
            {
                SpeciesId = 2,
                LatinName = "Burak",
                GrowthTimeInYears = 2

            });
    }
}