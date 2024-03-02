using System;
using System.Collections.Generic;

namespace Gestion_de_Eventos.EventosMosdels;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? NombreUsuario { get; set; }

    public string? MetodoDePago { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<EventosFavorito> EventosFavoritos { get; set; } = new List<EventosFavorito>();

    public virtual ICollection<InicioDeSecion> InicioDeSecions { get; set; } = new List<InicioDeSecion>();

    public virtual ICollection<Preguntum> Pregunta { get; set; } = new List<Preguntum>();

    public virtual ICollection<SeguirOrganizadore> SeguirOrganizadores { get; set; } = new List<SeguirOrganizadore>();
}
