

using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class SeguirEventoCController : ControllerBase
{
    private readonly SeguirEventosServices _services;

    public SeguirEventoCController (SeguirEventosServices services)
    {
        this._services= services;
    }

    [HttpGet]
    public async Task<IEnumerable<SeguirEventos>> GetAll()
    {
        return  await _services.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<SeguirEventos> GetById(int id)
    {
        return  await _services.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SeguirEventoDTO seguir)
    {
        var resultado = await _services.Create(seguir);

        if(resultado is not null)
            return  CreatedAtAction(nameof(GetById), new { id = resultado.IdSeguirEvento }, resultado);
        else
            return BadRequest("Evento no disponible");
    }

}