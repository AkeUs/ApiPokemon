namespace PokeApiCustom.Services.Requests {
    
    public class PokeApiPokemonDetailRequest {
        private const string Url = "/api/v2/pokemon";
        private readonly string _name;
        
        public PokeApiPokemonDetailRequest(string name) {
            _name = name;
        }
        
        public string GetUrlRequest() {
            return $"{Url}/{_name}";
        }
    }
}