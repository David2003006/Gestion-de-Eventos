

using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Services;

public class SeguidoresServices 
{
    private readonly EventosContext _context;

    public SeguidoresServices (EventosContext  context)
    {
        this._context= context;
    }

    public async Task<IEnumerable<Seguidores>> GetAll()
    {
        return await _context.Seguidores.ToListAsync();
    }

     public async Task<Seguidores> GetById(int id)
    {
        return await _context.Seguidores.FindAsync(id);
    }

    public async Task<Seguidores> Create(SeguidoresDTO seguidor)
    {
        var newSeguidor = new Seguidores();

        newSeguidor.IdOrganizador = seguidor.IdOrganizador;
        newSeguidor.IdUsuario = seguidor.IdUsuario;

        _context.Seguidores.Add(newSeguidor);
        await _context.SaveChangesAsync();
        return newSeguidor;
    }
}