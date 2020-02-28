using System;

namespace PokemonGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string result;

            Console.WriteLine("Bienvenue dans Pokemon Fight!");
            Console.WriteLine("Gagne les 5 combats pour terminer la ligue Pokemon et deviens maître Pokemon!");
            Console.WriteLine("Choisis ta difficulté: 'tranquille' ou 'chaud' ");
            result = Console.ReadLine();
            if (result == "tranquille" || result =="chaud")
            {
                Game pokemonGame = new Game(result);
            }
            else
            {
                Game pokemonGame = new Game("tranquille");
            }
            Console.WriteLine("*Prof Chen parle*");
            Console.WriteLine("Bien le bonjour! Quel est ton nom?");
            result = Console.ReadLine();
            Character player = new Character(result);
            Console.WriteLine("Bienvenue " + player.Name + " dans le monde magique des Pokemon! Mon nom est Chen! Les gens souvent m'appellent le Prof Pokemon! Ce monde est peuple de creatures du nom de Pokemon! L'etude des Pokemon est ma profession. Ta quête pour devenir maître Pokemon est sur le point de commencer! Un tout nouveau monde de rêves, d'aventures et de Pokemon t'attend! Dingue!");
            Console.WriteLine("A present, choisis parmi ces 3 Pokemons! Prends-en bien soin.");
            Console.WriteLine("Veux-tu le Pokemon type Plante: Bulbizarre? Tape 1");
            Console.WriteLine("Veux-tu le Pokemon type Feu: Salamèche? Tape 2");
            Console.WriteLine("Veux-tu le Pokemon type Eau: Carapuce? Tape 3");
            Console.WriteLine("Tu ne sais pas qui tu veux? Tape 4 pour en obtenir un aléatoirement");
            result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("*vous avez obtenu Bulbizarre*");
                    break;

                case "2":
                    Console.WriteLine("*vous avez obtenu Salamèche*");
                    break;

                case "3":
                    Console.WriteLine("*vous avez obtenu Carapuce*");
                    break;

                case "4":
                    Console.WriteLine("*vous avez obtenu ?*");
                    break;

                default:
                    break;
            }
        }
    }
}
