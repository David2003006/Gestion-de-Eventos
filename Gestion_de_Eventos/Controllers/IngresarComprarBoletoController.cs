using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Eventos.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class IngresarComprarBoletoController : ControllerBase
{
    private readonly IngresarComprarBoletoServices _services; 

    public IngresarComprarBoletoController (IngresarComprarBoletoServices services)
    {
        this._services = services;
    }

    [HttpPost]
    public async Task<IActionResult> Create(IngresarComprarBoletoDTO boletoDTO  )
    {
        var resultado = await _services.Create(boletoDTO);

        if(resultado != null)
            return Ok();
        else 
            return BadRequest("Evento no encontrado o no hay boletos para el");
    }

}