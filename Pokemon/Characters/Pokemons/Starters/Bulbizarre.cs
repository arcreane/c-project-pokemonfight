using System;
namespace PokemonGame
{
    public class Bulbizarre : Starter

    {

      
        public Bulbizarre()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* vous avez obtenu Bulbizarre *");
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

        public override void evolve(int evolve_state)
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
            string[] AttackName = new string[2];
            string[] AttackType = new string[] { "Normal", "Plante" };
            int attackValue;
            switch (evolve_state)
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
    }
}
