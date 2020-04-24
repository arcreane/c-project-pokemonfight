using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PokemonGame
{
    public class Combat {
        int resultUser,
        choice_attack,
        choice_attack_boss,
        baseHP,
        boss_baseHP,
        nbPotions,
        atck_chance;
        double cm_starter,
        cm_boss,
        hpLost;
        //Chance d'échec ou de critique ( chiffre aléatoire entre 0 et 100) 
        //si < 5, échec critique, si > 95, coup critique)
        Random rnd_atck = new Random();
        Pokemon boss_pkmn;
        Starter starter;
        string difficulty;
        bool restartGame = false,
        isResultOk = false; //Test du résultat pour le TryParse
        public bool keepGoing { get; set; }



        public Combat(string c_Name, Pokemon p_boss_pkmn, Starter p_starter, string s_difficulty, int i_nbPotions)
        {
            starter = p_starter;
            starter.pkmn_attacks = starter.getAttacks(); // On utilise la méthode pour récupérer les attaques
            difficulty = s_difficulty;
            boss_pkmn = p_boss_pkmn;
            baseHP = starter.HP; // on garde en mémoire les HP de base pour recommencer le combat et les potions
            boss_baseHP = boss_pkmn.HP;
            nbPotions = i_nbPotions;
            restart:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            introduceFight(c_Name);

            do
            {
                Round(); // Méthode associée à chaque tour qui se répète
            } while (boss_pkmn.HP > 0 && starter.HP > 0);

            keepGoing = checkWinner(); // On vérifie qui a gagné le combat

            if (restartGame)
            {
                goto restart;
            }
        }

        private bool checkWinner()
        {
            if (starter.HP <= 0)
            {
                endFight(false);
                if (difficulty == "tranquille")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Souhaitez-vous recommencer le combat? (oui/non)");
                    string result = Console.ReadLine();
                    if (result == "oui")
                    {
                        boss_pkmn.HP = boss_baseHP;
                        starter.HP = baseHP;
                        restartGame = true;
                    }
                    else if (result == "non")
                    {
                        endFight(false);
                        Console.WriteLine("");
                        Console.WriteLine("Merci d'avoir joue, retour a l'accueil...");
                    }
                }
                return false;
            }
            else
            {
                endFight(true);
                starter.HP = baseHP; // On regénère les HP du Pokémon pour le combat suivant
                Console.WriteLine("Appuyer sur une touche pour continuer...");
                Console.ReadKey(true);
                Console.Clear();
                return true;
            }
        }

        private void Round()
        {
            displayHp(); // affichage des points de vie en début de tour pour l'utilisateur
            resultUserChoice(); // on traite le choix de l'utilisateur
            executeChoice(); // selon l'action désirée, on établit l'ordre dans lequel les actions sont faites
            if (boss_pkmn.HP > 0 && starter.HP > 0)
            {
                // On clear la Console seulement si le combat n'est pas fini, sinon une autre fonction 
                // annonçant la fin du combat s'occupe de clear la Console plus tard
                Console.WriteLine("Appuyer sur une touche pour continuer...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private void executeChoice()
        {
            if (resultUser == 1)
            {
                // Si on choisit de se soigner, on possède la priorité sur l'attaque de l'adversaire
                // mais on ne peut pas soigner et attaquer directement, il faut patienter un tour
                Potion();
                counterAttack();
            }
            else if (resultUser == 2)
            {
                retrieveAttack(); // On récupère l'attaque sélectionnée par l'utilisateur
                if (starter.Speed > boss_pkmn.Speed || starter.Speed == boss_pkmn.Speed)
                {
                    Color(starter);
                    useAttack();
                    counterAttack();
                }
                else
                {
                    counterAttack();
                    Color(starter);
                    useAttack();
                }
            }
        }

        private void useAttack()
        {
            if (starter.HP <= 0)
            {
                Console.WriteLine(starter.Name + " est mort!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine(starter.Name + " utilise " + starter.pkmn_attacks[choice_attack - 1].Name);
            Console.ForegroundColor = ConsoleColor.White;
            starter.PP[choice_attack - 1] -= 1; // On retire une utilisation à l'attaque sélectionnée
            cm_starter = 1;

            if (starter.Type == starter.pkmn_attacks[choice_attack - 1].Type)
            {
                cm_starter = cm_starter * 1.5;
            }
            // Calcul du coefficient multiplicateur en passant par la classe Type
            cm_starter = cm_starter * Type.retrieveCM(starter.pkmn_attacks[choice_attack - 1].Type, boss_pkmn.Type);
            atck_chance = rnd_atck.Next(0, 100); // On randomise un coup ou échec critique

            if (atck_chance <= 5)
            {
                //Échec critique
                cm_starter = 0;
                Console.WriteLine("Echec critique !");
            }
            else if (atck_chance >= 95)
            {
                //Coup critique
                cm_starter = cm_starter * 2;
                Console.WriteLine("Coup critique !");
            }

            hpLost = cm_starter * ((8 * starter.Attack * starter.pkmn_attacks[choice_attack - 1].Damage) / (boss_pkmn.Defense * 50) + 2);
            boss_pkmn.HP -= Convert.ToInt16(hpLost); 
            // Pour utiliser un multiplicateur de *1.5 on a du utilisé une variable double mais pour simplifier
            // l'affichage et le jeu on convertit tout en int à la fin
            Console.WriteLine(boss_pkmn.Name + " a perdu " + Convert.ToInt16(hpLost) + " HP");
            Console.WriteLine("*******************************************************");
        }

        private void retrieveAttack()
        {
            do
            {
                Console.WriteLine("Quelle attaque souhaitez-vous utiliser?");
                Console.WriteLine("Tapez 1 pour utiliser : " + starter.pkmn_attacks[0].Name + "(" + starter.PP[0] + "/50)");
                Console.WriteLine("Tapez 2 pour utiliser : " + starter.pkmn_attacks[1].Name + "(" + starter.PP[1] + "/10)");
                Console.WriteLine("*******************************************************");
                isResultOk = int.TryParse(Console.ReadLine(), out choice_attack);
            } while (!isResultOk);

        }

        private void resultUserChoice()
        {
            do
            {
                if (nbPotions == 0 || starter.HP == baseHP)
                {
                    // Si l'utilisateur n'a plus de potion ou qu'il n'a pas perdu d'hp
                    //on ne lui propose pas d'en prendre une, il est obligé d'attaquer
                    resultUser = 2;
                    isResultOk = true;
                }
                else
                {
                    Console.WriteLine("Que voulez-vous faire ? Tapez 1 pour utiliser une potion ou 2 pour utiliser une attaque");
                    isResultOk = int.TryParse(Console.ReadLine(), out resultUser);
                }

            } while (!isResultOk);
        }

        private void displayHp()
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine(starter.Name + " possede " + starter.HP + " HP");
            Console.WriteLine(boss_pkmn.Name + " possede " + boss_pkmn.HP + " HP");
            Console.WriteLine("*******************************************************");

        }

        public void Potion()
        {
            if (nbPotions > 0 && starter.HP < baseHP)
            {
                starter.HP += 20;
                // Test pour que le starter ne possède pas + d'HP après utilisation d'une potion
                // qu'il n'en a de base
                starter.HP = starter.HP > baseHP ? baseHP : starter.HP;
                nbPotions--;
                Console.WriteLine("Vous avez recupere 20hp et il vous reste " + nbPotions + " potions");
            }
            else
            {
                Console.WriteLine("Vous ne pouvez pas utiliser de potion");
            }
        }

        public void Color(Pokemon pkmn = null, Attack atck = null)
        {
            // On utilise une variable dynamic pour pouvoir lui affecter soit le type Pokemon 
            // Soit le type Attack en fonction du paramètre envoyé
            dynamic element;
            if (pkmn == null)
                element = atck;
            else
                element = pkmn;
            if (element.Type == pokeType.Feu)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (element.Type == pokeType.Eau)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if(element.Type == pokeType.Plante)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (element.Type == pokeType.Ultime)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public void introduceFight(string c_Name) {
            Console.WriteLine(c_Name + " veut se battre.");
        }

        public void endFight(bool won) {
            if (won)
            {
                Console.WriteLine("Vous avez gagne!  Passons au combat suivant.");
                //Lancement nouveau combat startFight(boss++);
            }
            else
            {
                Console.WriteLine("Vous avez perdu!");
            }
        }
        public void counterAttack()
        {
            if (boss_pkmn.HP <= 0)
            {
                Console.WriteLine(boss_pkmn.Name + " est mort!");
                return;
            }
            Random rnd = new Random();
            choice_attack_boss = rnd.Next(1, 3);
            Color(null,boss_pkmn.pkmn_attacks[choice_attack_boss - 1]);
            Console.WriteLine(boss_pkmn.Name + " utilise " + boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Name);
            Console.ForegroundColor = ConsoleColor.White;
            //Définition du coefficient multiplicateur
            cm_boss = 1;
            if (boss_pkmn.Type == boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Type)
            {
                cm_boss = cm_boss * 1.5;
            }
            // Calcul du coefficient multiplicateur en passant par la classe Type
            cm_boss = cm_boss * Type.retrieveCM(boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Type, starter.Type);

            atck_chance = rnd_atck.Next(0, 100); // On randomise un coup ou échec critique
            if (atck_chance <= 5)
            {
                //Échec critique
                cm_boss = 0;
                Console.WriteLine("Echec critique !");
            }
            else if (atck_chance >= 95)
            {
                //Coup critique
                cm_boss = cm_boss * 2;
                Console.WriteLine("Coup critique !");
            }
            hpLost = cm_boss * ((8 * boss_pkmn.Attack * boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Damage) / (starter.Defense * 50) + 2);
            starter.HP -= Convert.ToInt16(hpLost);
            Console.WriteLine(starter.Name + " a perdu " + Convert.ToInt16(hpLost) + " HP");
            Console.WriteLine("*******************************************************");
        }
    }
}
