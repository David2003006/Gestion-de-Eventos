using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class ComentarioController: ControllerBase
{
    private readonly ComentarioServices _services;

    public ComentarioController(ComentarioServices services)
    {
        this._services= services;
    }

    [HttpGet]
    public async Task<IEnumerable<Comentarios>> Get()
    {
        return await _services.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Comentarios> GetById(int id)
    {
        return await _services.GetById(id);
    }

    [HttpPost]
    public async Task<ActionResult> Create (ComentarioDTO comentario)
    {
        var newComentario = await _services.Create(comentario);
        return CreatedAtAction(nameof(GetById), new{id= newComentario.IdComentario}, newComentario);
    }
    

}