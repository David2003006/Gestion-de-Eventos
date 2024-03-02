using System;
using System.Collections.Generic;

namespace Gestion_de_Eventos.EventosMosdels;

public partial class InicioDeSecion
{
    public int IdInicioSecion { get; set; }

    public int? UsuarioId { get; set; }

    public int? OrganizadorId { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public bool? Activo { get; set; }

    public virtual Organizadore? Organizador { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
