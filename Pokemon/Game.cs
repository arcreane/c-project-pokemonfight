
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame
{
    public class Game {

        public string Difficulty;

        public Game(string difficulty) {
            Difficulty = difficulty;
        }

        public void generateFights(int starter_choice, Pokemon starter)
        {
            Pokemon boss_pkmn;
            Combat fight1;
            Combat fight2;
            Combat fight3;
            Combat fight4;
            Combat fight5;
            switch (starter_choice)
            {
                case 1:
                    fight1 = new Combat();
                    boss_pkmn = new Rattata();
                    fight1.start_Fight("boss", boss_pkmn, starter);

                    fight2 = new Combat();
                    boss_pkmn = new Leviator(2);
                    fight2.start_Fight("boss", boss_pkmn, starter);

                    fight3 = new Combat();
                    boss_pkmn = new Empiflor(3);
                    fight3.start_Fight("boss", boss_pkmn, starter);

                    fight4 = new Combat();
                    boss_pkmn = new Arcanin(4);
                    fight4.start_Fight("boss", boss_pkmn, starter);
                    break;

                case 2:
                    fight1 = new Combat();
                    boss_pkmn = new Rattata();
                    fight1.start_Fight("boss", boss_pkmn, starter);
                    break;

                case 3:
                    fight1 = new Combat();
                    boss_pkmn = new Rattata();
                    fight1.start_Fight("boss", boss_pkmn, starter);
                    break;

                default:
                    break;
            }
        }
    



    }
}
