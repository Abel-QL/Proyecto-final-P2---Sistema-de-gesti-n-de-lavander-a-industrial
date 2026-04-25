using Microsoft.AspNetCore.Mvc;
using SGL.Aplication.Dtos.FacturaDto;
using SGL.Aplication.Services.Interfaces;

namespace SGL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacturaController : ControllerBase
{
    private readonly IFacturaService _service;

    public FacturaController(IFacturaService service)
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
            return StatusCode(500, new { mensaje = "Error al obtener facturas", detalle = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(new { mensaje = $"Factura {id} no encontrada" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener factura", detalle = ex.Message });
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
            return StatusCode(500, new { mensaje = "Error al obtener facturas por cliente", detalle = ex.Message });
        }
    }

    [HttpGet("estado/{estadoPago}")]
    public async Task<IActionResult> GetPorEstado(string estadoPago)
    {
        try
        {
            var result = await _service.GetPorEstadoAsync(estadoPago);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al obtener facturas por estado", detalle = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FacturaCreateDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al crear factura", detalle = ex.Message });
        }
    }

    [HttpPatch("{id}/estado")]
    public async Task<IActionResult> UpdateEstado(int id, [FromBody] FacturaUpdateDto dto)
    {
        try
        {
            var result = await _service.UpdateEstadoAsync(id, dto);
            if (result == null) return NotFound(new { mensaje = $"Factura {id} no encontrada" });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al actualizar estado de factura", detalle = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound(new { mensaje = $"Factura {id} no encontrada" });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensaje = "Error al eliminar factura", detalle = ex.Message });
        }
    }
}

