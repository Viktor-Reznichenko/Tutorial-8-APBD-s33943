using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tut_8.Entities_;


[Table("PCs")]

public class PC
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public double Weight { get; set; }

    public int Warranty { get; set; }
    
    [Column(TypeName = "date")]
    public DateTime CreatedAt { get; set; }
    
    
    public int Stock { get; set; }

    public ICollection<PCComponent> PCComponent { get; set; } = [];
}