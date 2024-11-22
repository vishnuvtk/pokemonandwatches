using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonNWatches.Models;

namespace PokemonNWatches.Interfaces
{
    public interface IBuildService
    {
        Task<IEnumerable<BuildDTO>> ListBuilds();
        Task<BuildDTO> FindBuilds(int id);
        Task CreateBuilds(BuildDTO buildDto);
        Task<bool> UpdateBuilds(BuildDTO buildDto);
        Task<bool> DeleteBuilds(int id);

    }
}
