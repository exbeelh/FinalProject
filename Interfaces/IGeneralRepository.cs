namespace FinalProject.Interfaces;

interface IGeneralRepository<T>
{
    List<T> GetAllData();
    T GetDataById (int id);
    int InsertData (T entity);
    int UpdateData (T entity);
    int DeleteData (int id);
}