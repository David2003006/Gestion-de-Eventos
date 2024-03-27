using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Data.Models;

public class Usuarios 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUsuario {get; set; }
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public DateTime FechaNacimiento {get; set;}
    public string NombreDeUsuario {get; set;}
    public string MetodoDePago {get; set;}
    [EmailAddress]
    public string Correo {get; set;} 
 }