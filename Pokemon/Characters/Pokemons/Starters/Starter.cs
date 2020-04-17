
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PokemonGame
{
    public abstract class Starter : Pokemon {

        public Starter() {
        }
     
        public int[] PP { get; set; } = new int[2] ;
        
    }
}