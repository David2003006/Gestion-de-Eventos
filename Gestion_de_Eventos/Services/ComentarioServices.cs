using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Services;

public class ComentarioServices
{
    private readonly EventosContext _context;

    public ComentarioServices(EventosContext context)
    {
        this._context= context;
    }

    public async  Task<IEnumerable<Comentarios>> GetAll()
    {
        return await _context.Comentarios.ToArrayAsync();
    }

    public async Task<Comentarios> GetById(int id)
    {
        return await _context.Comentarios.FindAsync(id);
    }

    public async Task<Comentarios> Create (ComentarioDTO comentario)
    {
        var newComentario = new Comentarios();

        newComentario.IdUsuario = comentario.IdUsuario;
        newComentario.IdOrganizador= comentario.IdOrganizador;
        newComentario.Comentario= comentario.Comentario;

        _context.Comentarios.Add(newComentario);
        await _context.SaveChangesAsync();

        return newComentario;
    }


}