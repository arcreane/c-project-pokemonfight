using System;
namespace PokemonGame
{
    public class Bulbizarre : Starter

    {

        public Bulbizarre()
        {
            color = ConsoleColor.Green;
            update("Bulbizarre", 30, 30, 40, 30);
            Type = pokeType.Plante;
            pkmn_attacks = getAttacks();
        }


        public override void evolve()
        {
            switch (s_evolve_state)
            {
                case 0:
                    update("Herbizzare", 60, 60, 75, 60);
                    s_evolve_state++;
                    break;

                case 1:
                    update("Florizzare", 90, 90, 110, 90);
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
            pokeType[] AttackType = new pokeType[] { pokeType.Normal, pokeType.Plante };
            int attackValue;
            switch (s_evolve_state)
            {
                case 0:
                    attackValue = 30;
                    AttackName[0] = "Charge";
                    AttackName[1] = "Vol-vie";
                    break;

                case 1:
                    attackValue = 50;
                    AttackName[0] = "Vive-attaque";
                    AttackName[1] = "Tranch'herbe";
                    break;


                case 2:
                    attackValue = 70;
                    AttackName[0] = "Force";
                    AttackName[1] = "Danse-fleur";
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
