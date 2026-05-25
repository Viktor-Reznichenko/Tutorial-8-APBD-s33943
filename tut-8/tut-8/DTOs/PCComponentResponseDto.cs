namespace tut_8.DTOs;

public class PCComponentResponseDto
{
    
    public string ComponentCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Amount { get; set; }
}
