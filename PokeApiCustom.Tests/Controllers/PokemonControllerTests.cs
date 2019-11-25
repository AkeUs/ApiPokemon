using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PokeApiCustom.Controllers;
using PokeApiCustom.Models;
using PokeApiCustom.Repositories;
using PokeApiCustom.Tests.Fakes;
using Xunit;

namespace PokeApiCustom.Tests.Controllers {
    
    public class PokemonControllerTests {

        [Fact]
        public void Get_ListPokemon_ReturnList() {
            var pokemonRepositoryMock = new Mock<IPokemonRepository>();
            pokemonRepositoryMock.Setup(x => x.GetPokemonList()).Returns(default(Task<List<Pokemon>>));
            
            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var response = pokemonController.Get();

            Assert.Null(response.Result);

        }
        
    }
}