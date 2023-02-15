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


        public Pokemon(string name, int userId, int level, Stats? stats, pType.types t1, pType.types? t2, params Move[] moves)
        {
            this.name = name;
            this.userId = userId;
            this.level = level;
            this.stats = stats;

            types = new pType.types?[2];
            types[0] = t1;
            types[1] = t2;

            this.moves = moves;
        }
        public Pokemon(string name, int userId, int level, Stats? stats, pType.types t1, pType.types? t2, params string[] moves)
        {
            this.name = name;
            this.userId = userId;
            this.level = level;
            this.stats = stats;

            types = new pType.types?[2];
            types[0] = t1;
            types[1] = t2;

            List<Move> movesList = new List<Move>();
            foreach (var move in moves)
            {
                movesList.Add(Move.KeyMovePair[move]);
            }

            this.moves = movesList.ToArray();
        }

        public static Pokemon fromString(string s)
        {
            //"pikachulita,0,100,100;100;100;100;100;100,ELECTRIC,null,test"
            var sArray = s.Split(",");
            var name = sArray[0];
            var userId = int.Parse(sArray[1]);
            var level = int.Parse(sArray[2]);
            var stats = Stats.fromString(sArray[3]);
            var type1 = pType.fromString(sArray[4]);
            var type2 = pType.fromString(sArray[5]);
            var moves = new List<String>();
            for (int i = 6; i < sArray.Length; i++)
            {
                moves.Add(sArray[i]);
            }

            return new Pokemon(name, userId, level, stats, type1, type2, moves.ToArray());

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

            public static Stats fromString(string s, char sep = ';')
            {
                var sArray = s.Split(sep);

                var hp = int.Parse(sArray[0]);
                var atk = int.Parse(sArray[1]);
                var def = int.Parse(sArray[2]);
                var spa = int.Parse(sArray[3]);
                var spd = int.Parse(sArray[4]);
                var spe = int.Parse(sArray[5]);

                return new Stats(hp, atk, def, spa, spd, spe);
            }

            public override string ToString()
            {
                return $"{hp};{atk};{def};{spa};{spd};{spe}";
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


        public override string ToString()
        {
            //"pikachulita,0,100,100;100;100;100;100;100,ELECTRIC,null,test"

            string movesString = "";
            if (moves != null)
            {
                foreach (Move move in moves)
                {
                    movesString += move.name + ",";
                }
            }
            movesString=movesString.Substring(0,movesString.Length-2);

            var t1 = types[0].ToString();
            var t2 = types[1].ToString();
            return $"{name},{userId},{level},{stats.ToString()},{t1},{types[1].ToString()},{movesString}";
        }



    }
}