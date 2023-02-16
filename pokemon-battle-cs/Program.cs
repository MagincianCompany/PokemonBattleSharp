using PokemonBattle;
using PokemonBattle.Moves.Actions;
using PokemonBattle.Moves;

public class Program
{
    public static void Main(string[] args)
    {
        database.SetPokemonPreload();

        var m = new Move("test", "this is a test", pType.types.GROUND,Move.mType.PHSYSICAL, 100, "targetDamage");
        Move.KeyMovePair.Add("test", m);

        //Pokemon p1 = new Pokemon("pikachula", 0, 100, new Pokemon.Stats(100, 100, 100, 100, 100, 100), pType.types.ELECTRIC, pType.types.NONE, "test");
        PokemonBattle.PokemonActive p1 = new PokemonBattle.PokemonActive("pikachurro", 0, 100, new Pokemon.Stats(10, 10, 10, 10, 10, 10), pType.types.GROUND, pType.types.NONE, "test");
        PokemonBattle.PokemonActive p2 = new PokemonBattle.PokemonActive(Pokemon.preloadedPokemons["BULBASAUR"],0,100,"test");

        Console.WriteLine(p1.ToString());
        Console.WriteLine(p1.attack(0, p2));
        Console.WriteLine(p2.stats.hp);
    }
}