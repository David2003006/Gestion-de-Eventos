using Gestion_de_Eventos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Data;

public class EventosContext : DbContext
{

    public EventosContext(DbContextOptions<EventosContext> options): base(options){}

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Organizadores> Organizadores { get; set; }
    public DbSet<Eventos> Eventos { get; set; }
    public DbSet<IngresarComprarBoletos> IngresarComprarBoletos { get; set; }

    public DbSet<Comentarios> Comentarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuarios>()
            .HasKey(u => u.IdUsuario);
            
        modelBuilder.Entity<Eventos>().HasKey(u => u.IdEvento);
        
         // Define UsuarioId como la clave primaria
    }
}