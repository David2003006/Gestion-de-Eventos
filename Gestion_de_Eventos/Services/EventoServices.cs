
using Gestion_de_Eventos.Data;
using Gestion_de_Eventos.Data.DTOS;
using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Services;

   public class  EventoServices 
   {
        private readonly EventosContext _context;

        public EventoServices(EventosContext context)
        {
            this._context= context;
        }

        public async Task<IEnumerable<Eventos>> GetAll()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task <Eventos> GetById( int id)
        {
            return await _context.Eventos.FindAsync(id);
        }

        public async Task<Eventos> create (EventoDTO newEventoDTO)
        {
            var newEvento = new Eventos();

            newEvento.Nombre= newEventoDTO.Nombre;
            newEvento.Descripcion = newEventoDTO.Direccion;
            newEvento.Fecha = newEventoDTO.Fecha;
            newEvento.Hora = newEventoDTO.Hora;
            newEvento.Direccion = newEventoDTO.Direccion;
            newEvento.BoletosDisponibles= newEventoDTO.BoletosDisponibles;
            newEvento.Costo = newEventoDTO.Costo;

            _context.Eventos.Add(newEvento);
            await _context.SaveChangesAsync();

            return newEvento;
        } 

        public async Task<Eventos?> Edit (int id, EventoDTO evento)
        {
            var encontrado = await GetById(id);

            if(encontrado != null)
            {
                encontrado.Nombre= evento.Nombre;
                encontrado.Descripcion = evento.Direccion;
                encontrado.Fecha = evento.Fecha;
                encontrado.Hora = evento.Hora;
                encontrado.Direccion = evento.Direccion;
                encontrado.BoletosDisponibles= evento.BoletosDisponibles;
                encontrado.Costo = evento.Costo;
                _context.Eventos.Update(encontrado);
                await _context.SaveChangesAsync();
                return encontrado;
            }else
            {
                return null;
            }
        }

   }
