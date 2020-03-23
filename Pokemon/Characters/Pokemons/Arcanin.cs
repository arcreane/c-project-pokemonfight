using System;
namespace PokemonGame
{
    public class Arcanin : Pokemon
    {
        protected int nb_Fight;

        public Arcanin(int nb_Trainer)
        {
            Attack = 70;
            Defense = 70;
            Speed = 70;
            HP = 70;
            nb_Fight = nb_Trainer;
            pkmn_attacks = getAttacks();
            Name = "Arcanin";
            Type = "Feu";
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            Attack Damoclès = new Attack("Damoclès", 30, "Normal");
            Attack Déflagration = new Attack("Déflagration", 30, "Feu");

            switch (nb_Fight)
            {
                case 3:
                    Damoclès = new Attack("Damoclès", 50, "Normal");
                    Déflagration = new Attack("Déflagration", 50, "Feu");
                    break;

                case 4:
                    Damoclès = new Attack("Damoclès", 70, "Normal");
                    Déflagration = new Attack("Déflagration", 70, "Feu");
                    break;

                default:
                    break;
            }
           
            a_Attacks[0] = Damoclès;
            a_Attacks[1] = Déflagration;

            return a_Attacks;
        }
    }
}
