using System;
using System.Collections.Generic;

namespace Gestion_de_Eventos.EventosMosdels;

public partial class Evento
{
    public int IdEvento { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Direccion { get; set; }

    public int? CapacidadMax { get; set; }

    public double? Costo { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<EventosFavorito> EventosFavoritos { get; set; } = new List<EventosFavorito>();
}
