using tut_8.DTOs;

namespace tut_8.Services;

public interface IDbService
{
    
    Task<IEnumerable<PCResponseDto>> GetAllAsync();
    Task<IEnumerable<PCComponentResponseDto>?> GetComponentsAsync(int id);
    Task<PCResponseDto> CreateAsync(CreatePCDto dto);
    Task UpdateAsync(int id, UpdatePCDto dto);
    Task DeleteAsync(int id);

}