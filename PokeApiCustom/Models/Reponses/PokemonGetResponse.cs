using System.Collections.Generic;

namespace PokeApiCustom.Models.Reponses {
    public class PokemonGetResponse {
        public List<Pokemon> Results;

        public PokemonGetResponse() {
            Results = new List<Pokemon>();
        }
    }
}