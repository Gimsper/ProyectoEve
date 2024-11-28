using Azure;
using Eve.Infraestructure.Base.Interfaces;
using Eve.Shared.Utils;
using System.Text;
using System.Xml;

namespace Eve.Infraestructure.Base
{
    public class _Service : _IService { }
    
    public class _Service<T> : _Service, _IService<T> where T : class
    {
        private readonly _IRepository<T> _repository;

        public _Service(_IRepository<T> repository)
        {
            _repository = repository;
        }

        public ResultOperation<T> GetAll()
        {
            ResultOperation<T> rst = new();
            try
            {
                rst.Results = _repository.GetAll();
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.MessageError = ex.Message;
            }

            return rst;
        }

        public ResultOperation<T> GetBy(Func<T, bool> func)
        {
            ResultOperation<T> rst = new();
            try
            {
                rst.Result = _repository.GetBy(func);
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.MessageError = ex.Message;
            }

            return rst;
        }

        public ResultOperation<T> GetListBy(Func<T, bool> func)
        {
            ResultOperation<T> rst = new();
            try
            {
                rst.Results = _repository.GetListBy(func);
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.MessageError = ex.Message;
            }

            return rst;
        }

        public ResultOperation<T> Add(T entity)
        {
            ResultOperation<T> rst = new();
            try
            {
                rst.Result = _repository.Add(entity);
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.MessageError = ex.Message;
            }

            return rst;
        }

        public ResultOperation<bool> Update(T entity)
        {
            ResultOperation<bool> rst = new();
            try
            {
                rst.Result = _repository.Update(entity);
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.MessageError = ex.Message;
            }

            return rst;
        }

        public ResultOperation<bool> Delete(T entity)
        {
            ResultOperation<bool> rst = new();
            try
            {
                rst.Result = _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.MessageError = ex.Message;
            }

            return rst;
        }
    }
}
