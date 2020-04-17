
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame
{
    public class Game
    {

        public string Difficulty;
        public int nbPotions;

        public Game(string difficulty)
        {
            Difficulty = difficulty;
            nbPotions = 5;
        }

        public void generateFights(int starter_choice, Starter starter)
        {
            bool game_state = true;
            Pokemon boss_pkmn;
            Combat[] fight = new Combat[5];
            Boss[] bosses = new Boss[] { new Boss("Toto",new Rattata()),
                                         new Boss("Titi",new Leviator()),
                                         new Boss("Tata",new Empiflor()),
                                         new Boss("Tutu",new Arcanin()),
                                         new Boss("Tomy",new Tomy()),
                                        };

            int[,] matrixBosses = new int[3, 5] { { 0, 1, 2, 3, 4 }, { 0, 2, 3, 1, 4 }, { 0, 3, 1, 2, 4 } };

            for (int i = 0; i < fight.Length; i++)
            {
                fight[i] = new Combat();
                int bossIndex = matrixBosses[starter_choice - 1, i];
                boss_pkmn = bosses[bossIndex].myPokePoke;
                boss_pkmn.evolve(i);
                game_state = fight[i].start_Fight("boss", boss_pkmn, starter, Difficulty, nbPotions);
                if (!game_state)
                    return;

                if (i == 2 || i == 4)
                    starter.evolve(i);
            }
        }
    }
}
