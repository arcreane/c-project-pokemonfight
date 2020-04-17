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

        public override void evolve()
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
            switch (evolve_state)
            {
                case 0:
                    Attack Charge = new Attack("Charge", 30, "Normal");
                    Attack Flammèche = new Attack("Flammeche", 30, "Feu");
                    a_Attacks[0] = Charge;
                    a_Attacks[1] = Flammèche;
                    break;

                case 1:
                    Attack Combo_griffe = new Attack("Combo-griffe", 50, "Normal");
                    Attack Poing_de_feu = new Attack("Poing de feu", 50, "Feu");
                    a_Attacks[0] = Combo_griffe;
                    a_Attacks[1] = Poing_de_feu;
                    break;


                case 2:
                    Attack Tranche = new Attack("Tranche", 70, "Normal");
                    Attack Lance_flamme = new Attack("Lance-flamme", 70, "Feu");
                    a_Attacks[0] = Tranche;
                    a_Attacks[1] = Lance_flamme;
                    break;


                default:
                    break;
            }

            return a_Attacks;
        }
    }
}
