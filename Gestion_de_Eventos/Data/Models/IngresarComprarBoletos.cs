using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_Eventos.Data.Models;

public class IngresarComprarBoletos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCompra { get; set; }
    public int IdEvento { get; set; }
    public int IdUsuario { get; set; }
    public int CantidadBoletos { get; set; }
    public string MetodoDePago { get; set; }

    [ForeignKey("IdEvento")]
    public Eventos Evento {get; set;}
    [ForeignKey("IdUsuario")]
    public Usuarios Usuario {get; set;}
}