﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Game
{
    public class GameEngine
    {
        public Pokemon FirstPokemon { get; set; }
        public Pokemon SecondPokemon { get; set; }

        public GameEngine()
        {
            FirstPokemon = new Pokemon("Pikachu");
            SecondPokemon = new Pokemon("Charizard");
        }
    }
}
