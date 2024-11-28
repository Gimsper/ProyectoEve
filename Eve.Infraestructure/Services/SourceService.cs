using Eve.Core.Models.Entities;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;
using Eve.Infraestructure.Services.Interfaces;
using Eve.Shared.Utils;

namespace Eve.Infraestructure.Services
{
    public class SourceService : _Service<Source>, ISourceService
    {
        private readonly ISourceRepository _repository;
    
        public SourceService(ISourceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ResultOperation<Source> GetSourcesWithCategories()
        {
            ResultOperation<Source> rst = new();
            try
            {
                rst.Results = _repository.GetSourcesWithCategories();
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.Result = null;
                rst.MessageError = ex.Message;
            }

            return rst;
        }
    }
}
