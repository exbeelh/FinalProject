using FinalProject.Interfaces;
using Models.FinalProject;
using System.Data.SqlClient;

namespace FinalProject.Repositories;

class PokemonRepository : IGeneralRepository<Pokemon>
{
    private readonly string _connectionString;

    public PokemonRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Pokemon> GetAllData()
    {
        SqlConnection connection = new(_connectionString);
        connection.Open();

        using SqlCommand command = new("SELECT * FROM tb_pokemon", connection);
        using SqlDataReader reader = command.ExecuteReader();
        var pokemon = new List<Pokemon>();
        while (reader.Read())
        {
            pokemon.Add(new Pokemon
            {
                Id = (int)reader[0],
                Name = (string)reader[1],
                Height = (double)reader[2],
                Weight = (double)reader[3],
                Element = (string)reader[4],
                Abilities = (string)reader[5],
                IsEvolve = (bool)reader[6],
                Hp = (int)reader[7],
                AttackPoint = (int)reader[8],
                DeffensePoint = (int)reader[9],
                SpAttack = (int)reader[10],
                SpDeffense = (int)reader[11],
                Speed = (int)reader[12],
            });
        }
        return pokemon;
    }

    public Pokemon GetDataById(int id)
    {
        SqlConnection connection = new(_connectionString);
        connection.Open();

        using SqlCommand command = new("SELECT * FROM tb_pokemon WHERE id=@id", connection);
        command.Parameters.AddWithValue("@id", id);
        
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Pokemon
            {
                Id = (int)reader[0],
                Name = (string)reader[1],
                Height = (double)reader[2],
                Weight = (double)reader[3],
                Element = (string)reader[4],
                Abilities = (string)reader[5],
                IsEvolve = (bool)reader[6],
                Hp = (int)reader[7],
                AttackPoint = (int)reader[8],
                DeffensePoint = (int)reader[9],
                SpAttack = (int)reader[10],
                SpDeffense = (int)reader[11],
                Speed = (int)reader[12],
            };
        }
        return null;
    }

    public int InsertData(Pokemon pokemon)
    {
        using SqlConnection connection = new(_connectionString);
        connection.Open();

        try
        {
            using SqlCommand command = new("INSERT INTO tb_pokemon VALUES (@name, @height, @weight, @element, @abilities, @is_evolve, @hp, @atk, @def, @spAtk, @spDef, @speed)", connection);
            command.Parameters.AddWithValue("@name", pokemon.Name);
            command.Parameters.AddWithValue("@height", pokemon.Height);
            command.Parameters.AddWithValue("@weight", pokemon.Weight);
            command.Parameters.AddWithValue("@element", pokemon.Element);
            command.Parameters.AddWithValue("@abilities", pokemon.Abilities);
            command.Parameters.AddWithValue("@is_evolve", pokemon.IsEvolve);
            command.Parameters.AddWithValue("@hp", pokemon.Hp);
            command.Parameters.AddWithValue("@atk", pokemon.AttackPoint);
            command.Parameters.AddWithValue("@def", pokemon.DeffensePoint);
            command.Parameters.AddWithValue("@spAtk", pokemon.SpAttack);
            command.Parameters.AddWithValue("@spDef", pokemon.SpDeffense);
            command.Parameters.AddWithValue("@speed", pokemon.Speed);
            command.ExecuteNonQuery();
            return 1;
        } 
        catch
        {
            return 0;
        }
    }

    public int UpdateData(Pokemon pokemon)
    {
        using SqlConnection connection = new(_connectionString);
        GetAllData();
        connection.Open();
        
        try
        {
            using SqlCommand command = new("UPDATE tb_pokemon SET name=@name, height_per_inch=@height, weight_per_lbs=@weight, element=@element, abilities=@abilities, is_evolve=@is_evolve, stats_hp=@hp, stats_atk=@atk, stats_def=@def, stats_sp_atk=@spAtk, stats_sp_def=@spDef, stats_speed=@speed WHERE id=@id", connection);
            command.Parameters.AddWithValue("@id", pokemon.Id);
            command.Parameters.AddWithValue("@name", pokemon.Name);
            command.Parameters.AddWithValue("@height", pokemon.Height);
            command.Parameters.AddWithValue("@weight", pokemon.Weight);
            command.Parameters.AddWithValue("@element", pokemon.Element);
            command.Parameters.AddWithValue("@abilities", pokemon.Abilities);
            command.Parameters.AddWithValue("@is_evolve", pokemon.IsEvolve);
            command.Parameters.AddWithValue("@hp", pokemon.Hp);
            command.Parameters.AddWithValue("@atk", pokemon.AttackPoint);
            command.Parameters.AddWithValue("@def", pokemon.DeffensePoint);
            command.Parameters.AddWithValue("@spAtk", pokemon.SpAttack);
            command.Parameters.AddWithValue("@spDef", pokemon.SpDeffense);
            command.Parameters.AddWithValue("@speed", pokemon.Speed);
            
            return command.ExecuteNonQuery();
        }
        catch
        {
            return 0;
        }
    }

    public int DeleteData(int id)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            using SqlCommand command = new("DELETE FROM tb_pokemon WHERE id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
}