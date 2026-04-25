using Microsoft.AspNetCore.Mvc;
using SGL.Aplication.Dtos.LoteDto;
using SGL.Aplication.Services.Interfaces;

namespace SGL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoteController : ControllerBase
{
    private readonly ILoteService _service;

    public LoteController(ILoteService service)
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
            return StatusCode(500, new { mensaje = "Error al obtener lotes", detalle = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(new { mensaje = $"Lote {id} no encontrado" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener lote", detalle = ex.Message });
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
            return StatusCode(500, new { mensaje = "Error al obtener lotes por estado", detalle = ex.Message });
        }
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> GetPorCliente(int clienteId)
    {
        try
        {
            var result = await _service.GetPorClienteAsync(clienteId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener lotes por cliente", detalle = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LoteCreateDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al crear lote", detalle = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] LoteUpdateDto dto)
    {
        try
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result == null) return NotFound(new { mensaje = $"Lote {id} no encontrado" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al actualizar lote", detalle = ex.Message });
        }
    }

    [HttpPatch("{id}/estado")]
    public async Task<IActionResult> CambiarEstado(int id, [FromBody] CambiarEstadoDto dto)
    {
        try
        {
            var result = await _service.CambiarEstadoAsync(id, dto.NuevoEstado, dto.OperadorId, dto.Observaciones);
            if (!result) return NotFound(new { mensaje = $"Lote {id} no encontrado" });
            return Ok(new { mensaje = "Estado actualizado correctamente" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al cambiar estado del lote", detalle = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound(new { mensaje = $"Lote {id} no encontrado" });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al eliminar lote", detalle = ex.Message });
        }
    }
}
