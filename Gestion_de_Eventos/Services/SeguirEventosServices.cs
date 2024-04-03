using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Gestion_de_Eventos.Services;

public class SeguirEventosServices
{
    private readonly EventosContext _context;

    public SeguirEventosServices(EventosContext context)
    {
        this._context= context;
    }

    public async Task<IEnumerable<SeguirEventos>> GetAll()
    {
        return await _context.SeguirEventos.ToListAsync();
    }

    public async Task<SeguirEventos> GetById(int id)
    {
        return await  _context.SeguirEventos.FindAsync(id);
    }

      public async Task<SeguirEventos> Create(SeguirEventoDTO seguir)
    {
        var newSeguir= new SeguirEventos();

        newSeguir.IdEvento= seguir.IdEvento;
        newSeguir.IdUsuario= seguir.IdUsuario;

         _context.SeguirEventos.Add(newSeguir);
         await _context.SaveChangesAsync();

         return newSeguir;
    }
}