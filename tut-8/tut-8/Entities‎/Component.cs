using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace tut_8.Entities_;

[Table("Components")]

public class Component
{
    [Key]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public int ComponentTypeId { get; set; }
    public int ComponentManufacturerId { get; set; }
    
    [ForeignKey(nameof(ComponentTypeId))]
    public ComponentType ComponentType { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentManufacturerId))]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    public ICollection<PCComponent> PCComponent { get; set; } = [];
}