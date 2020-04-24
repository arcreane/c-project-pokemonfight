using System;
namespace PokemonGame
{
    public class Tomy : Pokemon
    {
        

        public Tomy()
        {
            // C'est une private joke, on le met super fort comparé aux autres pour que ça se termine sur de la chance
            // Comme c'est le boss, on peut seulement gagner avec un échec critique de sa part et si on ne
            // fait pas un échec critique, ou si on fait un coup critique également
            update("Tomy", 130, 130, 130, 50);
            pkmn_attacks = getAttacks();
            Name = "Tomy";
            Type = pokeType.Ultime;
        }

        public override void updateBoss(int evolution)
        {
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            Attack Lance_monop = new Attack("Lance-Monop", 100, pokeType.Ultime);
            Attack Tricherie = new Attack("Tricherie", 100, pokeType.Ultime);
            a_Attacks[0] = Lance_monop;
            a_Attacks[1] = Tricherie;

            return a_Attacks;
        }
    }
}
