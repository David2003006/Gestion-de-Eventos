using System.Globalization;
using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Services;

public class UsuarioServices
{

    private readonly EventosContext _context;

    public UsuarioServices(EventosContext context)
    {
        this._context= context;
    }

     public async Task<IEnumerable<Usuarios>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task <Usuarios> GetById( int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public async Task<Eventos?> GetByValor(string?  valor)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        var fecha = await ParseFecha(valor); 
        if(fecha.HasValue)
        {
        var posibleFecha = DateOnly.Parse(valor);
        var eventosFiltrados = await _context.Eventos.FirstOrDefaultAsync(e =>  e.Fecha == posibleFecha);
        return eventosFiltrados;
        }else
        {
            var eventosFiltrados = await _context.Eventos.FirstOrDefaultAsync(e => e.Nombre == valor || e.Direccion == valor);
            return eventosFiltrados;
        }
    }

    public async Task<Usuarios> create(UsuarioDTO usuario)
        {
            var newUsuario = new Usuarios();

            newUsuario.Nombre= usuario.Nombre;
            newUsuario.Apellido= usuario.Apellido;
            newUsuario.FechaNacimiento = usuario.FechaNacimiento;
            newUsuario.NombreDeUsuario = usuario.NombreDeUsuario;
            newUsuario.MetodoDePago= usuario.MetodoDePago;
            newUsuario.Correo = usuario.Correo;

            _context.Usuarios.Add(newUsuario);
            await _context.SaveChangesAsync();

            return newUsuario;
        }

    public async Task<DateOnly?> ParseFecha(string? valor)
{
    if (DateOnly.TryParseExact(valor, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly parsedFecha))
    {
        return  await Task.FromResult<DateOnly?>(parsedFecha);
    }
    else
    {
        // Si la cadena no tiene el formato deseado, retorna null o maneja el error según lo necesites
        return await Task.FromResult<DateOnly?>(null);
    }
}
}

