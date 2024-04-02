using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase 
{
    private readonly UsuarioServices _services;

    public UsuarioController (UsuarioServices services)
    {
        this._services = services;
    }

    [HttpGet]
    public async Task<IEnumerable<Usuarios>> Get()
    {
        return await _services.GetAll();
    }

    [HttpGet("{id}")]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public async Task<Usuarios?> GetById(int id)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        var found = await _services.GetById(id);

        if(found is null)
         NotFound();
        
        return found;
    }

    [HttpGet("valor/{valor}")]
    public async Task<ActionResult<Eventos>> GetByValor(string valor)
    {
        var encontrado= await  _services.GetByValor(valor);

        if(encontrado is not null)
            return encontrado;
        else
            return BadRequest("No Se encontro el evento");
    }


    [HttpPost]
    public async Task<IActionResult> create(UsuarioDTO usuario)
    {
        var newUsuario = await _services.create(usuario);
        return CreatedAtAction(nameof(GetById), new{id= newUsuario.IdUsuario}, newUsuario);
    }
}