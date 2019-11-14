using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeApiCustom.Models;
using PokeApiCustom.Repositories;

namespace PokeApiCustom.Controllers {
    
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase {
    
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository) {
            _pokemonRepository = pokemonRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> Get() {
            List<Pokemon> pokemonList = await _pokemonRepository.GetPokemonList();
            if (pokemonList is null) return NotFound();
            return Ok(pokemonList);
        }
        
        

    }
}