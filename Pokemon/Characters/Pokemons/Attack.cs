namespace PokemonGame
{
    public class Attack
    {
        public int Damage { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }


        public Attack(string name, int damage, string type)
        {
            Name = name;
            Type = type;
            Damage = damage;
        }
    }
}
