using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_Eventos.Data.Models;

public class Seguidores 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdSeguidor {get; set;}

    [ForeignKey("IdOganizador")]
    public int IdOrganizador {get; set;}

    [ForeignKey("IdUsuario")]
    public int IdUsuario {get; set;}

     public Usuarios Usuario {get; set;}

     public Organizadores Organizador {get; set;}
}