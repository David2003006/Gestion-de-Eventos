using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Services;

public class OrganizadorServices
{
    private readonly EventosContext _context;

    public OrganizadorServices(EventosContext context)
    {
        this._context= context;
    }

    public async Task<IEnumerable<Organizadores>> GetAll()
    {
        return await _context.Organizadores.ToListAsync();
    }

    public async Task<Organizadores> GetById(int id)
    {
        return await _context.Organizadores.FindAsync(id);
    }

    public async Task<Organizadores> Create(OrganizadorDTO organizador)
    {
        var newOrganizador = new Organizadores();

        newOrganizador.Nombre= organizador.Nombre;
        newOrganizador.Apellido= organizador.Apellido;
        newOrganizador.NombreEmpresa = organizador.NombreEmpresa;
        newOrganizador.Correo= organizador.Correo;

        _context.Organizadores.Add(newOrganizador);
        await _context.SaveChangesAsync();

        return newOrganizador;
    }


}