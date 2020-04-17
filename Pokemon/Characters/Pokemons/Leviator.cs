﻿using System;
namespace PokemonGame
{
    public class Leviator : Pokemon
    {
        protected int nb_Fight;

        public Leviator()
        {
            Attack = 60;
            Defense = 60;
            Speed = 60;
            HP = 60;
            pkmn_attacks = getAttacks();
            Name = "Leviator";
            Type = "Eau";
         }

        public override void evolve(int nb_Trainer)
        {
            nb_Fight = nb_Trainer;
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
            Attack Hydro_canon = new Attack("Hydro-canon", 30, "Eau");

            switch (nb_Fight)
            {
                case 3:
                    Damoclès = new Attack("Damocles", 50, "Normal");
                    Hydro_canon = new Attack("Hydro-canon", 50, "Eau");
                    break;

                case 4:
                    Damoclès = new Attack("Damocles", 70, "Normal");
                    Hydro_canon = new Attack("Hydro-canon", 70, "Eau");
                    break;

                default:
                    break;
            }

            a_Attacks[0] = Damoclès;
            a_Attacks[1] = Hydro_canon;

            return a_Attacks;
        }
    }
}
