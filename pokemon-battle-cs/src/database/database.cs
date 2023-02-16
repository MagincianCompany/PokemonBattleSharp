using Microsoft.Data.SqlClient;
using Pokemons;
using Pokemons.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class database
{

    public static string databaseFile = "D:\\pokemon-battle\\pokemon-battle-cs\\pokemon-battle-cs\\data\\pkmnDatabase.mdf";
    public static string conString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databaseFile};Integrated Security=True";

    

    public static void SetPokemonPreload()
    {
        try
        {
            using var con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("GetPokemon", con);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()) 
            {
                Console.WriteLine(reader.GetString(2).Trim());

                Pokemon p = new Pokemon(reader.GetString(1).Trim(),
                    Pokemon.Stats.fromString(reader.GetString(4).Trim(),','),
                    pType.fromString(reader.GetString(2).Trim()),
                     pType.fromString(reader.GetString(3).Trim()));

                Pokemon.preloadedPokemons.Add(reader.GetString(0).Trim(), p);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}