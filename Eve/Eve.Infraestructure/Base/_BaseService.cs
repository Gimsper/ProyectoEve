using Eve.Core.Entities;
using Eve.Infraestructure.Base.Interfaces;
using Eve.Shared.Utils;

namespace Eve.Infraestructure.Base
{
    public class _BaseService : _IBaseService { }

    public class _BaseService<T> : _BaseService, _IBaseService<T> where T : _BaseEntity
    {
        private readonly _IBaseRepository<T> _repository;

        public _BaseService(_IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public ResultOperation<T> GetAll()
        {
            ResultOperation<T> result = new ResultOperation<T>();
            try
            {
                result.Results = _repository.GetAll();              
            }
            catch (Exception ex)
            {
                result.StateOperation = false;
                result.ErrorMessage = ex.Message;
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }

        public ResultOperation<T> GetById(int id)
        {
            ResultOperation<T> result = new ResultOperation<T>();
            try
            {
                result.Result = _repository.GetById(id);
            }
            catch (Exception ex)
            {
                result.StateOperation = false;
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }

        public ResultOperation<T> Add(T entity)
        {
            ResultOperation<T> result = new ResultOperation<T>();
            try
            {
                result.Result = _repository.Add(entity);
            }
            catch (Exception ex)
            {
                result.StateOperation= false;
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }

        public ResultOperation<bool> Update(T entity)
        {
            ResultOperation<bool> result = new ResultOperation<bool>();
            try
            {
                result.Result = _repository.Update(entity);
            }
            catch (Exception ex)
            {
                result.StateOperation = false;
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }

        public ResultOperation<bool> DeleteById(int id)
        {
            ResultOperation<bool> result = new ResultOperation<bool>();
            try
            {
                result.Result = _repository.DeleteById(id);
            }
            catch (Exception ex)
            {
                result.StateOperation = false;
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            return result;
        }
    }
}
