using System;

namespace PokemonGame
{

    class MainClass
    {
        static string result;
        static int i_result;
        static Game pokemonGame;
        static Starter starter;
        static Character player;
        public static void Main(string[] args)
        {
            // On a choisit le blanc comme couleur par défaut
            Console.ForegroundColor = ConsoleColor.White;
            bool keepGoing = true;

            do
            {
                difficultyChoice(); // Choix de la difficulté
                nameChoice(); // Choix du pseudo de l'utilisateur
                int resultUser = pokemonChoice(); // On choisit son starter et on l'affecte à resultUser
                Console.ForegroundColor = starter.color;
                Console.WriteLine("Felicitations, vous avez obtenu un " + starter.Name);
                Console.WriteLine("Appuyer sur une touche pour continuer...");
                Console.ReadKey(true);
                startPlay(resultUser); // On utilise resultUser pour lancer le bon schéma de jeu
                keepGoing = rebootGame(); // On relance une partie ou non à la volonté de l'utilisateur
            } while (keepGoing);


        }

        private static void startPlay(int resultUser)
        {
            pokemonGame.generateFights(resultUser, starter); //Génère les combats dans l'ordre correspondant
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
                //Dans les cas où le retour utilisateur ne correspond pas à un de nos cas
                //On lui attribue la plus simple difficulté par défaut
                pokemonGame = new Game("tranquille");
            }
        }
        private static void nameChoice()
        {
            Console.WriteLine("Bien le bonjour! Quel est ton nom?");
            result = Console.ReadLine();
            player = new Character(result);
            Console.WriteLine("Bienvenue " + player.Name + " dans le monde magique des Pokemon! Mon nom est Chen! Les gens souvent m'appellent le Prof Pokemon! Ce monde est peuple de creatures du nom de Pokemon! L'etude des Pokemon est ma profession. Ta quête pour devenir maître Pokemon est sur le point de commencer! Un tout nouveau monde de rêves, d'aventures et de Pokemon t'attend! Dingue!");

        }
        private static int pokemonChoice()
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
                    starter = new Bulbizarre();
                    break;

                case 2:
                    starter = new Salamèche();
                    break;

                case 3:
                    starter = new Carapuce();
                    break;

                case 4:
                    //Dans le cas aléatoire, on utilise le point retry pour utiliser un cas aléatoire
                    i_result = rnd.Next(1, 3);
                    goto retry;

                default:
                    break;
            }

            return i_result;
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
