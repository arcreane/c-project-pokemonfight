
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PokemonGame
{
    public abstract class Starter : Pokemon {

        public Starter() {
            PP[0] = 50;
            PP[1] = 10;
        }
     
        public int[] PP { get; set; } = new int[2] ;

        public int s_evolve_state { get; set; } = new int();

        public ConsoleColor color { get; set; }
        public abstract void evolve();
    }
}