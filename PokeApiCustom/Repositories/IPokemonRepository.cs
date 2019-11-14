using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApiCustom.Models;

namespace PokeApiCustom.Repositories {
    
    public interface IPokemonRepository {
        Task<List<Pokemon>> GetPokemonList();
    }
}