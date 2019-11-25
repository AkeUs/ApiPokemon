using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PokeApiCustom.Controllers;
using PokeApiCustom.Models;
using PokeApiCustom.Repositories;
using Xunit;

namespace PokeApiCustom.Tests.Controllers {
    
    public class PokemonControllerTests {

        [Fact]
        public async Task Get_ListPokemon_ReturnList() {
            var pokemonRepositoryMock = new Mock<IPokemonRepository>();
            var pokemonList = new List<Pokemon>();
            
            pokemonList.Add(new Pokemon {
                Id = 1,
                Name = "Bulbasaur",
                TypeOne = "Grass",
                TypeTwo = "Poison",
                UrlImage = "http://bulbasaur.png"
            });
            pokemonList.Add(new Pokemon {
                Id = 2,
                Name = "Venusaur",
                TypeOne = "Grass",
                TypeTwo = "Poison",
                UrlImage = "http://venusaur.png"
            });
            
            pokemonRepositoryMock.Setup(x => x.GetPokemonListAsync()).Returns(Task.FromResult(pokemonList));
            
            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var response = await pokemonController.Get();

            Assert.IsType<OkObjectResult>(response.Result);
        }
        
        [Fact]
        public async Task Get_ListPokemon_ReturnNull() {
            var pokemonRepositoryMock = new Mock<IPokemonRepository>();
            pokemonRepositoryMock.Setup(x => x.GetPokemonListAsync()).Returns(Task.FromResult<List<Pokemon>>(null));
            
            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var response = await pokemonController.Get();

            Assert.IsType<NotFoundResult>(response.Result);
        }
        
    }
}