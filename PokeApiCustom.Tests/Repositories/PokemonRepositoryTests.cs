using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using PokeApiCustom.Models;
using PokeApiCustom.Repositories;
using PokeApiCustom.Services;
using PokeApiCustom.Services.Reponses;
using Xunit;

namespace PokeApiCustom.Tests.Repositories {
    
    public class PokemonRepositoryTests {

        [Fact]
        public async Task GetPokemonListAsync_SendRequestApi_ApiReturnsList() {
            var pokeApiServiceMock = new Mock<IPokeApiService>();
            var cacheMock = new Mock<IDistributedCache>();

            PokeApiPokemonListResponse pokemonListResponse = new PokeApiPokemonListResponse();
            
            pokeApiServiceMock.Setup(x => x.GetPokemonListAsync())
                .Returns(Task.FromResult(pokemonListResponse));

            PokemonRepository pokemonRepository = new PokemonRepository(pokeApiServiceMock.Object, cacheMock.Object);
            var response = await pokemonRepository.GetPokemonListAsync();
            
            Assert.IsType<List<Pokemon>>(response);
        }
        
        [Fact]
        public async Task GetPokemonListAsync_SendRequestApi_ApiReturnsNull() {
            var pokeApiServiceMock = new Mock<IPokeApiService>();
            var cacheMock = new Mock<IDistributedCache>();
            
            pokeApiServiceMock.Setup(x => x.GetPokemonListAsync())
                .Returns(Task.FromResult<PokeApiPokemonListResponse>(null));

            PokemonRepository pokemonRepository = new PokemonRepository(pokeApiServiceMock.Object, cacheMock.Object);
            var response = await pokemonRepository.GetPokemonListAsync();
            
            Assert.Null(response);
        }
    }
}