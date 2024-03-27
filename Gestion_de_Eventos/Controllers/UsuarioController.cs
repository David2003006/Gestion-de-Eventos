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
    public async Task<Usuarios?> GetById(int id)
    {
        var found = await _services.GetById(id);

        if(found is null)
         NotFound();
        
        return found;
    }

    [HttpPost]
    public async Task<IActionResult> create(UsuarioDTO usuario)
    {
        var newUsuario = await _services.create(usuario);
        return CreatedAtAction(nameof(GetById), new{id= newUsuario.IdUsuario}, newUsuario);
    }
}