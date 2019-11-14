using System.Threading.Tasks;
using PokeApiCustom.Services.Reponses;

namespace PokeApiCustom.Services {
    public interface IPokeApiService {

        Task<PokeApiPokemonListResponse> GetPokemonListAsync();
        Task<PokeApiPokemonDetailResponse> GetPokemonDetailAsync(string name);

    }
}