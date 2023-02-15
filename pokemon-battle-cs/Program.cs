using PokemonBattle;
using PokemonBattle.Moves;
using PokemonBattle.Moves.Actions;

public class Program
{
    public static void Main(string[] args)
    {

        var m = new Move("test", "this is a test", pType.types.GROUND,Move.mType.PHSYSICAL, 100, "targetDamage");
        Move.KeyMovePair.Add("test", m);

        //Pokemon p1 = new Pokemon("pikachula", 0, 100, new Pokemon.Stats(100, 100, 100, 100, 100, 100), pType.types.ELECTRIC, pType.types.NONE, "test");
        Pokemon p2 = new Pokemon("pikachurro", 0, 100, new Pokemon.Stats(100, 100, 100, 100, 100, 100), pType.types.GROUND, pType.types.NONE, "test", "g");
        Pokemon p1 = Pokemon.fromString("pikachurro, 0, 100, 100; 100; 100; 100; 100; 100,GROUND,NONE,test");

        Console.WriteLine(p1.ToString());
        Console.WriteLine(p1.attack(0, p2));
        Console.WriteLine(p2.stats.hp);
    }
}