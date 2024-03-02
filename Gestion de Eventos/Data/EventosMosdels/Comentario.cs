using System;
using System.Collections.Generic;

namespace Gestion_de_Eventos.EventosMosdels;

public partial class Comentario
{
    public int IdComentario { get; set; }

    public int IdUsuario { get; set; }

    public int IdOrganizador { get; set; }

    public string? Comentario1 { get; set; }

    public virtual Organizadore IdOrganizadorNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
