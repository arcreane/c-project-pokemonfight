using System.Collections.Generic;

namespace PokemonGame
{
    public class Type
    {
        public Type()
        {

        }

        // Fonction statique pour pouvoir l'utiliser sans instancier de Type
        // Elle calcule le coefficient des attaques Pokémon en fonction des types
        public static double retrieveCM(pokeType atckType, pokeType targetType)
        {
            double cm = 1;

            // On crée une liste qui associe à un type en particulier une liste de type contre
            // qui il est faible en cas d'attaque
            IDictionary<pokeType, pokeType[]> weakTypes = new Dictionary<pokeType, pokeType[]>()
            {
                {pokeType.Feu, new pokeType[] {pokeType.Eau, pokeType.Feu, pokeType.Ultime } },
                {pokeType.Eau, new pokeType[] {pokeType.Plante, pokeType.Eau, pokeType.Ultime } },
                {pokeType.Plante, new pokeType[] {pokeType.Feu, pokeType.Plante, pokeType.Ultime } },
                {pokeType.Normal, new pokeType[] {pokeType.Normal, pokeType.Ultime } },
                {pokeType.Ultime, new pokeType[] {pokeType.Ultime } }
            };
            // On crée une liste qui associe à un type en particulier une liste de type contre
            // qui il est fort en cas d'attaque
            IDictionary<pokeType, pokeType[]> strongTypes = new Dictionary<pokeType, pokeType[]>()
            {
                {pokeType.Feu, new pokeType[] {pokeType.Plante, pokeType.Ultime } },
                {pokeType.Eau, new pokeType[] {pokeType.Feu, pokeType.Ultime } },
                {pokeType.Plante, new pokeType[] {pokeType.Eau, pokeType.Ultime } },
                {pokeType.Normal, new pokeType[] { pokeType.Ultime } },
                {pokeType.Ultime, new pokeType[] {pokeType.Normal, pokeType.Eau, pokeType.Feu, pokeType.Plante } }
            };

            // On parcourt les listes associées au type de l'attaque pour calculer le
            // coefficient multiplicateur déclaré au préalable en tant que double
            foreach (pokeType wType in strongTypes[atckType])
            {
                if (wType == targetType)
                {
                    cm = 2;
                    break;
                }
            }
            if(cm != 2)
            {
                foreach (pokeType sType in weakTypes[atckType])
                {
                    if (sType == targetType)
                    {
                        cm = 0.5;
                    }
                }
            }

            return cm;
        }
    }

    // Enumération de tous les types disponibles dans le jeu
    public enum pokeType
    {
        Normal,
        Feu,
        Eau,
        Plante,
        Ultime
    }
    
}
