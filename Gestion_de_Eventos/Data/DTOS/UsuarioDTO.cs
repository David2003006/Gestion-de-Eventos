namespace Gestion_de_Eventos.Data.DTOS;

public class UsuarioDTO
{
    public int IdUsuario {get; set; }
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public DateTime FechaNacimiento {get; set;}
    public string NombreDeUsuario {get; set;}
    public string MetodoDePago {get; set;}
    public string Correo {get; set;} 
}