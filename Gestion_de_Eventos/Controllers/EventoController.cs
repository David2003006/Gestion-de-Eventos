using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class EventoController : ControllerBase
{

    private readonly EventoServices _services;

    public EventoController(EventoServices services)
    {
        this._services= services;
    }

    [HttpGet]
    public async Task<IEnumerable<Eventos>> Get()
    {
        return await _services.GetAll();
    }

     [HttpGet("{id}")]
    public async Task<ActionResult<Eventos>> GetById(int id)
    {
        var found= await _services.GetById(id);

        if(found is null)
            return NotFound();

        return found;
    }

    [HttpPost]
    public async Task<IActionResult> create(EventoDTO evento)
    {
        var newEvento = await _services.create(evento);
        return CreatedAtAction(nameof(GetById), new{id= newEvento.IdEvento}, newEvento); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, EventoDTO evento)
    {
        var editEvento = await _services.Edit(id, evento);

        if(editEvento != null)
        {
            return CreatedAtAction(nameof(GetById), new{id= editEvento.IdEvento}, editEvento);
        }else
        {
            return BadRequest("No se encontro el evento a actualizar");
        }
    }

    

}