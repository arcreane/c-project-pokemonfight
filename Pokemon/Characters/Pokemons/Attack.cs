using System;
namespace PokemonGame
{
    public class Attack
    {
        public int Damage { get; set; }
        public pokeType Type { get; set; }
        public string Name { get; set; }
        public ConsoleColor color { get; set; }

        public Attack(string name, int damage, pokeType type)
        {
            Name = name;
            Type = type;
            Damage = damage;
            switch (this.Type)
            {
                case pokeType.Feu:
                    color = ConsoleColor.Red;
                    break;

                case pokeType.Eau:
                    color = ConsoleColor.Blue;
                    break;

                case pokeType.Plante:
                    color = ConsoleColor.Green;
                    break;

                case pokeType.Ultime:
                    color = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
