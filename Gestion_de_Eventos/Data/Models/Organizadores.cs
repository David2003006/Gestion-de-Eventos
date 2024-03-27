using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_Eventos.Data.Models;

public class Organizadores 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdOrganizador {get; set;}

    public string Nombre {get; set;}

    public string Apellido {get; set;}

    public string NombreEmpresa {get; set;}
    [EmailAddress]
    public string Correo {get; set;}
}