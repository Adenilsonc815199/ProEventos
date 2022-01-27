using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventosContext _context;
        public EventoPersistence(ProEventosContext context)
        {
            this._context = context;
           // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                            .Include(e => e.Lote)
                            .Include(e => e.RedesSociais);

                        if(includePalestrantes){
                            query = query
                                .Include(e => e.PalestrantesEventos)
                                .ThenInclude(pe =>pe.Palestrante);
                        }

            query = query.AsNoTracking().OrderBy(e=> e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                            .Include(e => e.Lote)
                            .Include(e => e.RedesSociais);

                        if(includePalestrantes){
                            query = query
                                .Include(e => e.PalestrantesEventos)
                                .ThenInclude(pe =>pe.Palestrante);
                        }

            query = query.AsNoTracking().OrderBy(e=> e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                            .Include(e => e.Lote)
                            .Include(e => e.RedesSociais);

                        if(includePalestrantes){
                            query = query
                                .Include(e => e.PalestrantesEventos)
                                .ThenInclude(pe =>pe.Palestrante);
                        }

            query = query.AsNoTracking().OrderBy(e=> e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}