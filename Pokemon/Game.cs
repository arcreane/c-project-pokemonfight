
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
            Boss[] bosses = new Boss[] { new Boss("Thomas",new Rattata()),
                                         new Boss("Papou",new Leviator()),
                                         new Boss("Robin",new Empiflor()),
                                         new Boss("Batman",new Arcanin()),
                                         new Boss("Tomy",new Tomy()),
                                        };

            int[,] matrixBosses = new int[3, 5] { { 0, 1, 2, 3, 4 }, { 0, 2, 3, 1, 4 }, { 0, 3, 1, 2, 4 } };

            for (int i = 0; i < fight.Length; i++)
            {
                int bossIndex = matrixBosses[starter_choice - 1, i];
                boss_pkmn = bosses[bossIndex].myPokePoke;
                boss_pkmn.updateBoss(i);
                fight[i] = new Combat(bosses[bossIndex].Name, boss_pkmn, starter, Difficulty, nbPotions);
                game_state = fight[i].keepGoing;
                if (!game_state)
                    return;

                if (i == 1 || i == 3)
                    starter.evolve();
            }
        }
    }
}
