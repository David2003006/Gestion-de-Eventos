

using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Services;

public class HistorialServices
{
    private readonly EventosContext _context;

    public HistorialServices(EventosContext context)
    {
        this._context= context;
    }

    public async Task<IEnumerable<Historial>> GetAll()
    {
        return await _context.Historial.ToListAsync();
    }

    public async Task<Historial> GetById(int id)
    {
        return await _context.Historial.FindAsync(id);
    }

public async Task<Historial> Create(HistorialDTO historial)
{
    var compra = await _context.IngresarComprarBoletos.FirstOrDefaultAsync(c => c.IdCompra == historial.IdCompra);
    
    if (compra != null && compra.Evento != null && compra.Evento.Fecha != null)
    {
        var fecha = DateOnly.FromDateTime(DateTime.Now);

        if (fecha > compra.Evento.Fecha)
        {
            var newHistorial = new Historial();

            newHistorial.IdCompra = historial.IdCompra;
            newHistorial.Asistio = historial.Asistio;
            _context.Historial.Add(newHistorial);
            await _context.SaveChangesAsync();
            return newHistorial;
        }
        else
        {
            return null;
        }
    }
    else
    {
        return null;
    }
}
}