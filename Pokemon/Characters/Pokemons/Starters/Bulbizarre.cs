using System;
namespace PokemonGame
{
    public class Bulbizarre : Starter

    {

        protected int evolve_state = 0;

        public Bulbizarre()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Attack = 30;
            Defense = 30;
            Speed = 40;
            HP = 30;
            Type = "Plante";
            Name = "Bulbizarre";
            pkmn_attacks = getAttacks();
          
            PP[0] = 50;
            PP[1] = 10;
        }

        public override void evolve()
        {
            switch (evolve_state)
            {
                case 0:
                    Name = "Herbizarre";
                    Attack = 60;
                    Defense = 60;
                    Speed = 75;
                    HP = 60;
                    evolve_state++;
                    break;

                case 1:
                    Name = "Florizarre";
                    Attack = 90;
                    Defense = 90;
                    Speed = 110;
                    HP = 90;
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
                    Attack Vol_vie = new Attack("Vol-vie", 30, "Plante");
                    a_Attacks[0] = Charge;
                    a_Attacks[1] = Vol_vie;
                    break;
                    

                case 1:
                    Attack Vive_Attaque = new Attack("Vive-attaque", 50, "Normal");
                    Attack Tranch_herbe = new Attack("Tranch'herbe", 50, "Plante");
                    a_Attacks[0] = Vive_Attaque;
                    a_Attacks[1] = Tranch_herbe;
                    break;


                case 2:
                    Attack Force = new Attack("Force", 70, "Normal");
                    Attack Danse_fleur = new Attack("Danse-fleur", 70, "Plante");
                    a_Attacks[0] = Force;
                    a_Attacks[1] = Danse_fleur;
                    break;
                    

                default:
                    break;
            }

            return a_Attacks;
        }
    }
}
