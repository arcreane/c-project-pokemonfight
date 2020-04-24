
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

        public int s_evolve_state { get; set; } = new int();

        public abstract void evolve();
        public void update(string name, int attack, int defense, int speed, int HP)
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.HP = HP;
        }
    }
}