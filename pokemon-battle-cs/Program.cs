using PokemonBattle;
using PokemonBattle.Moves;

var m = new Move("test", "this is a test", pType.types.GROUND, 100, "targetDamage");
Move.KeyMovePair.Add("test", m);

Pokemon p1 = new Pokemon("pikachula",0,100,new Pokemon.Stats(100,100,100,100,100,100),pType.types.ELECTRIC,null,"test");
Pokemon p2 = new Pokemon("pikachurro", 0,100, new Pokemon.Stats(100, 100, 100, 100, 100, 100), pType.types.GROUND, null, "test");

Console.WriteLine(p2.stats.hp);
Console.WriteLine( p1.attack(0, p2));
Console.WriteLine(p2.stats.hp);
