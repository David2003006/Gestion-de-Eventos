using System;
using System.Collections.Generic;

namespace Gestion_de_Eventos.EventosMosdels;

public partial class SeguirOrganizadore
{
    public int IdSeguidor { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdOrganizador { get; set; }

    public virtual Organizadore? IdOrganizadorNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
