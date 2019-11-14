using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeApiCustom.Services.Reponses;
using PokeApiCustom.Services.Requests;

namespace PokeApiCustom.Services {
    
    public class PokeApiService : IPokeApiService {
        
        private const string PokeApiClient = "PokeApiClient";
        private readonly IHttpClientFactory _clientFactory;

        public PokeApiService(IHttpClientFactory httpClient) {
            _clientFactory = httpClient;
        }

        public async Task<PokeApiPokemonListResponse> GetPokemonListAsync() {
            var pokemonListRequest = new PokeApiPokemonListRequest();
            var request = new HttpRequestMessage(HttpMethod.Get, pokemonListRequest.GetUrlRequest());
            var client = _clientFactory.CreateClient(PokeApiClient);
            var response = await client.SendAsync(request);
            if(!response.IsSuccessStatusCode) return null;
            var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PokeApiPokemonListResponse>(jsonResult);
        }
        
        public async Task<PokeApiPokemonDetailResponse> GetPokemonDetailAsync(string name) {
            var pokemonDetailRequest = new PokeApiPokemonDetailRequest(name);
            var request = new HttpRequestMessage(HttpMethod.Get, pokemonDetailRequest.GetUrlRequest());
            var client = _clientFactory.CreateClient(PokeApiClient);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode) return null;
            var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PokeApiPokemonDetailResponse>(jsonResult);
        }
        
    }
}