namespace Gestion_de_Eventos.Data.DTOS;

public class IngresarComprarBoletoDTO
{
     public int IdEvento { get; set; }

    public int IdUsuario { get; set; }

    public int CantidadBoletos { get; set; }

    public string MetodoDePago { get; set; }

    public int IdCompra { get; set; }

}