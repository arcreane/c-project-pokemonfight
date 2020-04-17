
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame
{
    public class Boss : Character {

        public string name;
        public Pokemon myPokePoke { get; set; }
        
        public Boss(string name, Pokemon pokemon) : base(name)
        {
            myPokePoke = pokemon;
        }

        public void beginTalkFight() {
            // TODO implement here
        }

        public void endTalkFight() {
            // TODO implement here
        }

    }
}
