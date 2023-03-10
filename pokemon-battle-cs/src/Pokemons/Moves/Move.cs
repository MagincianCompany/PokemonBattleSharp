using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemons.Types;
using Pokemons.Moves.Actions;

namespace Pokemons.Moves
{
    internal class Move
    {
        public static Dictionary<string, Move> KeyMovePair = new Dictionary<string, Move>();

        public string name;
        public string description;
        public pType.types ptype;
        public mType type;
        public int power;

        public Func<Move, PokemonActive, PokemonActive, string>? onAttack;


        public Move fromString(string s, char sep = ';')
        {
            //name;description;ptype;type;power;action
            var sArray = s.Split(sep);

            var name = sArray[0];
            var description = sArray[1];
            var ptype = pType.fromString(sArray[2]);
            var type = mType.NONE;
            switch (sArray[3])
            {
                case "P":
                case "PHSYSICAL":
                    type = mType.PHSYSICAL;
                    break;
                case "S":
                case "SPECIAL":
                    type = mType.SPECIAL;
                    break;
            }
            var power = int.Parse(sArray[4]);

            return new Move(name, description, ptype, type, power, sArray[5]);


        }


        public Move(string name, string description, pType.types pType, mType type, int power, string onAttackString)
        {
            this.name = name;
            this.description = description;
            ptype = pType;
            this.type = type;
            this.power = power;
            onAttack = MoveActions.parseAttack(onAttackString);
        }

        public override string ToString()
        {
            return $"{name};{description};{ptype.ToString()};{type.ToString()};{power};{MoveActions.toString(onAttack)}";
        }

        public enum mType
        {
            NONE,
            PHSYSICAL,
            SPECIAL
        }




    }
}