using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_Eventos.Data.Models;

public class Eventos
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvento {get; set;}
        public int IdOrganizador {get; set;}

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateOnly? Fecha { get; set; }

        public TimeOnly? Hora { get; set; }

        public string Direccion { get; set; }

        public int BoletosDisponibles { get; set; }

        public double Costo { get; set; }

         public List<Eventos> ListaEventos { get; set; }

        [ForeignKey("IdOganizador")]
        public Eventos Evento {get; set; }
        public string Ubicacion { get; internal set; }

    public Eventos()
    {
        ListaEventos = new List<Eventos>();
    }
}