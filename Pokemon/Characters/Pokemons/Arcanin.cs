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

            switch (nb_Trainer)
            {
                case 2:
                    Attack = 40;
                    Defense = 40;
                    Speed = 40;
                    HP = 40;
                    break;

                case 3:
                    Attack = 60;
                    Defense = 60;
                    Speed = 60;
                    HP = 60;
                    break;

                case 4:
                    Attack = 70;
                    Defense = 70;
                    Speed = 70;
                    HP = 70;
                    break;

                default:
                    break;
            }
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            Attack Damoclès = new Attack("Damocles", 30, "Normal");
            Attack Déflagration = new Attack("Deflagration", 30, "Feu");

            switch (nb_Fight)
            {
                case 3:
                    Damoclès = new Attack("Damocles", 50, "Normal");
                    Déflagration = new Attack("Deflagration", 50, "Feu");
                    break;

                case 4:
                    Damoclès = new Attack("Damocles", 70, "Normal");
                    Déflagration = new Attack("Deflagration", 70, "Feu");
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
