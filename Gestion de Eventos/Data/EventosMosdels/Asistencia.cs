using System;
using System.Collections.Generic;

namespace Gestion_de_Eventos.EventosMosdels;

public partial class Asistencia
{
    public int IdAsistencia { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEvento { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
