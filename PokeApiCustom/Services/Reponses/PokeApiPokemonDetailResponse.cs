using System.Collections.Generic;

namespace PokeApiCustom.Services.Reponses {
    public class PokeApiPokemonDetailResponse {
        public int Id { get; set; }
        public string Name { get; set; }
        public PokeApiSprites Sprites { get; set; }
        public List<PokeApiTypes> Types { get; set; }
        
        # region Clases propias de la respuesta
        public class PokeApiSprites {
            public string back_default { get; set; }
            public string front_default { get; set; }
        }
        
        public class PokeApiTypes {
            public int Slot { get; set; }
            public PokeApiType Type { get; set; }
        }
        
        public class PokeApiType {
            public string Name { get; set; }
        }
        
        #endregion
    }
}