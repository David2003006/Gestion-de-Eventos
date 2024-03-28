using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class OrganizadoresController: ControllerBase
{
    private readonly OrganizadorServices _services;

    public OrganizadoresController(OrganizadorServices services)
    {
        this._services= services;
    }

    [HttpGet]
    public async Task<IEnumerable<Organizadores>> Get()
    {
        return await _services.GetAll();
    }

    
    [HttpGet("{id}")]
    public async Task<Organizadores> GetById(int id)
    {
        return await _services.GetById(id);
    }

    [HttpPost]
    public async Task<ActionResult<Organizadores>> Create (OrganizadorDTO organizador)
    {
        var newOrganizador= await _services.Create(organizador);
        return CreatedAtAction(nameof(GetById), new{id= newOrganizador.IdOganizador}, newOrganizador); ;
    }

}