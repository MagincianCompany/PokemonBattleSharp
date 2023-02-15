using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    public static class pType
    {
        public static types fromString(string s)
        {
            switch (s)
            {
                case "NORMAL":
                    return types.NORMAL;
                case "FIRE":
                    return types.FIRE;
                case "WATER":
                    return types.WATER;
                default: return types.NONE;
            }
        }

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

                if (def == types.WATER || def == types.GRASS || def == types.DRAGON)
                {

                    ret = 1 / 2;
                }
                else if (def == types.FIRE || def == types.GROUND || def == types.ROCK)
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
                else if (def == types.WATER || def == types.FLYING)
                {
                    ret = 2;
                }
                else if (def == types.GROUND)
                {

                    ret = 0;
                }
            }
            else if (atk == types.GRASS)
            {

                if (def == types.STEEL || def == types.BUG || def == types.FIRE || def == types.GRASS || def == types.POISON || def == types.FLYING)
                {
                    ret = 1 / 2;
                }
                else if (def == types.WATER || def == types.PSYCHIC || def == types.GROUND)
                {
                    ret = 2;
                }
            }
            else if (atk == types.ICE)
            {

                if (def == types.STEEL || def == types.WATER || def == types.FIRE || def == types.ICE)
                {
                    ret = 1 / 2;
                }
                else if (def == types.DRAGON || def == types.BUG|| def == types.GROUND || def == types.FLYING)
                {
                    ret = 2;
                }
            }
            else if (atk == types.FIGHTING)
            {

                if (def == types.BUG || def == types.FAIRY || def == types.PSYCHIC || def == types.POISON || def == types.FLYING)
                {
                    ret = 1 / 2;
                }
                else if (def == types.STEEL || def == types.ICE || def == types.NORMAL || def == types.ROCK || def == types.DARK)
                {
                    ret = 2;
                }
                else if (def == types.GHOST)
                {

                    ret = 0;
                }
            }
            else if (atk == types.POISON)
            {
                if (def == types.GHOST || def == types.ROCK|| def == types.GROUND || def == types.POISON)
                {
                    ret = 1 / 2;
                }
                else if (def == types.FAIRY || def == types.BUG)
                {
                    ret = 2;
                }
                else if (def == types.STEEL)
                {

                    ret = 0;
                }
            }
            else if (atk == types.GROUND)
            {
                if (def == types.BUG || def == types.GRASS)
                {
                    ret = 1 / 2;
                }
                else if (def == types.STEEL || def == types.ELECTRIC || def == types.ROCK || def == types.GROUND)
                {
                    ret = 2;
                }
                else if (def == types.FLYING)
                {

                    ret = 0;
                }
            }


            return ret;
        }
        public enum types
        {
            NONE,//
            NORMAL,//
            FIRE,//
            WATER,//
            ELECTRIC,//
            GRASS,//
            ICE,//
            FIGHTING,//
            POISON,//
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