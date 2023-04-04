using FinalProject.Interfaces;
using FinalProject.Models;
using System.Data.SqlClient;

namespace FinalProject.Repositories;

class AbilitiesRepository : IAbilitiesRepository
{
    private readonly string _connectionString;

    public AbilitiesRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Abilities> GetAbilities()
    {
        SqlConnection connection = new(_connectionString);
        connection.Open();

        using SqlCommand command = new("SELECT * FROM tb_abilities", connection);
        using SqlDataReader reader = command.ExecuteReader();
        var abilities = new List<Abilities>();
        while (reader.Read())
        {
            abilities.Add(new Abilities
            {
                Name = (string)reader[0],
                Element = (string)reader[1],
                Effect = (bool)reader[2],
                Damagable = (bool)reader[3],
                
            });
        }
        return abilities;
    }
}