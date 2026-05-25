using CodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using tut_8.DTOs;
using tut_8.Entities_;
using tut_8.Exceptions_;

namespace tut_8.Services;

public class DbService : IDbService
{
    
private readonly AppDbContext _context;

    public DbService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PCResponseDto>> GetAllAsync()
    {
        var res = await _context.PCs
            .Select(pc => new PCResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
        return res;
    }

    public async Task<IEnumerable<PCComponentResponseDto>?> GetComponentsAsync(int id)
    {
        

        var res = await _context.PCComponents
            .Where(pc => pc.PCId == id)
            .Select(pc => new PCComponentResponseDto
            {
                ComponentCode = pc.ComponentCode,
                Name = pc.Component.Name,
                Description = pc.Component.Description,
                Amount = pc.Amount
            })
            .ToListAsync();
        
            if (res == null) 
            {
                throw new NotFoundException();
            }
            return res;
    }

    public async Task<PCResponseDto> CreateAsync(CreatePCDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();

        return new PCResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task UpdateAsync(int id, UpdatePCDto dto)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(e => e.Id == id);
        if (pc == null)
        {
            throw new NotFoundException();
        }

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(int id)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(e => e.Id == id);
        if (pc == null) 
        {
            throw new NotFoundException();
        }

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();

        
    }

}