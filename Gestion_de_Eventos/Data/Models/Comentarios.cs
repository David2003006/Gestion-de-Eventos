using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_Eventos.Data.Models;

public class Comentarios 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdComentario {get; set;}

    public int IdUsuario {get; set;}

    public int IdOrganizador {get; set;}

    public string Comentario {get; set;}

    [ForeignKey("IdUsuario")]
    public Usuarios Usuario {get; set;}

    [ForeignKey("IdOrganizador")]
    public Organizadores Organizador {get; set;}

}