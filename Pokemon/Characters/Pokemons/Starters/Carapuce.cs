using System;
namespace PokemonGame
{
    public class Carapuce : Starter
    {
        protected int evolve_state = 0;

        public Carapuce()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            update("Carapuce", 30, 35, 30, 35);
            Type = "Eau";
            pkmn_attacks = getAttacks();
            PP[0] = 50;
            PP[1] = 10;
        }

        public override void evolve(int evolve_state)
        {
            switch (evolve_state)
            {
                case 0:
                    update("Carabaffe", 60, 65, 60, 70);
                    evolve_state++;
                    break;

                case 1:
                    update("Tortank", 90, 100, 90, 100);
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
                    Attack Pistolet_a_o = new Attack("Pistolet à O", 30, "Eau");
                    a_Attacks[0] = Charge;
                    a_Attacks[1] = Pistolet_a_o;
                    break;

                case 1:
                    Attack Ecras_face = new Attack("Ecras-face", 50, "Normal");
                    Attack Cascade = new Attack("Cascade", 50, "Eau");
                    a_Attacks[0] = Ecras_face;
                    a_Attacks[1] = Cascade;
                    break;


                case 2:
                    Attack Plaquage = new Attack("Plaquage", 70, "Normal");
                    Attack Surf = new Attack("Surf", 70, "Eau");
                    a_Attacks[0] = Plaquage;
                    a_Attacks[1] = Surf;
                    break;


                default:
                    break;
            }

            return a_Attacks;
        }
    }
}
