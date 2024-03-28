using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Gestion_de_Eventos.Services;


public class IngresarComprarBoletoServices 
{
    private readonly EventosContext _context;

    public IngresarComprarBoletoServices (EventosContext context)
    {
        this._context= context;
    } 

    public async Task<IngresarComprarBoletos>  Create(IngresarComprarBoletoDTO boleto)
    {
        var newBoleto = new IngresarComprarBoletos();

        newBoleto.IdEvento= boleto.IdEvento;
        newBoleto.IdUsuario= boleto.IdUsuario;
        newBoleto.CantidadBoletos = boleto.CantidadBoletos;
        newBoleto.MetodoDePago = boleto.MetodoDePago;

        bool resultadoActualizacion = await ActualizarCantidad(newBoleto.IdEvento, newBoleto.CantidadBoletos);
        if(resultadoActualizacion)
        {
            _context.IngresarComprarBoletos.Add(newBoleto);
            await _context.SaveChangesAsync();
            return newBoleto;
        }
        else 
            return null ;
        
    }


    public async Task<bool>  ActualizarCantidad (int? IdEvento, int CantidadDeBoletos)
    {
        var encontrado= await _context.Eventos.FindAsync(IdEvento);

        if(encontrado != null && encontrado.BoletosDisponibles != 0)
        {
            encontrado.BoletosDisponibles -= CantidadDeBoletos;
             _context.Eventos.Update(encontrado); 
            await  _context.SaveChangesAsync();
            return true;
        }else
        {
                return false;
        }
            
    }
}