using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PokeApiCustom.Models;
using PokeApiCustom.Services;
using PokeApiCustom.Services.Reponses;

namespace PokeApiCustom.Repositories {
    public class PokemonRepository : IPokemonRepository {

        private readonly IPokeApiService _pokeApiService;
        private readonly IDistributedCache _cache;

        private const int TimeExpiration = 10;
        private const string KeyPokemonList = "PokemonList";

        public PokemonRepository(IPokeApiService pokeApiService, IDistributedCache cache) {
            _pokeApiService = pokeApiService;
            _cache = cache;
        }
        
        public async Task<List<Pokemon>> GetPokemonList() {
            var dataCache = await _cache.GetStringAsync(KeyPokemonList);

            if (!string.IsNullOrWhiteSpace(dataCache)) return JsonConvert.DeserializeObject<List<Pokemon>>(dataCache);
            
            PokeApiPokemonListResponse result = await _pokeApiService.GetPokemonListAsync();
                
            if (result is null) return null;
            
            var pokemonList = new List<Pokemon>();
            
            foreach (var item in result.Results) {
                PokeApiPokemonDetailResponse detailResponse = await _pokeApiService.GetPokemonDetailAsync(item.Name);

                if (detailResponse != null) {
                    pokemonList.Add(new Pokemon {
                        Id = detailResponse.Id,
                        Name = detailResponse.Name,
                        UrlImage = detailResponse.Sprites.front_default,
                        TypeOne = detailResponse.Types.Find(t => t.Slot == 1).Type.Name,
                        TypeTwo = detailResponse.Types.Exists(t => t.Slot == 2)
                            ? detailResponse.Types.Find(t => t.Slot == 2).Type.Name
                            : ""
                    });
                }
            }
                
            // Se guarda la respuesta en cache
            var cacheSettings = new DistributedCacheEntryOptions();
            cacheSettings.SetAbsoluteExpiration(TimeSpan.FromMinutes(TimeExpiration));
            var itemJson = JsonConvert.SerializeObject(pokemonList);
            await _cache.SetStringAsync(KeyPokemonList, itemJson, cacheSettings);
            return pokemonList;
        }

    }
}