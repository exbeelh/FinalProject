using FinalProject.Interfaces;
using FinalProject.Models;
using System.Data.SqlClient;

namespace FinalProject.Repositories;

class ElementRepo:IElementRepository
{
    private readonly string _connectionString;

    public ElementRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Element> GetElements()
    {
        SqlConnection connection = new(_connectionString);
        connection.Open();

        using SqlCommand command = new("SELECT * FROM tb_element", connection);
        using SqlDataReader reader = command.ExecuteReader();
        var element = new List<Element>();
        while (reader.Read())
        {
            element.Add(new Element
            {
                Id = (string)reader[0],
                Name = (string)reader[1],
                AvgHp = (double)reader[2],
                AvgAtk = (double)reader[3],
                AvgDeff = (double)reader[4],
                AvgSpAtk = (double)reader[5],
                AvgSpDeff = (double)reader[6],
                AvgSpeed = (double)reader[7],
                Cons = (string)reader[8],
                Pros = (string)reader[9]
            });
        }
        return element;
    }
}
