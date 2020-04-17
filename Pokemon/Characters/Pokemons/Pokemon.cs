
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PokemonGame
{
    public abstract class Pokemon {

        public Pokemon() {
        }

        //protected int hp;

        public int HP { get; set; }

        //protected int attack;

        public int Attack { get; set; }

        //protected int defense;

        public int Defense { get; set; }

        //protected int speed;

        public int Speed { get; set; }

       // protected string type;

        public string Type { get; set; }

        //protected string name;

        public string Name { get; set; }


        


        public Attack[] pkmn_attacks;



        public abstract Attack[] getAttacks();


        public abstract void evolve(int evolution);
    }
}
