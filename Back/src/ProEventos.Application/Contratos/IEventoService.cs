using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
         Task<Evento> AddEvento(Evento model );
         Task<Evento> UpdateEvento(int eventoId, Evento model );
         Task<bool> DeleteEvento(int eventoId );

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);

        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
    }
}