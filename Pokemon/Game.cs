
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

        public void generateFights(int starter_choice, Starter starter)
        {
            bool game_state = true;
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
                    game_state = fight1.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    if (!game_state)
                    {
                        break;
                    }

                    fight2 = new Combat();
                    boss_pkmn = new Leviator(2);
                    game_state = fight2.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    if (!game_state)
                    {
                        break;
                    }

                    starter.evolve();

                    fight3 = new Combat();
                    boss_pkmn = new Empiflor(3);
                    game_state = fight3.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    if (!game_state)
                    {
                        break;
                    }

                    fight4 = new Combat();
                    boss_pkmn = new Arcanin(4);
                    game_state = fight4.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    if (!game_state)
                    {
                        break;
                    }

                    starter.evolve();

                    fight5 = new Combat();
                    boss_pkmn = new Tomy();
                    game_state = fight5.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    break;

                case 2:
                    fight1 = new Combat();
                    boss_pkmn = new Rattata();
                    game_state = fight1.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    fight2 = new Combat();
                    boss_pkmn = new Empiflor(2);
                    game_state = fight2.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    starter.evolve();

                    fight3 = new Combat();
                    boss_pkmn = new Arcanin(3);
                    game_state = fight3.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    fight4 = new Combat();
                    boss_pkmn = new Leviator(4);
                    game_state = fight4.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    starter.evolve();

                    fight5 = new Combat();
                    boss_pkmn = new Tomy();
                    game_state = fight5.start_Fight("boss", boss_pkmn, starter, Difficulty);
                    break;

                case 3:
                    fight1 = new Combat();
                    boss_pkmn = new Rattata();
                    game_state = fight1.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    fight2 = new Combat();
                    boss_pkmn = new Arcanin(2);
                    game_state = fight2.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    starter.evolve();

                    fight3 = new Combat();
                    boss_pkmn = new Leviator(3);
                    game_state = fight3.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    fight4 = new Combat();
                    boss_pkmn = new Empiflor(4);
                    game_state = fight4.start_Fight("boss", boss_pkmn, starter, Difficulty);

                    starter.evolve();

                    fight5 = new Combat();
                    boss_pkmn = new Tomy();
                    game_state = fight5.start_Fight("boss", boss_pkmn, starter, Difficulty);
                    break;

                default:
                    break;
            }
        }
    



    }
}
