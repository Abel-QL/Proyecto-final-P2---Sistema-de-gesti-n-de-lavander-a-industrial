using Microsoft.AspNetCore.Mvc;
using SGL.Aplication.Dtos.ServicioDto;
using SGL.Aplication.Services.Interfaces;

namespace SGL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicioController : ControllerBase
{
    private readonly IServicioService _service;

    public ServicioController(IServicioService service)
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
            return StatusCode(500, new { mensaje = "Error al obtener servicios", detalle = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(new { mensaje = $"Servicio {id} no encontrado" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener servicio", detalle = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ServicioCreateDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al crear servicio", detalle = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ServicioUpdateDto dto)
    {
        try
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result == null) return NotFound(new { mensaje = $"Servicio {id} no encontrado" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al actualizar servicio", detalle = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound(new { mensaje = $"Servicio {id} no encontrado" });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al eliminar servicio", detalle = ex.Message });
        }
    }
}