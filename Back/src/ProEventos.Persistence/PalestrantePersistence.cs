using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;
        public PalestrantePersistence(ProEventosContext context)
        {
            this._context = context;

        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos = false)
        {
                        IQueryable<Palestrante> query = _context.Palestrantes
                            .Include(p => p.RedesSociais);

                        if(includeEventos){
                            query = query
                                .Include(p => p.PalestrantesEventos)
                                .ThenInclude(pe =>pe.Evento);
                        }

            query = query.AsNoTracking().OrderBy(p=> p.Id).Where(p => p.Nome.ToLower().Contains(p.Nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
                        IQueryable<Palestrante> query = _context.Palestrantes
                            .Include(p => p.RedesSociais);

                        if(includeEventos){
                            query = query
                                .Include(p => p.PalestrantesEventos)
                                .ThenInclude(pe =>pe.Evento);
                        }

            query = query.AsNoTracking().OrderBy(p=> p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
                        IQueryable<Palestrante> query = _context.Palestrantes
                            .Include(p => p.RedesSociais);

                        if(includeEventos){
                            query = query
                                .Include(p => p.PalestrantesEventos)
                                .ThenInclude(pe =>pe.Evento);
                        }

            query = query.AsNoTracking().OrderBy(p=> p.Id).Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}