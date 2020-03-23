using System;
namespace PokemonGame
{
    public class Tomy : Pokemon
    {
        public Tomy()
        {
            Attack = 130;
            Defense = 130;
            Speed = 130;
            HP = 130;
            pkmn_attacks = getAttacks();
            Name = "Tomy";
            Type = "Ultime";
        }

        public override Attack[] getAttacks()
        {
            throw new NotImplementedException();
        }
    }
}
