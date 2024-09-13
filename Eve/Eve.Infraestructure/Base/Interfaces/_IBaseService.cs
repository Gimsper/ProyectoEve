using Eve.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.Infraestructure.Base.Interfaces
{
    public interface _IBaseService { }

    public interface _IBaseService<T> : _IBaseService
    {
        ResultOperation<T> GetAll();
        ResultOperation<T> GetById(int id);
        ResultOperation<T> Add(T entity);
        ResultOperation<bool> Update(T entity);
        ResultOperation<bool> DeleteById(int id);
    }
}
