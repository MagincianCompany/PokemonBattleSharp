using PokemonBattle.Moves.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Moves
{
    internal class Move
    {
        public static Dictionary<String, Move> KeyMovePair = new Dictionary<String, Move>();

        public string name;
        public string description;
        public pType.types pType;
        public mType type;
        public int power;

        public Func<Move, Pokemon, Pokemon, string>? onAttack;
        

        public Move(string name, string description,pType.types pType,int power, string onAttakcString)
        {
            this.name = name;
            this.description = description;
            this.pType = pType;
            this.power = power;
            this.onAttack =MoveActions.parseAttack(onAttakcString);
        }

        public enum mType
        { 
            PHSYSICAL,
            SPECIAL
        }

        
        
        
    }
}
