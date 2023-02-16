using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemons.Moves;
using Pokemons.Types;

namespace Pokemons
{
    internal class Pokemon
    {
        public static Dictionary<string, Pokemon> preloadedPokemons = new Dictionary<string, Pokemon>();

        internal string name;
        internal Stats? stats;
        internal pType.types?[] types = new pType.types?[2];
        


        public Pokemon(string name, Stats? stats, pType.types t1, pType.types? t2)
        {
            this.name = name;
            this.stats = stats;

            types = new pType.types?[2];
            types[0] = t1;
            types[1] = t2;

        }
        public Pokemon(Pokemon p) 
        {
            this.name = p.name;
            this.stats = p.stats;
            this.types  = p.types;
        }


        public static Pokemon fromString(string s)
        {
            //"pikachulita,0,100,100;100;100;100;100;100,ELECTRIC,null,test"
            var sArray = s.Split(",");
            var name = sArray[0];
            var stats = Stats.fromString(sArray[3]);
            var type1 = pType.fromString(sArray[4]);
            var type2 = pType.fromString(sArray[5]);

            return new Pokemon(name, stats, type1, type2);

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


        public override string ToString()
        {
            var t1 = types[0].ToString();
            var t2 = types[1].ToString();
            return $"{name},{stats.ToString()},{t1},{types[1].ToString()}";
        }



    }
    internal class PokemonActive : Pokemon
    {
        internal int userId;
        internal int level;
        internal Move?[] moves = new Move[3];
        internal Stats multiplyStats;
        internal Stats activeStats { get {return new Stats(stats.hp*multiplyStats.hp,
            stats.atk*multiplyStats.atk,
            stats.def*multiplyStats.def,
            stats.spa*multiplyStats.spa,
            stats.spd*multiplyStats.spd,
            stats.spe*multiplyStats.spe); } }

        public PokemonActive(string name, int userId, int level, Stats? stats, pType.types t1, pType.types? t2, params Move[] moves):base(name,stats,t1,t2)
        {
            this.userId = userId;
            this.level = level;
            this.moves = moves;

            multiplyStats = new Stats(1, 1, 1, 1, 1, 1);
        }
        public PokemonActive(Pokemon p,int userId,int level, params string[] moves) : base(p)
        {
            this.userId = userId;
            this.level = level;

            List<Move> movesList = new List<Move>();
            foreach (var move in moves)
            {
                movesList.Add(Move.KeyMovePair[move]);
            }

            this.moves = movesList.ToArray();

            multiplyStats = new Stats(1, 1, 1, 1, 1, 1);
        }
        public PokemonActive(string p, int userId, int level, params string[] moves) : base(Pokemon.preloadedPokemons[p])
        {
            this.userId = userId;
            this.level = level;

            List<Move> movesList = new List<Move>();
            foreach (var move in moves)
            {
                movesList.Add(Move.KeyMovePair[move]);
            }

            this.moves = movesList.ToArray();

            multiplyStats = new Stats(1, 1, 1, 1, 1, 1);
        }
        public PokemonActive(string name, int userId, int level, Stats? stats, pType.types t1, pType.types? t2, params string[] moves) : base(name, stats, t1, t2)
        {
            this.userId = userId;
            this.level = level;

            List<Move> movesList = new List<Move>();
            foreach (var move in moves)
            {
                movesList.Add(Move.KeyMovePair[move]);
            }

            this.moves = movesList.ToArray();

            multiplyStats = new Stats(1, 1, 1, 1, 1, 1);
        }

        new public static PokemonActive fromString(string s)
        {
            //"pikachulita,0,100,100;100;100;100;100;100,ELECTRIC,null,test"
                
            var sArray = s.Split(",");
            var name = sArray[0];
            var userId = int.Parse(sArray[1]);
            var level = int.Parse(sArray[2]);
            var stats = Stats.fromString(sArray[3]);
            var type1 = pType.fromString(sArray[4]);
            var type2 = pType.fromString(sArray[5]);
            var moves = new List<string>();
            for (int i = 6; i < sArray.Length; i++)
            {
                moves.Add(sArray[i]);
            }

            return new PokemonActive(name, userId, level, stats, type1, type2, moves.ToArray());

        }


        public string attack(int moveId, PokemonActive target)
        {
            if (target == null) return null;
            if (moves[moveId] == null) return null;

            return attack(moves[moveId], target);

        }
        public string attack(Move move, PokemonActive target)
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
            movesString = movesString.Substring(0, movesString.Length - 1);

            var t1 = types[0].ToString();
            var t2 = types[1].ToString();
            return $"{name},{userId},{level},{stats.ToString()},{t1},{types[1].ToString()},{movesString}";
        }
    }
}

    
