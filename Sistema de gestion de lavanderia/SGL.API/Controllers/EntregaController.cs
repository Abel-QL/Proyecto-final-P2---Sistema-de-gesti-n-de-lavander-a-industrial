using Microsoft.AspNetCore.Mvc;
using SGL.Aplication.Dtos.EntregaDto;
using SGL.Aplication.Services.Interfaces;

namespace SGL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EntregaController : ControllerBase
{
    private readonly IEntregaService _service;

    public EntregaController(IEntregaService service)
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
            return StatusCode(500, new { mensaje = "Error al obtener entregas", detalle = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(new { mensaje = $"Entrega {id} no encontrada" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener entrega", detalle = ex.Message });
        }
    }

    [HttpGet("conductor/{conductorId}")]
    public async Task<IActionResult> GetPorConductor(int conductorId)
    {
        try
        {
            var result = await _service.GetPorConductorAsync(conductorId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener entregas por conductor", detalle = ex.Message });
        }
    }

    [HttpGet("estado/{estado}")]
    public async Task<IActionResult> GetPorEstado(string estado)
    {
        try
        {
            var result = await _service.GetPorEstadoAsync(estado);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener entregas por estado", detalle = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EntregaCreateDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al crear entrega", detalle = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EntregaUpdateDto dto)
    {
        try
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result == null) return NotFound(new { mensaje = $"Entrega {id} no encontrada" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al actualizar entrega", detalle = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound(new { mensaje = $"Entrega {id} no encontrada" });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al eliminar entrega", detalle = ex.Message });
        }
    }
}