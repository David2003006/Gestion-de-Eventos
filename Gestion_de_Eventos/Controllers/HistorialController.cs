using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class HistorialController : ControllerBase
{
    private HistorialServices _services;

    public HistorialController (HistorialServices services)
    {
        this._services= services;
    }

    [HttpGet]
    public async Task<IEnumerable<Historial>> GetAll()
    {
        return await _services.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Historial> GetById(int id)
    {
        return await _services.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Create(HistorialDTO historial)
    {
        var newHistorial = await _services.Create(historial);

        if(newHistorial is not null)
            return CreatedAtAction(nameof(GetById), new { id = newHistorial.IdHistorial }, newHistorial);
        else
            return BadRequest("El evento todavia no se a realizado");
    } 

}