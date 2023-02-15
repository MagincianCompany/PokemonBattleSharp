using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    public static class pType
    {
        /// <summary>
        /// calculates the effectiveness of one type over another type
        /// </summary>
        /// <param name="atk">it's the attack type</param>
        /// <param name="def">it's the deffense type</param>
        /// <returns></returns>
        public static float calcEfectivity(types? atk, types? def)
        { 
            float ret = 1;

            if (atk == null || def == null)
                return ret;

            if (atk == types.NORMAL)
            {

                if (def == types.ROCK || def == types.STEEL)
                {

                    ret = 1 / 2;
                }
                else if (def == types.GHOST)
                {

                    ret = 0;
                }

            }
            else if (atk == types.FIRE)
            {

                if (def == types.FIRE || def == types.WATER || def == types.ROCK || def == types.DRAGON)
                {

                    ret = 1 / 2;
                }
                else if (def == types.GRASS || def == types.ICE || def == types.BUG || def == types.STEEL)
                {
                    ret = 2;
                }
            }
            else if (atk == types.WATER)
            {

                if (def == types.WATER || def == types.GRASS|| def == types.DRAGON)
                {

                    ret = 1 / 2;
                }
                else if (def == types.FIRE || def == types.GROUND|| def == types.ROCK)
                {
                    ret = 2;
                }
            }
            else if (atk == types.ELECTRIC)
            {

                if (def == types.ELECTRIC || def == types.GRASS || def == types.DRAGON)
                {
                    ret = 1 / 2;
                }
                else if (def == types.WATER|| def == types.FLYING)
                {
                    ret = 2;
                }
                else if (def == types.GROUND)
                {

                    ret = 0;
                }

            }


            return ret;
        }
        public enum types
        { 
            NORMAL,
            FIRE,
            WATER,
            ELECTRIC,
            GRASS,
            ICE,
            FIGHTING,
            POISON,
            GROUND,
            FLYING,
            PSYCHIC,
            BUG,
            ROCK,
            GHOST,
            DRAGON,
            DARK,
            STEEL,
            FAIRY
        }
            
    }


}
