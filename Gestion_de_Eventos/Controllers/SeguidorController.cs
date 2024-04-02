

using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;

[ApiController]
[Route("api/Seguidor")]
public class seguidorController:  ControllerBase
{
    private readonly SeguidoresServices _services;

    public seguidorController(SeguidoresServices services)
    {
        this._services= services;
    }

    [HttpGet]
    public async Task<IEnumerable<Seguidores>> GetAll()
    {
        return await _services.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Seguidores> GetById(int id)
    {
        return await _services.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SeguidoresDTO seguidor) 
    {
        var newSeguidor = await _services.Create(seguidor);
        return CreatedAtAction(nameof(GetById), new { id = newSeguidor.IdSeguidor }, newSeguidor);
    }
}