using Eve.Shared.Utils;

namespace Eve.Infraestructure.Base.Interfaces
{
    public interface _IService { }

    public interface _IService<T> : _IService where T : class
    {
        ResultOperation<T> GetAll();
        ResultOperation<T> GetBy(Func<T, bool> func);
        ResultOperation<T> GetListBy(Func<T, bool> func);
        ResultOperation<T> Add(T entity);
        ResultOperation<bool> Update(T entity);
        ResultOperation<bool> Delete(T entity);
    } 
}
