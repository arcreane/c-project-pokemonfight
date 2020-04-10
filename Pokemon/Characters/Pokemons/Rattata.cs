using System;
namespace PokemonGame
{
    public class Rattata : Pokemon
    {
        public Rattata()
        {
            Attack = 30;
            Defense = 30;
            Speed = 30;
            HP = 30;
            pkmn_attacks = getAttacks();
            Name = "Rattata";
            Type = "Normal";
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            Attack Charge = new Attack("Charge", 30, "Normal");
            Attack Vive_attaque = new Attack("Vive-attaque", 30, "Normal");
            a_Attacks[0] = Charge;
            a_Attacks[1] = Vive_attaque;

            return a_Attacks;
        }
    }
}
