using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonBattle.Moves;

namespace PokemonBattle
{
    internal class Pokemon
    {
        internal string name;
        internal int userId;
        internal int level;
        internal Stats? stats;
        internal pType.types?[] types = new pType.types?[2];
        internal Move?[] moves = new Move[3];
        

        public Pokemon(string name, int userId,int level, Stats? stats,pType.types t1, pType.types? t2, params Move[] moves)
        {
            this.name = name;
            this.userId = userId;
            this.level = level;
            this.stats = stats;
            
            types=new pType.types?[2];
            types[0] = t1;
            types[1] = t2;

            this.moves = moves;
        }
        public Pokemon(string name, int userId,int level, Stats? stats, pType.types t1, pType.types? t2, params string[] moves)
        {
            this.name = name;
            this.userId = userId;
            this.level = level;
            this.stats = stats;

            types = new pType.types?[2];
            types[0] = t1;
            types[1] = t2;

            List<Move> movesList= new List<Move>();
            foreach (var move in moves) 
            {
                movesList.Add(Move.KeyMovePair[move]);
            }
            
            this.moves= movesList.ToArray();
        }
       
        internal class Stats 
        {
            public int hp;
            public int atk;
            public int def;
            public int spa;
            public int spd;
            public int spe;

            public Stats(int hp, int atk, int def, int spa, int spd, int spe)
            {
                this.hp = hp;
                this.atk = atk;
                this.def = def;
                this.spa = spa;
                this.spd = spd;
                this.spe = spe;
            }
        }
        public string attack(int moveId, Pokemon target)
        {
            if (target == null) return null;
            if (moves[moveId] == null) return null;

            return attack(moves[moveId], target);

        }
        public string attack(Move move, Pokemon target)
        {
            if (move.onAttack != null)
                return move.onAttack(move, this, target);
            return null;
        }






    }
}
