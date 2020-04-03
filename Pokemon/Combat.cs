
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame
{
    public class Combat {

        public Combat() {

        }

        public bool start_Fight(string c_Name, Pokemon boss_pkmn, Pokemon starter, string s_difficulty)
        {

        restart:
            //bool won;
            int choice_attack;
            int choice_attack_boss;
            int cm_starter = 1;
            int cm_boss = 1;
            int hpLost;
            int baseHP = starter.HP;
            string difficulty = s_difficulty;
            //Chance d'échec ou de critique
            Random rnd_atck = new Random();
            int atck_chance;
            starter.pkmn_attacks = starter.getAttacks();
            introduceFight(c_Name);

            do
            {
                Console.WriteLine(starter.Name + " possède " + starter.HP + " HP");
                Console.WriteLine(boss_pkmn.Name + " possède " +boss_pkmn.HP + " HP");
                Console.WriteLine("*******************************************************");

                cm_starter = 1;
                cm_boss = 1;

                //Déroulement du combat
                Console.WriteLine("Quelle attaque souhaitez-vous utiliser?");
                Console.WriteLine("Tapez 1 pour utiliser : " + starter.pkmn_attacks[0].Name);
                Console.WriteLine("Tapez 2 pour utiliser : " + starter.pkmn_attacks[1].Name);
                Console.WriteLine("*******************************************************");
                choice_attack = int.Parse(Console.ReadLine());

                

                if (starter.Speed > boss_pkmn.Speed || starter.Speed == boss_pkmn.Speed)
                {
                    Console.WriteLine(starter.Name + " utilise " + starter.pkmn_attacks[choice_attack - 1].Name);
                    //Calcul du coefficient multiplicateur
                    if (starter.Type == starter.pkmn_attacks[choice_attack - 1].Type)
                    {
                        cm_starter = cm_starter * 2;
                        Console.WriteLine(cm_starter);
                    }
                    switch (starter.pkmn_attacks[choice_attack - 1].Type)
                    {
                        case "Plante":
                            if (boss_pkmn.Type == "Eau")
                            {
                                cm_starter = cm_starter * 2;
                            }
                            else if(boss_pkmn.Type == "Feu")
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
                    boss_pkmn.HP -= hpLost;
                    Console.WriteLine(boss_pkmn.Name + " a perdu " + hpLost + " HP");
                    Console.WriteLine("*******************************************************");



                    //Contre-attaque du Pokémon adverse
                    if (boss_pkmn.HP <= 0)
                    {
                        break;
                    }
                    Random rnd = new Random();
                    choice_attack_boss = rnd.Next(1, 3);
                    Console.WriteLine(boss_pkmn.Name + " utilise " + boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Name);
                    //Définition du coefficient multiplicateur
                    if (boss_pkmn.Type == boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Type)
                    {
                        cm_boss = cm_boss * 2;
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
                    starter.HP -= hpLost;
                    Console.WriteLine(starter.Name + " a perdu " + hpLost + " HP");
                    Console.WriteLine("*******************************************************");
                }
                else
                {
                    //Attaque du Pokémon adverse
                    Random rnd = new Random();
                    choice_attack_boss = rnd.Next(1, 3);
                    Console.WriteLine(boss_pkmn.Name + " utilise " + boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Name);
                    //Définition du coefficient multiplicateur
                    if (boss_pkmn.Type == boss_pkmn.pkmn_attacks[choice_attack_boss - 1].Type)
                    {
                        cm_boss = cm_boss * 2;
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
                    starter.HP -= hpLost;
                    Console.WriteLine(starter.Name + " a perdu " + hpLost + " HP");
                    Console.WriteLine("*******************************************************");

                    if (starter.HP <= 0)
                    {
                        break;
                    }

                    Console.WriteLine(starter.Name + " utilise " + starter.pkmn_attacks[choice_attack - 1].Name);
                    //Calcul du coefficient multiplicateur
                    if (starter.Type == starter.pkmn_attacks[choice_attack - 1].Type)
                    {
                        cm_starter = cm_starter * 2;
                        Console.WriteLine(cm_starter);
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
                    boss_pkmn.HP -= hpLost;
                    Console.WriteLine(boss_pkmn.Name + " a perdu " + hpLost + " HP");
                    Console.WriteLine("*******************************************************");

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
                Console.WriteLine("Vous avez gagné! Passons au combat suivant.");
                //Lancement nouveau combat startFight(boss++);
            }
            else
            {
                Console.WriteLine("Vous avez perdu!");
            }
        }

    }
}
