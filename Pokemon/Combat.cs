using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame
{
    public class Combat {
        int resultUser;
        int choice_attack;
        int choice_attack_boss;
        double cm_starter;
        double cm_boss;
        double hpLost;
        //Chance d'échec ou de critique
        Random rnd_atck = new Random();
        int atck_chance;
        Pokemon boss_pkmn;
        Starter starter;
        bool game_state = true;
        int baseHP;
        int nbPotions;


        public Combat(string c_Name, Pokemon p_boss_pkmn, Starter p_starter, string s_difficulty, int i_nbPotions)
        {

            baseHP = starter.HP;

            nbPotions = i_nbPotions;

            Console.Clear();

            introduceFight(c_Name);


            do
            {
                Round();

            } while (game_state);
           
        }

        private void Round()
        {
            throw new NotImplementedException();
        }

        public void Potion()
        {
            if (nbPotions > 0 && starter.HP < baseHP)
            {
                starter.HP += 20;
                starter.HP = starter.HP > baseHP ? baseHP : starter.HP;
                nbPotions--;
                Console.WriteLine("Vous avez recupere 20hp et il vous reste " + nbPotions + " potions");
                counterAttack();
            }
            else
            {
                Console.WriteLine("Vous ne pouvez pas utiliser de potion");
            }
        }

        public void Color(Pokemon pkmn = null, Attack atck = null)
        {
            if (pkmn.Type == "Feu" || atck.Type == "Feu")
            { 
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (pkmn.Type == "Eau" || atck.Type == "Eau")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if(pkmn.Type == "Plante" || atck.Type == "Plante")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (pkmn.Type == "Ultime" || atck.Type == "Ultime")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public bool start_Fight(string c_Name, Pokemon p_boss_pkmn, Starter p_starter, string s_difficulty, int nbPotions)
        {

        restart:
            //bool won;
            boss_pkmn = p_boss_pkmn;
            starter = p_starter;
            int baseHP = starter.HP;
            string difficulty = s_difficulty;
            //Chance d'échec ou de critique
            Random rnd_atck = new Random();
            int atck_chance;
            starter.pkmn_attacks = starter.getAttacks();
            introduceFight(c_Name);
            start:
            do
            {
                Console.WriteLine(starter.Name + " possede " + starter.HP + " HP");
                Console.WriteLine(boss_pkmn.Name + " possede " +boss_pkmn.HP + " HP");
                Console.WriteLine("*******************************************************");

                cm_starter = 1;
                cm_boss = 1;

                //Déroulement du combat
                Console.WriteLine("Que voulez-vous faire ? Tapez 1 pour utiliser une potion ou 2 pour utiliser une attaque");
                resultUser = int.Parse(Console.ReadLine());
                if (resultUser == 1)
                {
                    if (nbPotions > 0 && starter.HP < baseHP)
                    {
                        starter.HP += 20;
                        starter.HP = starter.HP > baseHP ? baseHP : starter.HP;
                        nbPotions--;
                        Console.WriteLine("Vous avez recupere 20hp et il vous reste " + nbPotions + " potions");
                        counterAttack();
                    }
                    else
                    {
                        Console.WriteLine("Vous ne pouvez pas utiliser de potion");
                        goto start;
                    }
                }
                else if( resultUser == 2)
                {
                    
                
                Console.WriteLine("Quelle attaque souhaitez-vous utiliser?");
                Console.WriteLine("Tapez 1 pour utiliser : " + starter.pkmn_attacks[0].Name + "("+ starter.PP[0] + "/50)" ) ;
                Console.WriteLine("Tapez 2 pour utiliser : " + starter.pkmn_attacks[1].Name + "(" + starter.PP[1] + "/10)");
                Console.WriteLine("*******************************************************");
                choice_attack = int.Parse(Console.ReadLine());



                    if (starter.Speed > boss_pkmn.Speed || starter.Speed == boss_pkmn.Speed)
                    {
                        Console.WriteLine(starter.Name + " utilise " + starter.pkmn_attacks[choice_attack - 1].Name);
                        //Calcul du coefficient multiplicateur
                        if (starter.Type == starter.pkmn_attacks[choice_attack - 1].Type)
                        {
                            cm_starter = cm_starter * 1.5;
                        }
                        switch (starter.pkmn_attacks[choice_attack - 1].Type)
                        {
                            case "Plante":
                                if (boss_pkmn.Type == "Eau")
                                {
                                    cm_starter = cm_starter * 2;
                                }
                                else if (boss_pkmn.Type == "Feu")
                                {
                                    cm_starter = cm_starter / 2;
                                }
                                break;

                            case "Eau":
                                if (boss_pkmn.Type == "Feu")
                                {
                                    cm_starter = cm_starter * 2;
                                }
                                else if (boss_pkmn.Type == "Plante")
                                {
                                    cm_starter = cm_starter / 2;
                                }
                                break;

                            case "Feu":
                                if (boss_pkmn.Type == "Plante")
                                {
                                    cm_starter = cm_starter * 2;
                                }
                                else if (boss_pkmn.Type == "Eau")
                                {
                                    cm_starter = cm_starter / 2;
                                }
                                break;

                            case "Ultime":
                                cm_starter = cm_starter * 2;
                                break;

                            default:
                                break;
                        }
                        atck_chance = rnd_atck.Next(0, 100);

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
                        Console.WriteLine(boss_pkmn.Name + " a perdu " + hpLost + " HP");
                        Console.WriteLine("*******************************************************");



                        //Contre-attaque du Pokémon adverse
                        counterAttack();


                    }
                    else
                    {
                        counterAttack();
                        Console.WriteLine(boss_pkmn.Name + " a perdu " + hpLost + " HP");
                        Console.WriteLine("*******************************************************");
                    }
                }
            } while (boss_pkmn.HP > 0 && starter.HP > 0);

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
                        starter.HP = baseHP;
                        goto restart;
                    }
                    else if(result == "non")
                    {
                        endFight(false);
                        Console.WriteLine("");
                        Console.WriteLine("*****Merci d'avoir joue, retour a l'acceuil...*****");
                    }
                   
                }
                return false;
               
            }
            else
            {
                endFight(true);
                starter.HP = baseHP;
                return true;
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
                return;
            }
            Random rnd = new Random();
            choice_attack_boss = rnd.Next(1, 3);
            Console.WriteLine(boss_pkmn.Name + " utilise " + boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Name);
            //Définition du coefficient multiplicateur
            if (boss_pkmn.Type == boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Type)
            {
                cm_boss = cm_boss * 1.5;
            }

            switch (boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Type)
            {
                case "Plante":
                    if (starter.Type == "Eau")
                    {
                        cm_boss = cm_boss * 2;
                    }
                    else if (starter.Type == "Feu")
                    {
                        cm_boss = cm_boss / 2;
                    }
                    break;

                case "Eau":
                    if (starter.Type == "Feu")
                    {
                        cm_boss = cm_boss * 2;
                    }
                    else if (starter.Type == "Plante")
                    {
                        cm_boss = cm_boss / 2;
                    }
                    break;

                case "Feu":
                    if (starter.Type == "Plante")
                    {
                        cm_boss = cm_boss * 2;
                    }
                    else if (starter.Type == "Eau")
                    {
                        cm_boss = cm_boss / 2;
                    }
                    break;

                case "Ultime":
                    cm_boss = cm_boss * 2;
                    break;

                default:
                    break;
            }
            atck_chance = rnd_atck.Next(0, 100);

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
            Console.WriteLine(starter.Name + " a perdu " + hpLost + " HP");
            Console.WriteLine("*******************************************************");
        }

    }
}
