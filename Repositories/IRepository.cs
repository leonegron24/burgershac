public interface IRepository<T>
{
    List<T> GetAll();
    T GetById(int id);
    T Create(T data);
    void Delete(int id);
    void Update(T updateData);
}