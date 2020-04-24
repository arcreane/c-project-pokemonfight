
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

        public pokeType Type { get; set; }

        //protected string name;

        public string Name { get; set; }


        public void update(string name, int attack, int defense, int speed, int HP)
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.HP = HP;
        }


        public Attack[] pkmn_attacks;



        public abstract Attack[] getAttacks();


        public abstract void updateBoss(int evolution);
    }
}
