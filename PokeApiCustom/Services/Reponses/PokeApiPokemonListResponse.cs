using System.Collections.Generic;

namespace PokeApiCustom.Services.Reponses {
    
    public class PokeApiPokemonListResponse {
        public List<PokemonDetailsResponse> Results { get; set; }

        public PokeApiPokemonListResponse() {
            Results = new List<PokemonDetailsResponse>();
        }

        public class PokemonDetailsResponse {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}