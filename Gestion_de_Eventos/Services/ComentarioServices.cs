using Gestion_de_Eventos.Data;

namespace Gestion_de_Eventos.Services;

public class ComentarioServices
{
    private readonly EventosContext _context;

    public ComentarioServices(EventosContext context)
    {
        this._context= context;
    }
}