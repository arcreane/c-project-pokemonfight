﻿using System;
namespace PokemonGame
{
    public class Arcanin : Pokemon
    {
        protected int nb_Fight;

        public Arcanin()
        {
            update("Arcanin", 40, 40, 40, 40);
            pkmn_attacks = getAttacks();
            Name = "Arcanin";
            Type = pokeType.Feu;

        }
        public override void updateBoss(int nb_Trainer)
        {
            nb_Fight = nb_Trainer;
            switch (nb_Trainer)
            {
                case 2:
                    update("Arcanin", 40, 40, 40, 40);
                    break;

                case 3:
                    update("Arcanin", 50, 50, 50, 50);
                    break;

                case 4:
                    update("Arcanin", 60, 60, 60, 60);
                    break;

                default:
                    break;
            }
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            string[] AttackName = new string[2];
            AttackName[0] = "Damocles";
            AttackName[1] = "Deflagration";
            pokeType[] AttackType = new pokeType[] { pokeType.Normal, pokeType.Feu };
            int attackValue;
            switch (nb_Fight)
            {
                case 0:
                    attackValue = 30;
                    break;

                case 1:
                    attackValue = 50;
                    break;


                case 2:
                    attackValue = 60;
                    break;


                default:
                    attackValue = 0;
                    break;
            }
            for (int i = 0; i < a_Attacks.Length; i++)
                a_Attacks[i] = new Attack(AttackName[i], attackValue, AttackType[i]);

            return a_Attacks;
        }
    }
}
