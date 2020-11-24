namespace MVCWebApplication.DAL.Interface
{
    public interface IReadRepository<T> where T : class
    {
        T GetById(int id);

        T Get(T model);
    }
}
