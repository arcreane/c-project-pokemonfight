using System;
namespace PokemonGame
{
    public class Rattata : Pokemon
    {
        public Rattata()
        {
            update("Rattata", 20, 20, 30, 20);
            pkmn_attacks = getAttacks();
            Name = "Rattata";
            Type = pokeType.Normal;
        }

        public override void updateBoss(int evolution)
        {
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            Attack Charge = new Attack("Charge", 30, pokeType.Normal);
            Attack Vive_attaque = new Attack("Vive-attaque", 30, pokeType.Normal);
            a_Attacks[0] = Charge;
            a_Attacks[1] = Vive_attaque;

            return a_Attacks;
        }
    }
}
