using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApiCustom.Models;
using PokeApiCustom.Repositories;
using PokeApiCustom.Services;
using PokeApiCustom.Services.Reponses;

namespace PokeApiCustom.Tests.Fakes {
    public class PokemonRepositoryFake : IPokemonRepository {
        
        public async Task<List<Pokemon>> GetPokemonList() {
            var pokemonList = new List<Pokemon>();
            
            pokemonList.Add(new Pokemon {
                Id = 1,
                Name = "",
                TypeOne = "",
                TypeTwo = "",
                UrlImage = ""
            });
            
            return await Task.FromResult(pokemonList);
        }
    }
}