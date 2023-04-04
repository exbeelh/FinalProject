using Models.FinalProject;

namespace FinalProject.Interfaces;
interface IPokemonRepository
{
    List<Pokemon> GetAllData();
    Pokemon GetDataById(int id);
    void CreateData(Pokemon pokemon);
    void UpdateData(Pokemon pokemon);
    void DeleteData(int id);
}