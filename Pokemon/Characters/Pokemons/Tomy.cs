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
            Attack[] a_Attacks = new Attack[2];
            Attack Lance_monop = new Attack("Lance-Monop", 100, "Ultime");
            Attack Tricherie = new Attack("Tricherie", 100, "Ultime");
            a_Attacks[0] = Lance_monop;
            a_Attacks[1] = Tricherie;

            return a_Attacks;
        }
    }
}
