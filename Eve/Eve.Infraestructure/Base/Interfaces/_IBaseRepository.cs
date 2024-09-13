using Eve.Core.Entities;

namespace Eve.Infraestructure.Base.Interfaces
{
    public interface _IBaseRepository { }

    public interface _IBaseRepository<T> : _IBaseRepository where T : _BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        bool Update(T entity);
        bool DeleteById(int id);
    }
}
