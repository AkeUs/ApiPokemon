namespace PokeApiCustom.Services.Requests {
    
    public class PokeApiPokemonListRequest {
        private const string Url = "/api/v2/pokemon?limit";
        private readonly int _limit;

        public PokeApiPokemonListRequest() {
            _limit = 151;
        }

        public PokeApiPokemonListRequest(int limit) {
            _limit = limit;
        }

        public string GetUrlRequest() {
            return $"{Url}={_limit}";
        }

    }
}