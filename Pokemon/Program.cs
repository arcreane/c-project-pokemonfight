using System;

namespace PokemonGame
{

    class MainClass
    {

        //static string[] faiblesses_feu = new string[] { "Eau", "Ultime" } ;
        //static string[] faiblesses_eau = new string[] { "Plante", "Ultime" };
        //static string[] faiblesses_plante = new string[] { "Feu", "Ultime" };

        static string result;
        static int i_result;
        static Game pokemonGame;
        static Starter starter;
        static Character player;
        public static void Main(string[] args)
        {

            bool keepGoing = true;

            do
            {
                difficultyChoice();

                nameChoice();

                pokemonChoice();

                keepGoing = rebootGame();

            } while (keepGoing);


        }
        private static void difficultyChoice()
        {
            Console.WriteLine("Bienvenue dans Pokemon Fight!");
            Console.WriteLine("Gagne les 5 combats pour terminer la ligue Pokemon et deviens maître Pokemon!");
            Console.WriteLine("Choisis ta difficulté: 'tranquille' ou 'chaud' ");
            result = Console.ReadLine();
            if (result == "tranquille" || result == "chaud")
            {
                pokemonGame = new Game(result);
            }
            else
            {
                pokemonGame = new Game("tranquille");
            }
        }
        private static void nameChoice()
        {
            Console.WriteLine("Bien le bonjour! Quel est ton nom?");
            result = Console.ReadLine();
            player = new Character(result);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bienvenue " + player.Name + " dans le monde magique des Pokemon! Mon nom est Chen! Les gens souvent m'appellent le Prof Pokemon! Ce monde est peuple de creatures du nom de Pokemon! L'etude des Pokemon est ma profession. Ta quête pour devenir maître Pokemon est sur le point de commencer! Un tout nouveau monde de rêves, d'aventures et de Pokemon t'attend! Dingue!");

        }
        private static void pokemonChoice()
        {
            Console.WriteLine("A present, choisis parmi ces 3 Pokemons! Prends-en bien soin.");
            Console.WriteLine("Veux-tu le Pokemon type Plante: Bulbizarre? Tape 1");
            Console.WriteLine("Veux-tu le Pokemon type Feu: Salameche? Tape 2");
            Console.WriteLine("Veux-tu le Pokemon type Eau: Carapuce? Tape 3");
            Console.WriteLine("Tu ne sais pas qui tu veux? Tape 4 pour en obtenir un aleatoirement");
            i_result = Int16.Parse(Console.ReadLine());
            Random rnd = new Random();
        retry:
            switch (i_result)
            {
                case 1:

                    Console.WriteLine("* vous avez obtenu Bulbizarre *");

                    starter = new Bulbizarre();
                    pokemonGame.generateFights(i_result, starter);
                    break;

                case 2:

                    Console.WriteLine("* vous avez obtenu Salameche *");

                    starter = new Salamèche();
                    pokemonGame.generateFights(i_result, starter);
                    break;

                case 3:

                    Console.WriteLine("* vous avez obtenu Carapuce  *");

                    starter = new Carapuce();
                    pokemonGame.generateFights(i_result, starter);
                    break;

                case 4:
                    i_result = rnd.Next(1, 3);
                    goto retry;
                    break;

                default:
                    break;
            }
        }
        private static bool rebootGame()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Voulez-vous recommencer une partie? oui/non");

            result = Console.ReadLine();

            if (result != "oui")
            {
                Console.WriteLine("A la prochaine " + player.Name + " !");

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
