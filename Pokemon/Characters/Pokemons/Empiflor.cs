﻿using System;
namespace PokemonGame
{
    public class Empiflor : Pokemon
    {
        protected int nb_Fight;

        public Empiflor(int nb_Trainer)
        {
            Attack = 40;
            Defense = 40;
            Speed = 40;
            HP = 40;
            nb_Fight = nb_Trainer;
            pkmn_attacks = getAttacks();
            Name = "Empiflor";
            Type = "Plante";
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            Attack Damoclès = new Attack("Damoclès", 30, "Normal");
            Attack Lance_soleil = new Attack("Lance-soleil", 30, "Plante");

            switch (nb_Fight)
            {
                case 3:
                    Damoclès = new Attack("Damoclès", 50, "Normal");
                    Lance_soleil = new Attack("Lance-soleil", 50, "Plante");
                    break;

                case 4:
                    Damoclès = new Attack("Damoclès", 70, "Normal");
                    Lance_soleil = new Attack("Lance-soleil", 70, "Plante");
                    break;

                default:
                    break;
            }

            a_Attacks[0] = Damoclès;
            a_Attacks[1] = Lance_soleil;

            return a_Attacks;
        }
    }
}
