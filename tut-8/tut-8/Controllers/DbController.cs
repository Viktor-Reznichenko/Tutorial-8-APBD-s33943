using Microsoft.AspNetCore.Mvc;
using tut_8.DTOs;
using tut_8.Exceptions_;
using tut_8.Services;

namespace tut_8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DbController : ControllerBase
{
    private readonly IDbService _service;

    public DbController(IDbService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var result = await _service.GetComponentsAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePCDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetComponents),
            new { id = result.Id },
            result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePCDto dto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();   
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
