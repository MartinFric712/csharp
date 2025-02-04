using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Game
{
    internal class GameEngine
    {
        public Pokemon FirtstPokemon { get; set; }
        public Pokemon SecondPokemon { get; set; }

        public GameEngine()
        {
            FirtstPokemon = new Pokemon("Pikachu");
            SecondPokemon = new Pokemon("Charizard");
        }

    }
}
