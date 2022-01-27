using System.Threading.Tasks;
using ProEventos.Domain;


namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersistence
    {
        
        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);

        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);

        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);


    }
}