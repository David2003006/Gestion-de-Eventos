using System;
using System.Collections.Generic;

namespace Gestion_de_Eventos.EventosMosdels;

public partial class HistorialUsurario
{
    public int IdUsuario { get; set; }

    public int IdEvento { get; set; }

    public int IdAsistencia { get; set; }

    public virtual Asistencia IdAsistenciaNavigation { get; set; } = null!;

    public virtual Evento IdEventoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
