namespace Gestion_de_Eventos.Data.DTOS;

public class EventoDTO 
{

        public int IdOrganizador {get; set;}

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateOnly? Fecha { get; set; }

        public TimeOnly? Hora { get; set; }

        public string Direccion { get; set; }

        public int BoletosDisponibles { get; set; }

        public double Costo { get; set; }
}