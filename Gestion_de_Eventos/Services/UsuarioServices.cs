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

        public async Task <Usuarios?> GetById( int id)
        {
            return await _context.Usuarios.FindAsync(id);
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


}