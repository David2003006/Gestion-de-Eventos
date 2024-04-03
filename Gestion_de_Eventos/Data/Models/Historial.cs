

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_Eventos.Data.Models;

public class Historial
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdHistorial {get; set;}

    public int IdCompra {get; set;}

    public bool Asistio {get; set;}= false;

    [ForeignKey("IdCompra")]
    public IngresarComprarBoletos Compra {get; set;}
}