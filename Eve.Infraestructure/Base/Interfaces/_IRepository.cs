using Microsoft.EntityFrameworkCore;

namespace Eve.Infraestructure.Base.Interfaces
{
    public interface _IRepository { }

    public interface _IRepository<T> : _IRepository where T : class
    {
        List<T> GetAll();
        T GetBy(Func<T, bool> func);
        List<T> GetListBy(Func<T, bool> func);
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
