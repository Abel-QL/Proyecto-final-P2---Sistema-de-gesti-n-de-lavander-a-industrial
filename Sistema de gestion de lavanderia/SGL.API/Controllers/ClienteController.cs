using Microsoft.AspNetCore.Mvc;
using SGL.Aplication.Dtos.ClienteDtos;
using SGL.Aplication.Services.Interfaces;

namespace SGL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _service;

    public ClienteController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener clientes", detalle = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(new { mensaje = $"Cliente {id} no encontrado" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener cliente", detalle = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClienteCreateDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al crear cliente", detalle = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClienteUpdateDto dto)
    {
        try
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result == null) return NotFound(new { mensaje = $"Cliente {id} no encontrado" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al actualizar cliente", detalle = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound(new { mensaje = $"Cliente {id} no encontrado" });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al eliminar cliente", detalle = ex.Message });
        }
    }
}