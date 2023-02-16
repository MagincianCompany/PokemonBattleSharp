using Pokemons;
using Pokemons.Moves.Actions;
using Pokemons.Moves;
using Pokemons.Types;

public class Program
{
    public static void Main(string[] args)
    {
        database.SetPokemonPreload();

        var m = new Move("test", "this is a test", pType.types.GROUND,Move.mType.PHSYSICAL, 100, "targetDamage");
        Move.KeyMovePair.Add("test", m);

        //Pokemon p1 = new Pokemon("pikachula", 0, 100, new Pokemon.Stats(100, 100, 100, 100, 100, 100), pType.types.ELECTRIC, pType.types.NONE, "test");
        PokemonActive p1 = new PokemonActive("pikachurro", 0, 100, new Pokemon.Stats(1000, 10, 10, 10, 10, 10), pType.types.GROUND, pType.types.NONE, "test");
        PokemonActive p2 = new PokemonActive("BULBASAUR",0,100,"test");

        Console.WriteLine(p2.ToString());
        Console.WriteLine(p2.attack(0, p1));
        Console.WriteLine(p1.stats.hp);
    }
}