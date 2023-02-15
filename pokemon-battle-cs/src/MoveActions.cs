using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Moves.Actions
{
    internal static class MoveActions
    {
        public static Func<Move, Pokemon, Pokemon,string>? parseAttack(string s)
        {
            if (s == "targetDamage")
            {
                return (move,self,target)=>targetDamage(move,self,target);
            }
            else return null;
        }
        public static String targetDamage(Move move, Pokemon self, Pokemon target)
        {

            float B = 1;
            if (self.types.Contains(move.pType))
                B = 1.5f;

            float E = 1;
            foreach (var type in target.types) 
            {
                E*=pType.calcEfectivity(move.pType, type);
            }

            float V = (new Random()).Next(85,101);

            float N = self.level;

            float A = 1;
            float D = 1;
            if (move.type == Move.mType.PHSYSICAL)
            {
                A = self.stats.atk;
                D = target.stats.def;
            }
            else if (move.type == Move.mType.SPECIAL)
            {

                A = self.stats.spa;
                D = target.stats.spd;
            }
            else
            { 
                A= 0;
                B = 0;
            }


            float P = move.power;
            

            float damage = 0.01f * B * E * V * (((0.2f * N + 1) * A * P) / (25 * D) + 2);

            target.stats.hp = (int)Math.Truncate(target.stats.hp-damage);

            return $"{self.name}->{target.name}: {move.name}({move.type},{move.pType})->({target.types[0]},{target.types[1]}{{{E}}} ==> {Math.Ceiling(damage)})";
            
        }
    }
}
