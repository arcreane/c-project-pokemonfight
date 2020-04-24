using System;
namespace PokemonGame
{
    public class Carapuce : Starter
    {

        public Carapuce()
        {
            color = ConsoleColor.Blue;
            update("Carapuce", 30, 35, 30, 35);
            Type = pokeType.Eau ;
            pkmn_attacks = getAttacks();
        }

        public override void evolve()
        {
            switch (s_evolve_state)
            {
                case 0:
                    update("Carabaffe", 60, 65, 60, 70);
                    s_evolve_state++;
                    break;

                case 1:
                    update("Tortank", 90, 100, 90, 100);
                    s_evolve_state++;
                    break;

                default:
                    break;
            }
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            string[] AttackName = new string[2];
            pokeType[] AttackType = new pokeType[] { pokeType.Normal, pokeType.Eau };
            int attackValue;
            switch (s_evolve_state)
            {
                case 0:
                    attackValue = 30;
                     AttackName[0] = "Charge";
                    AttackName[1] = "Pistolet a O";
                    break;

                case 1:
                    attackValue = 50;
                    AttackName[0] = "Ecras-face";
                    AttackName[1] = "Cascade";
                    break;


                case 2:
                    attackValue = 70;
                    AttackName[0] = "Plaquage";
                    AttackName[1] = "Surf";
                    break;


                default:
                    attackValue = 0;
                    break;
            }
            for(int i = 0; i< a_Attacks.Length; i++)
                a_Attacks[i] = new Attack(AttackName[i], attackValue, AttackType[i]);

            return a_Attacks;
        }

        public override void updateBoss(int evolution)
        {
            // Obligatoire car héritage de la classe Pokemon
        }
    }
}
