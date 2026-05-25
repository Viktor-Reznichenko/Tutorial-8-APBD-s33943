using Microsoft.EntityFrameworkCore;
using tut_8.Entities_;

namespace CodeFirst.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PC> PCs { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PC>().HasData(new List<PC>()
        {
            new PC() {Id = 1, Name = "PC Number 1", Weight = 5.1, CreatedAt =  DateTime.Parse("2026-05-07"), Stock = 2, Warranty = 3},
            new PC() {Id = 2, Name = "PC Number 2", Weight = 3.0, CreatedAt =  DateTime.Parse("2026-05-07"), Stock = 1, Warranty = 5},
            new PC() {Id = 3, Name = "PC Number 3", Weight = 4.4, CreatedAt =  DateTime.Parse("2026-05-07"), Stock = 5, Warranty = 1},
        });

        modelBuilder.Entity<ComponentType>().HasData(new List<ComponentType>()
        {
            new ComponentType() { Id = 1, Name = "Processor", Abbreviation = "p"},
            new ComponentType() { Id = 2, Name = "MotherBoard", Abbreviation = "mb"},
            new ComponentType() { Id = 3, Name = "PowerBlock", Abbreviation = "pb"},

        });

        modelBuilder.Entity<ComponentManufacturer>().HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer() { Id = 1, Abbreviation = "m1", FullName = "Manufacturer1", FoundationDate =  DateTime.Parse("2020-03-01") },
            new ComponentManufacturer() { Id = 2, Abbreviation = "m2", FullName = "Manufacturer2", FoundationDate =  DateTime.Parse("2020-04-02")},
            new ComponentManufacturer() { Id = 3, Abbreviation = "m3", FullName = "Manufacturer3", FoundationDate =  DateTime.Parse("2020-05-03")}
        });
        
        modelBuilder.Entity<Component>().HasData(new List<Component>()
        {
            new Component() { Code = "c1", ComponentTypeId = 1, Name = "processor 1", ComponentManufacturerId = 1, Description = "This is processor", },
            new Component() { Code = "c2", ComponentTypeId = 2, Name = "MotherBoard 1", ComponentManufacturerId = 2, Description = "This is mother board",},
            new Component() { Code = "c3", ComponentTypeId = 3, Name = "PowerBlock 1", ComponentManufacturerId = 3, Description = "This is power block",}
        });
        
        modelBuilder.Entity<PCComponent>().HasData(new List<PCComponent>()
        {
            new PCComponent() { PCId = 1, ComponentCode = "c1", Amount = 1},
            new PCComponent() { PCId = 1, ComponentCode = "c2", Amount = 1},
            new PCComponent() { PCId = 1, ComponentCode = "c3", Amount = 1},
            new PCComponent() { PCId = 2, ComponentCode = "c1", Amount = 1},
            new PCComponent() { PCId = 2, ComponentCode = "c2", Amount = 1},
            new PCComponent() { PCId = 2, ComponentCode = "c3", Amount = 1},
            new PCComponent() { PCId = 3, ComponentCode = "c1", Amount = 1},
            new PCComponent() { PCId = 3, ComponentCode = "c2", Amount = 1},
            new PCComponent() { PCId = 3, ComponentCode = "c3", Amount = 1},
        });

        base.OnModelCreating(modelBuilder);
    }
}