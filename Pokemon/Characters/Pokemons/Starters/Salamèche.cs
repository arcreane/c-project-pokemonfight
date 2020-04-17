using System;
namespace PokemonGame
{
    public class Salamèche : Starter
    {
        protected int evolve_state = 0;

        public Salamèche()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            update("Salamèche", 40, 30, 30, 30);
            Type = "Feu";
            pkmn_attacks = getAttacks();
            PP[0] = 50;
            PP[1] = 10;       
        }
        public override void evolve(int evolve_state)
        {
            switch (evolve_state)
            {
                case 0:
                    update("Reptincel, 75, 60, 60, 60");
                    evolve_state++;
                    break;

                case 1:
                    update("Dracaufeu", 110, 90, 90, 90);
                    evolve_state++;
                    break;

                default:
                    break;
            }
        }

        public override Attack[] getAttacks()
        {
            Attack[] a_Attacks = new Attack[2];
            string[] AttackName = new string[2];
            string[] AttackType = new string[] { "Normal", "Feu" };
            int attackValue;
            switch (evolve_state)
            {
                case 0:
                    attackValue = 30;
                     AttackName[0] = "Charge";
                    AttackName[1] = "Flammèche";
                    break;

                case 1:
                    attackValue = 50;
                    AttackName[0] = "Combo-griffe";
                    AttackName[1] = "Poing de feu";
                    break;


                case 2:
                    attackValue = 70;
                    AttackName[0] = "Tranche";
                    AttackName[1] = "Lance-flamme";
                    break;


                default:
                    attackValue = 0;
                    break;
            }
            for(int i = 0; i< a_Attacks.Length; i++)
                a_Attacks[i] = new Attack(AttackName[i], attackValue, AttackType[i]);
            

            return a_Attacks;
        }
    }
}
