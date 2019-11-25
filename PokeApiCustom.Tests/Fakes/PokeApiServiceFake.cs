using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApiCustom.Services;
using PokeApiCustom.Services.Reponses;

namespace PokeApiCustom.Tests.Fakes {
    
    public class PokeApiServiceFake : IPokeApiService {
        
        public async Task<PokeApiPokemonListResponse> GetPokemonListAsync() {
            var pokeApiPokemonListResponse = new PokeApiPokemonListResponse();
            
            pokeApiPokemonListResponse.Results.Add(new PokeApiPokemonListResponse.PokemonDetailsResponse {
                Name = "Bulbasaur",
                Url = "https://url.to.image"
            });
            
            pokeApiPokemonListResponse.Results.Add(new PokeApiPokemonListResponse.PokemonDetailsResponse {
                Name = "Ivysaur",
                Url = "https://url.to.image"
            });
            
            pokeApiPokemonListResponse.Results.Add(new PokeApiPokemonListResponse.PokemonDetailsResponse {
                Name = "Venusaur",
                Url = "https://url.to.image"
            });

            return await Task.FromResult(pokeApiPokemonListResponse);
        }

        public async Task<PokeApiPokemonDetailResponse> GetPokemonDetailAsync(string name) {
            var pokeApiPokemonDetailResponse = new PokeApiPokemonDetailResponse {
                Id = 1,
                Name = name,
                Sprites = new PokeApiPokemonDetailResponse.PokeApiSprites {
                    back_default = "front.png",
                    front_default = "back.png"
                },
                Types = new List<PokeApiPokemonDetailResponse.PokeApiTypes> {
                    new PokeApiPokemonDetailResponse.PokeApiTypes {
                        Slot = 1,
                        Type = new PokeApiPokemonDetailResponse.PokeApiType {
                            Name = "type1"
                        }
                    },
                    new PokeApiPokemonDetailResponse.PokeApiTypes {
                        Slot = 2,
                        Type = new PokeApiPokemonDetailResponse.PokeApiType {
                            Name = "Type2"
                        }
                    }
                }
            };
            
            return await Task.FromResult(pokeApiPokemonDetailResponse);
        }
    }
}